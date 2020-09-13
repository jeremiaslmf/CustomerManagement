using CustomerManagement.Application.DTOs;
using CustomerManagement.Application.Interfaces;
using CustomerManagement.Application.Models;
using CustomerManagement.Domain.Entities;
using CustomerManagement.Domain.Enums;
using CustomerManagement.Domain.Interfaces;
using Nelibur.ObjectMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomerManagement.Application.Services
{
    public class ClienteService : GenericService, IClienteService
    {
        public ClienteService(IUnitOfWork iuow) : base(iuow) { }

        public bool Gravar(ClienteDTO.Gravar dto)
        {
            var cliente = CriarCliente(dto);
            SetEnderecosCliente(dto.Enderecos, cliente);
            UnitOfWork.ClienteRepository.Add(cliente);
            return UnitOfWork.SaveChanges();
        }

        public void Exlcuir(ClienteDTO.Excluir dto)
        {
            UnitOfWork.ClienteRepository.Delete(GetCliente(dto.Id));
            UnitOfWork.SaveChanges();
        }

        public ClienteDTO.Retorno GetById(Guid id)
        {
            var cliente = GetCliente(id);
            var enderecos = UnitOfWork.EnderecoRepository.GetAllByClienteId(cliente.Id);
            foreach (var item in enderecos)
                cliente.AdicionarEndereco(item);
                
            return TinyMapper.Map<ClienteDTO.Retorno>(cliente);
        }

        public List<ClienteDTO.Retorno> GetAll()
        {
            var clientes = UnitOfWork.ClienteRepository.GetAll().ToList();
            return TinyMapper.Map<List<ClienteDTO.Retorno>>(clientes);
        }

        private Cliente GetCliente(Guid id)
            => UnitOfWork.ClienteRepository.GetById(id)
                ?? throw new Exception("Cliente não encontrado!");

        private Cliente CriarCliente(ClienteDTO.Gravar dto)
            => new Cliente(dto.Nome, dto.SobreNome, dto.DataNascimento,
                TipoSexo.Outro, dto.Email, dto.Telefone);

        private void SetEnderecosCliente(List<EnderecoDTO.Dados> enderecos, Cliente cliente)
        {
            enderecos.ForEach(x =>
                cliente.AdicionarEndereco(new Endereco(
                    cliente.Id,
                    x.Logradouro,
                    x.DescricaoEndereco,
                    x.Numero,
                    x.Complemento,
                    x.Bairro,
                    x.CEP,
                    x.Cidade,
                    x.UfEstado)));
        }
    }
}
