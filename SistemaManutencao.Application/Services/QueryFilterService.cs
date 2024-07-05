using System.Linq.Expressions;
using SistemaManutencao.Domain.Entities;
using SistemaManutencao.Domain.Interfaces.Services;
using System.Linq.Dynamic.Core;
using System.Reflection;

namespace SistemaManutencao.Application.Services
{
    public class QueryFilterService : IQueryFilterService
    {
        public IQueryable<T> AplicarTodosOsFiltros<T>(IQueryable<T> query, Filtro filtros)
        {
            foreach (var filtro in filtros.Filtrar)
            {
                if (!string.IsNullOrEmpty(filtro.Value))
                {
                    var propriedade = filtro.Key;
                    var valor = filtro.Value;

                    try
                    {
                        if (propriedade.Contains("."))
                        {
                            // Tratamento para propriedades aninhadas e coleções
                            query = query.Where(GenerateNestedFilterExpression<T>(propriedade, valor));
                        }
                        else
                        {
                            // Filtro simples
                            query = query.Where($"{propriedade}.Contains(@0)", valor);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Log e tratamento de erro
                        throw new InvalidOperationException($"Erro ao aplicar filtro na propriedade '{propriedade}': {ex.Message}", ex);
                    }
                }
            }

            if (!string.IsNullOrEmpty(filtros.OrdenarPor))
            {
                query = query.OrderBy($"{filtros.OrdenarPor} {(filtros.OrdemAsc ? "ascending" : "descending")}");
            }

            query = query.Skip((filtros.Pagina - 1) * filtros.TamanhoPagina).Take(filtros.TamanhoPagina);

            return query;
        }

        private static Expression<Func<T, bool>> GenerateNestedFilterExpression<T>(string propertyPath, string value)
        {
            var parameter = Expression.Parameter(typeof(T), "x");
            var properties = propertyPath.Split('.');
            Expression expression = parameter;

            for (int i = 0; i < properties.Length; i++)
            {
                var property = properties[i];
                var propertyInfo = GetPropertyInfo(expression.Type, property);

                if (propertyInfo == null)
                {
                    throw new ArgumentException($"'{property}' is not a member of type '{expression.Type}'");
                }

                if (i < properties.Length - 1 && typeof(System.Collections.IEnumerable).IsAssignableFrom(propertyInfo.PropertyType) && propertyInfo.PropertyType != typeof(string))
                {
                    // Propriedade é uma coleção
                    var elementType = propertyInfo.PropertyType.GetGenericArguments().FirstOrDefault() ?? propertyInfo.PropertyType.GetElementType();
                    var anyMethod = typeof(Enumerable).GetMethods()
                        .First(m => m.Name == "Any" && m.GetParameters().Length == 2)
                        .MakeGenericMethod(elementType);

                    var lambdaParameter = Expression.Parameter(elementType, "y");
                    var subProperty = properties[i + 1];
                    var subPropertyInfo = GetPropertyInfo(elementType, subProperty);

                    if (subPropertyInfo == null)
                    {
                        throw new ArgumentException($"'{subProperty}' is not a member of type '{elementType}'");
                    }

                    var subContainsExpression = GenerateContainsExpression(subPropertyInfo, lambdaParameter, properties.Skip(i + 1).ToArray(), value);
                    var lambda = Expression.Lambda(subContainsExpression, lambdaParameter);

                    expression = Expression.Call(anyMethod, Expression.Property(expression, propertyInfo), lambda);
                    break;
                }
                else
                {
                    // Propriedade simples
                    expression = Expression.Property(expression, propertyInfo);
                }
            }

            if (expression.Type != typeof(string))
            {
                throw new InvalidOperationException("The final property in the path must be a string to apply 'Contains'.");
            }

            var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
            var constant = Expression.Constant(value, typeof(string));
            var containsExpression = Expression.Call(expression, containsMethod, constant);

            return Expression.Lambda<Func<T, bool>>(containsExpression, parameter);
        }

        private static Expression GenerateContainsExpression(PropertyInfo propertyInfo, ParameterExpression parameter, string[] subPropertyPath, string value)
        {
            Expression expression = Expression.Property(parameter, propertyInfo);

            for (int i = 1; i < subPropertyPath.Length; i++)
            {
                var property = subPropertyPath[i];
                propertyInfo = GetPropertyInfo(expression.Type, property);

                if (propertyInfo == null)
                {
                    throw new ArgumentException($"'{property}' is not a member of type '{expression.Type}'");
                }

                expression = Expression.Property(expression, propertyInfo);
            }

            if (expression.Type != typeof(string))
            {
                throw new InvalidOperationException("The final property in the path must be a string to apply 'Contains'.");
            }

            var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
            var constant = Expression.Constant(value, typeof(string));
            return Expression.Call(expression, containsMethod, constant);
        }

        private static PropertyInfo GetPropertyInfo(Type type, string propertyName)
        {
            return type.GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
        }
    }
}
