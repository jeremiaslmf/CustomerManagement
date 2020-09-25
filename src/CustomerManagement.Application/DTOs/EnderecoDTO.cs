using System;

namespace CustomerManagement.Application.DTOs
{
    public class EnderecoDTO
    {
        public class Gravar : Dados
        {
        }

        public class Excluir : ObterPorId
        {
        }

        public class ObterPorId
        {
            public Guid Id { get; set; }
        }

        public class Dados
        {
            public Guid ClienteId { get; set; }
            public string Logradouro { get; set; }
            public string Numero { get; set; }
            public string Complemento { get; set; }
            public string Bairro { get; set; }
            public string CEP { get; set; }
            public string Localidade { get; set; }
            public string Uf { get; set; }

            public Dados(string logradouro, string numero, string complemento, 
                string bairro, string cep, string cidade, string ufEstado)
            {
                Logradouro = logradouro;
                Numero = numero;
                Complemento = complemento;
                Bairro = bairro;
                CEP = cep;
                Localidade = cidade;
                Uf = ufEstado;
            }

            public Dados() { }
        }

        public class Retorno : Dados
        {
        }
    }
}
