using Bogus;
using CustomerManagement.Application.DTOs;
using CustomerManagement.Application.Interfaces;
using CustomerManagement.Application.Models;
using CustomerManagement.Application.Services;
using CustomerManagement.Domain.Entities;
using CustomerManagement.Domain.Enums;
using CustomerManagement.Domain.Interfaces;
using CustomerManagement.Infrastructure.Data.Context;
using CustomerManagement.Infrastructure.Data.Uow;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Linq;
using static Bogus.DataSets.Name;

namespace CustomerManagement.Applicantion.Tests
{
    [TestClass]
    public class ClienteServiceTests
    {
        private const string _owner = "Jeremias Lima";
        private const string _gravarCategory = "Gravar";
        private const string _editarCategory = "Editar";
        private const string _excluirCategory = "Excluir";
        private const string _obterCategory = "Obter";

        [TestMethod]
        [Owner(_owner)]
        [TestCategory(_gravarCategory)]
        [Description("Garantir que o serviço esteja persistindo todas as informações do cliente corretamente")]
        public void NovoCadastro_DadosValidos_ExpectedTrue()
        {
            using var context = CMTestsContext.SqlLiteInMemoryContext();
            var iuow = new UnitOfWork(context);
            var clienteService = new ClienteService(iuow);

            var genero = Gender.Female;
            var dto = GetCliente(genero, TipoSexo.Feminino, new DateTime(2000, 05, 01));
            dto.Endereco = GetEndereco(dto, "001");

            var retorno = clienteService.Gravar(dto);
            var cliente = iuow.ClienteRepository.GetAll().FirstOrDefault();

            Assert.IsNotNull(dto.Id);
            Assert.AreEqual(dto.Nome, cliente.Nome);
            Assert.AreEqual(dto.Sobrenome, cliente.Sobrenome);
            Assert.AreEqual(dto.DataNascimento, cliente.DataNascimento);
            Assert.AreEqual(dto.TipoSexo, cliente.TipoSexo.ToString());
            Assert.AreEqual(dto.Email, cliente.Email);
            Assert.AreEqual(dto.Telefone, cliente.Telefone);

            var endereco = cliente.Enderecos.FirstOrDefault();
            Assert.AreEqual(dto.Endereco.CEP, endereco.CEP);
            Assert.AreEqual(dto.Endereco.Logradouro, endereco.Logradouro);
            Assert.AreEqual(dto.Endereco.Numero, endereco.Numero);
            Assert.AreEqual(dto.Endereco.Bairro, endereco.Bairro);
            Assert.AreEqual(dto.Endereco.Complemento, endereco.Complemento);
            Assert.AreEqual(dto.Endereco.Cidade, endereco.Cidade);
            Assert.AreEqual(dto.Endereco.UfEstado, endereco.UfEstado);
            Assert.AreEqual(endereco.ClienteId, cliente.Id);

        }

        [TestMethod]
        [Owner(_owner)]
        [TestCategory(_editarCategory)]
        [Description("Garantir que o serviço esteja alterando todos os dados do cliente")]
        public void AlterarDados_DadosValidos_ExpectedTrue()
        {
            // Arrange
            using var context = CMTestsContext.SqlLiteInMemoryContext();
            var iuow = new UnitOfWork(context);
            var clienteService = new ClienteService(iuow);
            var genero = Gender.Male;
            var dto = GetCliente(genero, TipoSexo.Masculino, new DateTime(1990, 10, 10));
            dto.Endereco = GetEndereco(dto, "001");

            //Act
            var retorno = clienteService.Gravar(dto);
            var cliente = iuow.ClienteRepository.GetAll().FirstOrDefault();

            dto = GetCliente(genero, TipoSexo.Outro, new DateTime(1190, 10, 02));
            dto.Endereco = GetEndereco(dto, "555", "87200000", "PR");
            retorno = clienteService.Gravar(dto);

            // Assert
            Assert.IsNotNull(dto.Id);
            Assert.AreNotEqual(dto.Nome, cliente.Nome);
            Assert.AreNotEqual(dto.Sobrenome, cliente.Sobrenome);
            Assert.AreNotEqual(dto.DataNascimento, cliente.DataNascimento);
            Assert.AreNotEqual(dto.TipoSexo, cliente.TipoSexo.ToString());
            Assert.AreNotEqual(dto.Email, cliente.Email);
            Assert.AreNotEqual(dto.Telefone, cliente.Telefone);

            var endereco = cliente.Enderecos.FirstOrDefault();
            Assert.AreNotEqual(dto.Endereco.CEP, endereco.CEP);
            Assert.AreNotEqual(dto.Endereco.Logradouro, endereco.Logradouro);
            Assert.AreNotEqual(dto.Endereco.Numero, endereco.Numero);
            Assert.AreNotEqual(dto.Endereco.Bairro, endereco.Bairro);
            Assert.AreNotEqual(dto.Endereco.Complemento, endereco.Complemento);
            Assert.AreNotEqual(dto.Endereco.Cidade, endereco.Cidade);
            Assert.AreNotEqual(dto.Endereco.UfEstado, endereco.UfEstado);
            Assert.AreEqual(endereco.ClienteId, cliente.Id);
        }

        [TestMethod]
        [Owner(_owner)]
        [TestCategory(_excluirCategory)]
        [Description("Garantir que o serviço esteja excluindo um cliente corretamente")]
        public void ExcluirCliente_ClienteExistente_ExpectedTrue()
        {
            // Arrange
            using var context = CMTestsContext.SqlLiteInMemoryContext();
            var iuow = new UnitOfWork(context);
            var clienteService = new ClienteService(iuow);
            var genero = Gender.Male;
            var dto = GetCliente(genero, TipoSexo.Masculino, new DateTime(1990, 10, 10));
            dto.Endereco = GetEndereco(dto, "001");

            // Act
            clienteService.Gravar(dto);
            var clienteId1 = iuow.ClienteRepository.GetAll().FirstOrDefault().Id;
            clienteService.Exlcuir(new ClienteDTO.Excluir(clienteId1));

            //Assert
            Assert.IsNotNull(iuow.ClienteRepository.GetById(clienteId1));
            Assert.IsNull(iuow.EnderecoRepository.GetAllByClienteId(clienteId1));
        }

        [TestMethod]
        [Owner(_owner)]
        [TestCategory(_excluirCategory)]
        [Description("Garantir que o serviço esteja validando a exclusão de um cliente inexistente")]
        public void ExcluirCliente_ClienteInexistente_ExpectedException()
        {
            // Arrange
            using var context = CMTestsContext.SqlLiteInMemoryContext();
            var iuow = new UnitOfWork(context);
            var clienteService = new ClienteService(iuow);

            //Assert
            Assert.ThrowsException<Exception>(() =>
            clienteService.Exlcuir(new ClienteDTO.Excluir(Guid.NewGuid())),
            "Exceção não lançada para cliente inexistente");
        }

        [TestMethod]
        [Owner(_owner)]
        [TestCategory(_obterCategory)]
        [Description("Garantir que o serviço esteja retornando os dados de um cliente corretamente")]
        public void GetById_ClienteExistente_ExpectedTrue()
        {
            // Arrange
            using var context = CMTestsContext.SqlLiteInMemoryContext();
            var iuow = new UnitOfWork(context);
            var clienteService = new ClienteService(iuow);
            var genero = Gender.Male;
            var dto = GetCliente(genero, TipoSexo.Masculino, new DateTime(1980, 10, 15));
            dto.Endereco = GetEndereco(dto, "444");

            // Act
            clienteService.Gravar(dto);
            var clienteId = iuow.ClienteRepository.GetAll().FirstOrDefault().Id;
            var cliente = clienteService.GetById(clienteId);

            //Assert
            Assert.IsNotNull(dto.Id);
            Assert.AreEqual(dto.Nome, cliente.Nome);
            Assert.AreEqual(dto.Sobrenome, cliente.Sobrenome);
            Assert.AreEqual(dto.DataNascimento, cliente.DataNascimento);
            Assert.AreEqual(dto.TipoSexo, cliente.TipoSexo.ToString());
            Assert.AreEqual(dto.Email, cliente.Email);
            Assert.AreEqual(dto.Telefone, cliente.Telefone);

            var endereco = cliente.Endereco;
            Assert.AreEqual(dto.Endereco.CEP, endereco.CEP);
            Assert.AreEqual(dto.Endereco.Logradouro, endereco.Logradouro);
            Assert.AreEqual(dto.Endereco.Numero, endereco.Numero);
            Assert.AreEqual(dto.Endereco.Bairro, endereco.Bairro);
            Assert.AreEqual(dto.Endereco.Complemento, endereco.Complemento);
            Assert.AreEqual(dto.Endereco.Cidade, endereco.Cidade);
            Assert.AreEqual(dto.Endereco.UfEstado, endereco.UfEstado);
            Assert.AreEqual(endereco.ClienteId, cliente.Id);
        }

        [TestMethod]
        [Owner(_owner)]
        [TestCategory(_obterCategory)]
        [Description("Garantir que o serviço esteja validando corretamente ao tentar obter um cadastro inexistente")]
        public void GetById_ClienteIneExistente_ExpectedException()
        {
            // Arrange
            using var context = CMTestsContext.SqlLiteInMemoryContext();
            var iuow = new UnitOfWork(context);
            var clienteService = new ClienteService(iuow);

            //Act/Assert
            Assert.ThrowsException<Exception>(() =>
                clienteService.GetById(Guid.NewGuid()),
                "Exceção não lançada para cliente inexistente"
            );
        }

        private EnderecoDTO.Dados GetEndereco(ClienteDTO.Gravar dto, string idx = "", string cep = "01001000", string uf = "SP")
            => new EnderecoDTO.Dados(
                $"Praça da Sé {idx}",
                $"50{idx}",
                $"CASA {idx}",
                $"Sé {idx}",
                cep,
                $"São Paulo {idx}",
                uf);

        private static ClienteDTO.Gravar GetCliente(Gender genero, TipoSexo tipoSexo, DateTime dataNascimento)
            => new Faker<ClienteDTO.Gravar>()
                .RuleFor(p => p.Nome, p => p.Name.FirstName(genero))
                .RuleFor(p => p.Sobrenome, p => p.Name.LastName(genero))
                .RuleFor(p => p.DataNascimento, p => dataNascimento)
                .RuleFor(p => p.TipoSexo, p => tipoSexo.ToString())
                .RuleFor(p => p.Email, p => p.Person.Email)
                .RuleFor(p => p.Telefone, p => p.Random.AlphaNumeric(11))
                .Generate();

    }
}
