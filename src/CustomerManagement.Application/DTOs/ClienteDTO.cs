using CustomerManagement.Application.Models;
using System;

namespace CustomerManagement.Application.DTOs
{
    public class ClienteDTO
    {
        public class Gravar
        {
            public Guid Id { get; set; }
            public string Nome { get; set; }
            public string Sobrenome { get; set; }
            public DateTime DataNascimento { get; set; }
            public string TipoSexo { get; set; }
            public string Email { get; set; }
            public string Telefone { get; set; }
            public EnderecoDTO.Dados Endereco { get; set; }

            public Gravar(string nome, string sobreNome,
                DateTime dataNascimento, string tipoSexo, string email,
                string telefone, EnderecoDTO.Dados endereco)
            {
                Nome = nome;
                Sobrenome = sobreNome;
                DataNascimento = dataNascimento;
                TipoSexo = tipoSexo;
                Email = email;
                Telefone = telefone;
                Endereco = endereco;
            }

            public Gravar() { }
        }

        public class Excluir : ObterPorId
        {
            public Excluir(Guid id) : base(id) { }

            public Excluir() { }
        }

        public class ObterPorId
        {
            public Guid Id { get; set; }

            public ObterPorId(Guid id)
            {
                Id = id;
            }

            public ObterPorId() { }
        }

        public class Retorno
        {
            public Guid Id { get; set; }
            public string Nome { get; set; }
            public string Sobrenome { get; set; }
            public DateTime DataNascimento { get; set; }
            public string TipoSexo { get; set; }
            public string Email { get; set; }
            public string Telefone { get; set; }
            public EnderecoDTO.Dados Endereco { get; set; }
        }
    }
}
