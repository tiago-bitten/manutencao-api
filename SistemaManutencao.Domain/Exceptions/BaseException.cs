namespace SistemaManutencao.Domain.Exceptions
{
    public class BaseException : Exception
    {
        public string Codigo { get; }

        public BaseException(string codigo, string message) 
            : base($"{codigo}:=: {message} não encontrada")
        {
            Codigo = codigo;
        }
    }
}
