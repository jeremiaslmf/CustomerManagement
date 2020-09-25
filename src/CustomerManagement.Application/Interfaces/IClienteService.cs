using CustomerManagement.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Interfaces
{
    public interface IClienteService
    {
        Task<ClienteDTO.GravarRetorno> Criar(ClienteDTO.Gravar dto);
        Task Atualizar(ClienteDTO.Gravar dto);
        Task Exlcuir(ClienteDTO.Excluir dto);
        ClienteDTO.Retorno GetById(Guid id);
        List<ClienteDTO.Retorno> GetAll();
        bool IsClienteExists(Guid id);
    }
}