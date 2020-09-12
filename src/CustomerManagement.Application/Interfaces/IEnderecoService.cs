using CustomerManagement.Application.DTOs;
using System;
using System.Collections.Generic;

namespace CustomerManagement.Application.Interfaces
{
    public interface IEnderecoService
    {
        bool Gravar(EnderecoDTO.Gravar dto);
        void Exlcuir(EnderecoDTO.Excluir dto);
        EnderecoDTO.Retorno GetById(Guid id);
        EnderecoDTO.Retorno GetByClienteId(Guid id);
        List<EnderecoDTO.Retorno> GetAllByClienteId(Guid id);
    }
}
