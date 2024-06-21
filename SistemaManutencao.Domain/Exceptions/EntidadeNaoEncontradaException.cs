namespace SistemaManutencao.Domain.Exceptions
{
    public class EntidadeNaoEncontradaException : Exception
    {
        public string Codigo { get; }

        public EntidadeNaoEncontradaException(string codigo, string entidade) 
            : base($"{codigo}: {entidade} não encontrada")
        {
            Codigo = codigo;
        }
    }
}
