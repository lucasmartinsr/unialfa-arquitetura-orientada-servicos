using Newtonsoft.Json;

namespace UI.WebApi.Utils
{
    public class ErroGenerico
    {
        public ErroGenerico(object codigo, string mensagem)
        {
            Codigo = codigo;
            Mensagem = mensagem;
        }

        [JsonProperty("codigo")]
        public object Codigo { get; set; }

        [JsonProperty("message")]
        public string Mensagem { get; set; }
    }
}
