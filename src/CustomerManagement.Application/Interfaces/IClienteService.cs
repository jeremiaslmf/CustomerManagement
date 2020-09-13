using CustomerManagement.Application.DTOs;
using System;
using System.Collections.Generic;

namespace CustomerManagement.Application.Interfaces
{
    public interface IClienteService
    {
        bool Gravar(ClienteDTO.Gravar dto);
        void Exlcuir(ClienteDTO.Excluir dto);
        ClienteDTO.Retorno GetById(Guid id);
        List<ClienteDTO.Retorno> GetAll();
    }
}