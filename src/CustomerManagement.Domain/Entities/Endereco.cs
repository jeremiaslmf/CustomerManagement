using CustomerManagement.Infrastructure.CrossCuting.Extensions;
using Eventos.IO.Domain.Core.Models;
using FluentValidation;
using System;
using System.Text.RegularExpressions;

namespace CustomerManagement.Domain.Entities
{
    public class Endereco : Entity<Endereco>
    {
        public Endereco(Guid clienteId, string logradouro, string numero, string complemento,
            string bairro, string cep, string cidade, string ufEstado)
        {
            this.CreateGuid();
            ClienteId = clienteId;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            SetCep(cep);
            Localidade = cidade;
            Uf = ufEstado;
        }

        protected Endereco() { }

        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string CEP { get; private set; }
        public string Localidade { get; private set; }
        public string Uf { get; private set; }

        public Guid ClienteId { get; private set; }
        public virtual Cliente Cliente { get; private set; }

        public string SetCep(string cep)
            => CEP = cep.RemoveSpecialCharacters();

        public override bool IsValid()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        private void Validar()
        {
            ValidarLogradouro();
            ValidarBairro();
            ValidarCEP();
            ValidarCidade();
            ValidarEstado();
            ValidarNumero();
            ValidationResult = Validate(this);
        }

        private void ValidarLogradouro()
        {
            RuleFor(x => x.Logradouro)
                .NotEmpty().WithMessage("O campo Logradouro é obrigatório")
                .Length(2, 150).WithMessage("Deve conter entre 2 e 150 caracteres");
        }

        private void ValidarBairro()
        {
            RuleFor(x => x.Bairro)
                .NotEmpty().WithMessage("O campo Bairro é obrigatório")
                .Length(2, 150).WithMessage("Deve conter entre 2 e 150 caracteres");
        }

        private void ValidarCEP()
        {
            RuleFor(x => x.CEP)
             .NotEmpty().WithMessage("O campo CEP é obrigatório")
             .Length(8).WithMessage("Deve conter 8 caracteres");
        }

        private void ValidarCidade()
        {
            RuleFor(x => x.Localidade)
                .NotEmpty().WithMessage("O campo Cidade é obrigatório")
                .Length(2, 150).WithMessage("Deve conter entre 2 e 150 caracteres");
        }

        private void ValidarEstado()
        {
            RuleFor(x => x.Uf)
                .NotEmpty().WithMessage("O campo Estado é obrigatório")
                .Length(2, 150).WithMessage("Deve conter entre 2 e 150 caracteres");
        }

        private void ValidarNumero()
        {
            RuleFor(x => x.Numero)
                .NotEmpty().WithMessage("O campo Número é obrigatório")
                .Length(1, 10).WithMessage("Deve conter entre 1 e 10 caracteres");
        }
    }
}