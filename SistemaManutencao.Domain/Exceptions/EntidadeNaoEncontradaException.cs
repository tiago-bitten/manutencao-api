namespace SistemaManutencao.Domain.Exceptions
{
    public class EntidadeNaoEncontradaException : BaseException
    {
        public EntidadeNaoEncontradaException(string codigo, string entidade) 
            : base(codigo, entidade)
        {
        }
    }
}
