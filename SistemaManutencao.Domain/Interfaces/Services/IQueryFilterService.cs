using SistemaManutencao.Domain.Entities;

namespace SistemaManutencao.Domain.Interfaces.Services
{
    public interface IQueryFilterService
    {
        //IQueryable<T> AplicarFiltroPorCampo<T>(IQueryable<T> entidades, Dictionary<string, string?> filtros);
        //IQueryable<T> AplicarOrdenacao<T>(IQueryable<T> entidades, string ordemPor, bool ordemAsc);
        //IQueryable<T> AplicarPaginacao<T>(IQueryable<T> entidades, int pagina, int tamanhoPagina);
        IQueryable<T> AplicarTodosOsFiltros<T>(IQueryable<T> entidades, Filtro filtro);
    }
}
