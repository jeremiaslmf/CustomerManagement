using CustomerManagement.Application.DTOs;
using System;
using System.Collections.Generic;

namespace CustomerManagement.Application.Models
{
    public class ClienteModel
    {
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string TipoSexo { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public List<EnderecoDTO.Dados> Enderecos { get; set; }
    }
}
