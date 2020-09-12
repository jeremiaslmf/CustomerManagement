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
            public string DescricaoEndereco { get; set; }
            public string Numero { get; set; }
            public string Complemento { get; set; }
            public string Bairro { get; set; }
            public string CEP { get; set; }
            public string Cidade { get; set; }
            public string UfEstado { get; set; }
        }

        public class Retorno : Dados
        {
        }
    }
}
