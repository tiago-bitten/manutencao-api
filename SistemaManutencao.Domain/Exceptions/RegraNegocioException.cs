namespace SistemaManutencao.Domain.Exceptions
{
    public class RegraNegocioException : BaseException
    {
        public RegraNegocioException(string codigo, string message)
            : base(codigo, message)
        {
        }
    }
}
