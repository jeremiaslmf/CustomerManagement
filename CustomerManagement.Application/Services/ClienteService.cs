using CustomerManagement.Application.DTOs;
using CustomerManagement.Application.Interfaces;
using CustomerManagement.Application.Models;
using CustomerManagement.Domain.Entities;
using CustomerManagement.Domain.Enums;
using CustomerManagement.Domain.Interfaces;
using Nelibur.ObjectMapper;
using System;
using System.Linq;

namespace CustomerManagement.Application.Services
{
    public class ClienteService : GenericService, IClienteService
    {
        public ClienteService(IUnitOfWork iuow) : base(iuow) { }

        public bool Gravar(ClienteDTO.Gravar dto)
        {
            var cliente = new Cliente(
                dto.Nome,
                dto.SobreNome,
                dto.DataNascimento,
                TipoSexo.Outro,
                dto.Email,
                dto.Telefone);

            var endereco = new Endereco(
                dto.Endereco.Logradouro,
                dto.Endereco.DescricaoEndereco,
                dto.Endereco.Numero,
                dto.Endereco.Complemento,
                dto.Endereco.Bairro,
                dto.Endereco.CEP,
                dto.Endereco.Cidade,
                dto.Endereco.UfEstado);

            cliente.AdicionarEndereco(endereco);

            UnitOfWork.ClienteRepository.Add(cliente);
            return UnitOfWork.SaveChanges();
        }

        public void Exlcuir(ClienteDTO.Excluir dto)
        {
            var cliente = GetCliente(dto.Id);
            UnitOfWork.ClienteRepository.Delete(cliente);
            UnitOfWork.SaveChanges();
        }

        public ClienteDTO.Retorno ObterPorId(Guid id)
        {
            var cliente = GetCliente(id);
            return TinyMapper.Map<ClienteDTO.Retorno>(cliente);
        }

        private Cliente GetCliente(Guid id)
            => UnitOfWork.ClienteRepository.GetById(id)
                ?? throw new Exception("Cliente não encontrado!");
    }
}
