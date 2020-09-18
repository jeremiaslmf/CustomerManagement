using CustomerManagement.Application.DTOs;
using CustomerManagement.Application.Interfaces;
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
            Cliente cliente;
            if ((cliente = UnitOfWork.ClienteRepository.GetById(dto.Id)) == null)
                return CriarCliente(dto);

            return EditarCliente(cliente, dto);
        }

        public void Exlcuir(ClienteDTO.Excluir dto)
        {
            var cliente = GetCliente(dto.Id);
            UnitOfWork.ClienteRepository.Delete(cliente);
            UnitOfWork.SaveChanges();
        }

        public ClienteDTO.Retorno GetById(Guid id)
        {
            var cliente = GetCliente(id);
            MapDatas();
            var clienteMap = TinyMapper.Map<ClienteDTO.Retorno>(cliente);
            var enderecoMap = UnitOfWork.EnderecoRepository.GetAllByClienteId(id).FirstOrDefault();
            clienteMap.Endereco = TinyMapper.Map<EnderecoDTO.Retorno>(enderecoMap);
            return clienteMap;
        }

        public List<ClienteDTO.Retorno> GetAll()
        {
            var clientes = UnitOfWork.ClienteRepository.GetAll().ToList();
            return TinyMapper.Map<List<ClienteDTO.Retorno>>(clientes);
        }

        private Cliente GetCliente(Guid id)
            => UnitOfWork.ClienteRepository.GetById(id)
                ?? throw new Exception("Cliente não encontrado!");

        private bool CriarCliente(ClienteDTO.Gravar dto)
        {
            var cliente = new Cliente(dto.Nome, dto.Sobrenome, dto.DataNascimento,
                GetCompatibilidadeSexo(dto.TipoSexo), dto.Email, dto.Telefone);
            SetEnderecoCliente(dto.Endereco, cliente);
            UnitOfWork.ClienteRepository.Add(cliente);
            return UnitOfWork.SaveChanges();
        }

        private TipoSexo GetCompatibilidadeSexo(string tipoSexo)
            => TipoSexo.Masculino.ToString().Equals(tipoSexo)
                ? TipoSexo.Masculino
                : TipoSexo.Feminino.ToString().Equals(tipoSexo)
                    ? TipoSexo.Feminino
                    : TipoSexo.Outro;

        private void SetEnderecoCliente(EnderecoDTO.Dados endereco, Cliente cliente)
        {
            cliente.AdicionarEndereco(new Endereco(
                cliente.Id,
                endereco.Logradouro,
                endereco.Numero,
                endereco.Complemento,
                endereco.Bairro,
                endereco.CEP,
                endereco.Localidade,
                endereco.Uf));
        }

        private bool EditarCliente(Cliente cliente, ClienteDTO.Gravar dto)
        {
            var endereco = UnitOfWork.EnderecoRepository.GetAllByClienteId(dto.Id).FirstOrDefault();
            cliente.AdicionarEndereco(endereco);
            UnitOfWork.ClienteRepository.Update(cliente);
            return UnitOfWork.SaveChanges();
        }

        private void MapDatas()
        {
            TinyMapper.Bind<Cliente, ClienteDTO.Retorno>();
            TinyMapper.Bind<Endereco, EnderecoDTO.Retorno>();
            TinyMapper.Bind<EnderecoDTO.Retorno, Endereco>();
        }

    }
}
