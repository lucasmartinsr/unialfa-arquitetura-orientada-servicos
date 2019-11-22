using Newtonsoft.Json;

namespace UI.WebApi.Utils
{
    public class ErroEspecifico
    {
        public ErroEspecifico(int codigo, string[] erros)
        {
            Codigo = codigo;
            Erros = erros;
        }

        [JsonProperty("codigo")]
        public int Codigo { get; set; }

        [JsonProperty("erros")]
        public string[] Erros { get; set; }
    }
}
