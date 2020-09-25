using CustomerManagement.Application.DTOs;
using System;
using System.Collections.Generic;

namespace CustomerManagement.Application.Interfaces
{
    public interface IClienteService
    {
        ClienteDTO.GravarRetorno Criar(ClienteDTO.Gravar dto);
        void Atualizar(ClienteDTO.Gravar dto);
        void Exlcuir(ClienteDTO.Excluir dto);
        ClienteDTO.Retorno GetById(Guid id);
        List<ClienteDTO.Retorno> GetAll();
        bool IsClienteExists(Guid id);
    }
}