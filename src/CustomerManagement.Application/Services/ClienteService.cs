using CustomerManagement.Application.DTOs;
using CustomerManagement.Application.Interfaces;
using CustomerManagement.Domain.Entities;
using CustomerManagement.Domain.Enums;
using CustomerManagement.Domain.Interfaces;
using Nelibur.ObjectMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Services
{
    public class ClienteService : GenericService, IClienteService
    {
        public ClienteService(IUnitOfWork iuow) : base(iuow) { }

        public async Task<ClienteDTO.GravarRetorno> Criar(ClienteDTO.Gravar dto)
        {
            var cliente = new Cliente(dto.Nome, dto.Sobrenome, dto.DataNascimento,
                GetCompatibilidadeSexo(dto.TipoSexo), dto.Email, dto.Telefone);
            SetEnderecoCliente(dto.Endereco, cliente);
            UnitOfWork.ClienteRepository.Add(cliente);
            await UnitOfWork.SaveChangesAsync();
            return new ClienteDTO.GravarRetorno(cliente.Id);
        }

        public async Task Atualizar(ClienteDTO.Gravar dto)
        {
            var cliente = UnitOfWork.ClienteRepository.GetById(dto.Id);
            var endereco = UnitOfWork.EnderecoRepository.GetAllByClienteId(dto.Id).FirstOrDefault();
            cliente.AdicionarEndereco(endereco);
            UnitOfWork.ClienteRepository.Update(cliente);
            await UnitOfWork.SaveChangesAsync();         
        }

        public async Task Exlcuir(ClienteDTO.Excluir dto)
        {
            var cliente = GetCliente(dto.Id);
            UnitOfWork.ClienteRepository.Delete(cliente);
            await UnitOfWork.SaveChangesAsync();
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

        public bool IsClienteExists(Guid id)
            => UnitOfWork.ClienteRepository.GetById(id) != null;

        private Cliente GetCliente(Guid id)
            => UnitOfWork.ClienteRepository.GetById(id)
                ?? throw new Exception("Cliente não encontrado!");

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

        private void MapDatas()
        {
            TinyMapper.Bind<Cliente, ClienteDTO.Retorno>();
            TinyMapper.Bind<Endereco, EnderecoDTO.Retorno>();
            TinyMapper.Bind<EnderecoDTO.Retorno, Endereco>();
        }
    }
}
