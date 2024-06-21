using System.Text.Json.Serialization;

namespace SistemaManutencao.Application.Responses
{
    public class RespostaBaseApi<T>
    {
        public bool Sucesso { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Mensagem { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<string> Erros { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public T Conteudo { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Total { get; set; }

        public RespostaBaseApi()
        {
            Erros = new List<string>();
        }
    }
}
