using CustomerManagement.Application.DTOs;
using System;

namespace CustomerManagement.Application.Models
{
    public class ClienteModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string TipoSexo { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public EnderecoDTO.Dados Endereco { get; set; }

        public ClienteModel() { }
    }
}
