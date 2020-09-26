using CustomerManagement.Domain.Enums;
using CustomerManagement.Infrastructure.CrossCuting.Extensions;
using Eventos.IO.Domain.Core.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomerManagement.Domain.Entities
{
    public class Cliente : Entity<Cliente>
    {
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public TipoSexo TipoSexo { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }
        public virtual ICollection<Endereco> Enderecos { get; private set; } = new List<Endereco>();

        public Cliente(string nome, string sobreNome, DateTime dataNascimento, TipoSexo tipoSexo,
            string email, string telefone)
        {
            this.CreateGuid();
            Nome = nome;
            Sobrenome = sobreNome;
            DataNascimento = dataNascimento;
            TipoSexo = tipoSexo;
            Email = email;
            Telefone = telefone;
        }

        protected Cliente() { }

        public void AdicionarEndereco(Endereco endereco)
        {
            if (endereco == null || !endereco.IsValid())
                return;
            Enderecos.Add(endereco);
        }

        public Endereco GetEndereco(Guid id) => Enderecos.FirstOrDefault(x=> x.Id.Equals(id));


        public override bool IsValid()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        private void Validar()
        {
            RuleFor(x => x.Nome)
               .NotEmpty().WithMessage("O campo Nome é obrigatório")
               .Length(2, 150).WithMessage("Deve conter entre 2 e 15 caracteres");

            RuleFor(x => x.Sobrenome)
               .NotEmpty().WithMessage("O campo Sobrenome é obrigatório")
               .Length(2, 150).WithMessage("Deve conter entre 2 e 150 caracteres");
        }
    }
}
