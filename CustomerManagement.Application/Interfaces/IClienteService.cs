using CustomerManagement.Application.DTOs;
using System;

namespace CustomerManagement.Application.Interfaces
{
    public interface IClienteService
    {
        bool Gravar(ClienteDTO.Gravar dto);
        void Exlcuir(ClienteDTO.Excluir dto);
        ClienteDTO.Retorno ObterPorId(Guid id);
    }
}