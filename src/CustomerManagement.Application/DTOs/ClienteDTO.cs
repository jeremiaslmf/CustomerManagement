using CustomerManagement.Application.Models;
using System;
using System.Collections.Generic;

namespace CustomerManagement.Application.DTOs
{
    public class ClienteDTO
    {
        public class Gravar : ClienteModel { }

        public class Excluir : ObterPorId { }

        public class ObterPorId
        {
            public Guid Id { get; set; }
        }

        public class Retorno
        {
            public Guid Id { get; set; }
            public string Nome { get; set; }
            public string SobreNome { get; set; }
            public DateTime DataNascimento { get; set; }
            public string TipoSexo { get; set; }
            public string Email { get; set; }
            public string Telefone { get; set; }
            public List<EnderecoDTO.Dados> Enderecos { get; set; }
        }
    }
}
