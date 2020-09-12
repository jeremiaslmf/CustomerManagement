using CustomerManagement.Application.DTOs;
using CustomerManagement.Domain.Entities;
using Nelibur.ObjectMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagement.Application.Mappings
{
    public class TinyMappings
    {
        public static void Configure()
        {
            TinyMapper.Bind<ClienteDTO.Gravar, Cliente>();
            TinyMapper.Bind<Cliente, ClienteDTO.ObterPorId>();
            TinyMapper.Bind<Cliente, ClienteDTO.Retorno>();
            TinyMapper.Bind<Endereco, EnderecoDTO>();
            TinyMapper.Bind<EnderecoDTO, Endereco>();
        }
    }
}
