namespace SistemaManutencao.Application.DTOs.Entities.Auth
{
    public class TokenDTO
    {
        public string Token { get; set; }
        public DateTime LogadoEm { get; private set; } = DateTime.Now;
    }
}
