using System.Text.Json.Serialization;

namespace CustomerManagement.Application.DTOs
{
    public class CepDTO
    {
        public class Envio
        {
            public string Cep { get; set; }
        }

        public class Retorno
        {
            [JsonPropertyName("cep")]
            public string CEP { get; set; }
            [JsonPropertyName("logradouro")]
            public string Logradouro { get; set; }
            [JsonPropertyName("complemento")]
            public string Complemento { get; set; }
            [JsonPropertyName("bairro")]
            public string Bairro { get; set; }
            [JsonPropertyName("localidade")]
            public string Localidade { get; set; }
            [JsonPropertyName("uf")]
            public string Uf { get; set; }

        }
    }
}
