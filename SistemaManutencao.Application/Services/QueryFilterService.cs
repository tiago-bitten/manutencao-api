using SistemaManutencao.Domain.Entities;
using SistemaManutencao.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace SistemaManutencao.Application.Services
{
    public class QueryFilterService : IQueryFilterService
    {
        public IQueryable<T> AplicarFiltroPorCampo<T>(IQueryable<T> entidades, Dictionary<string, string> filtros)
        {
            var parameter = Expression.Parameter(typeof(T), "e");
            Expression expression = null;

            foreach (var filtro in filtros)
            {
                var propertyNames = filtro.Key.Split('.');
                Expression propertyAccess = parameter;
                Type propertyType = typeof(T);
                Expression containsExpression = null;

                for (int i = 0; i < propertyNames.Length; i++)
                {
                    var propertyName = propertyNames[i];
                    var property = propertyType.GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                    if (property == null)
                        break;

                    propertyAccess = Expression.MakeMemberAccess(propertyAccess, property);
                    propertyType = property.PropertyType;

                    if (i == propertyNames.Length - 1 && propertyType.IsGenericType && typeof(IEnumerable<>).IsAssignableFrom(propertyType.GetGenericTypeDefinition()))
                    {
                        var elementType = propertyType.GetGenericArguments()[0];
                        var lambdaParameter = Expression.Parameter(elementType, "x");
                        var innerProperty = elementType.GetProperty(propertyNames.Last(), BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                        if (innerProperty == null)
                            continue;

                        var innerPropertyAccess = Expression.MakeMemberAccess(lambdaParameter, innerProperty);
                        var filterValue = Expression.Constant(filtro.Value);
                        var toStringMethod = typeof(object).GetMethod("ToString");
                        var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                        var toStringExpression = Expression.Call(innerPropertyAccess, toStringMethod);
                        containsExpression = Expression.Call(toStringExpression, containsMethod, filterValue);

                        var lambdaExpression = Expression.Lambda(containsExpression, lambdaParameter);
                        var anyMethod = typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
                            .First(m => m.Name == "Any" && m.GetParameters().Length == 2)
                            .MakeGenericMethod(elementType);
                        propertyAccess = Expression.Call(anyMethod, propertyAccess, lambdaExpression);
                        break;
                    }
                }

                if (propertyAccess != parameter && containsExpression == null && !string.IsNullOrEmpty(filtro.Value))
                {
                    var filterValue = Expression.Constant(filtro.Value);
                    var toStringMethod = typeof(object).GetMethod("ToString");
                    var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                    var toStringExpression = Expression.Call(propertyAccess, toStringMethod);
                    containsExpression = Expression.Call(toStringExpression, containsMethod, filterValue);
                }

                if (containsExpression != null)
                {
                    if (expression == null)
                    {
                        expression = containsExpression;
                    }
                    else
                    {
                        expression = Expression.AndAlso(expression, containsExpression);
                    }
                }
            }

            if (expression == null)
            {
                return entidades;
            }

            var lambda = Expression.Lambda<Func<T, bool>>(expression, parameter);
            return entidades.Where(lambda);
        }

        public IQueryable<T> AplicarOrdenacao<T>(IQueryable<T> entidades, string ordenarPor, bool ordemAsc)
        {
            if (!string.IsNullOrEmpty(ordenarPor))
            {
                var propertyNames = ordenarPor.Split('.');
                var parameter = Expression.Parameter(typeof(T), "e");
                Expression propertyAccess = parameter;

                foreach (var propertyName in propertyNames)
                {
                    var property = propertyAccess.Type.GetProperty(propertyName);
                    if (property == null)
                        return entidades;

                    propertyAccess = Expression.MakeMemberAccess(propertyAccess, property);
                }

                var orderByExp = Expression.Lambda(propertyAccess, parameter);

                var orderByMethod = ordemAsc
                    ? "OrderBy"
                    : "OrderByDescending";

                var resultExp = Expression.Call(typeof(Queryable), orderByMethod, new Type[] { typeof(T), propertyAccess.Type },
                                                entidades.Expression, Expression.Quote(orderByExp));

                return entidades.Provider.CreateQuery<T>(resultExp);
            }
            return entidades;
        }

        public IQueryable<T> AplicarPaginacao<T>(IQueryable<T> entidades, int pagina, int tamanhoPagina)
        {
            return entidades.Skip((pagina - 1) * tamanhoPagina).Take(tamanhoPagina);
        }

        public IQueryable<T> AplicarTodosOsFiltros<T>(IQueryable<T> entidades, Filtro filtro)
        {
            entidades = AplicarFiltroPorCampo(entidades, filtro.Filtrar);
            entidades = AplicarOrdenacao(entidades, filtro.OrdenarPor, filtro.OrdemAsc);
            return AplicarPaginacao(entidades, filtro.Pagina, filtro.TamanhoPagina);
        }
    }
}
