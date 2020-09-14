using CustomerManagement.Application.DTOs;
using CustomerManagement.Application.Interfaces;
using CustomerManagement.Domain.Entities;
using CustomerManagement.Domain.Interfaces;
using Nelibur.ObjectMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomerManagement.Application.Services
{
    public class EnderecoService : GenericService, IEnderecoService
    {
        public EnderecoService(IUnitOfWork iuow) : base(iuow) { }

        public bool Gravar(EnderecoDTO.Gravar dto)
        {
            var cliente = GetCliente(dto.ClienteId);
            var endereco = CriarEndereco(dto);
            cliente.AdicionarEndereco(endereco);
            UnitOfWork.EnderecoRepository.Add(endereco);
            return UnitOfWork.SaveChanges();
        }
        
        public void Exlcuir(EnderecoDTO.Excluir dto)
        {
            UnitOfWork.EnderecoRepository.Delete(GetEndereco(dto.Id));
            UnitOfWork.SaveChanges();
        }

        public EnderecoDTO.Retorno GetByClienteId(Guid id)
        {
            var cliente = GetCliente(id);
            var enderecos = UnitOfWork.EnderecoRepository.GetAllByClienteId(cliente.Id);
            return TinyMapper.Map<EnderecoDTO.Retorno>(enderecos); 
        }

        public EnderecoDTO.Retorno GetById(Guid id)
        {
            var endereco = TinyMapper.Map<EnderecoDTO.Retorno>(GetEndereco(id)); 
            return endereco;
        }

        public List<EnderecoDTO.Retorno> GetAllByClienteId(Guid id)
        {
            var cliente = GetCliente(id);
            var enderecos = TinyMapper.Map<List<EnderecoDTO.Retorno>>(
                UnitOfWork.EnderecoRepository.GetAllByClienteId(cliente.Id).ToList());
            return enderecos;
        }

        private Endereco GetEndereco(Guid id)
            => UnitOfWork.EnderecoRepository.GetById(id)
                ?? throw new Exception("Endereço não encontrado!");

        private Cliente GetCliente(Guid id)
            => UnitOfWork.ClienteRepository.GetById(id)
                ?? throw new Exception("Cliente não encontrado!");

        private Endereco CriarEndereco(EnderecoDTO.Gravar dto)
            => new Endereco(dto.ClienteId, dto.Logradouro, dto.Numero, dto.Complemento,
                dto.Bairro, dto.CEP, dto.Cidade, dto.UfEstado);
    }
}
