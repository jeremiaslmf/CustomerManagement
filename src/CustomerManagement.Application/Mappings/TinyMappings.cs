using CustomerManagement.Application.DTOs;
using CustomerManagement.Domain.Entities;
using Nelibur.ObjectMapper;
using System.Collections.Generic;

namespace CustomerManagement.Application.Mappings
{
    public class TinyMappings
    {
        public static void Configure()
        {
            TinyMapper.Bind<ClienteDTO.Gravar, Cliente>();
            TinyMapper.Bind<Cliente, ClienteDTO.ObterPorId>();
            TinyMapper.Bind<Cliente, ClienteDTO.Retorno>();
            TinyMapper.Bind<ClienteDTO.Retorno, Cliente>();
            TinyMapper.Bind<List<ClienteDTO.Retorno>, List<Cliente>>();
            TinyMapper.Bind<List<Cliente>, List<ClienteDTO.Retorno>>();

            TinyMapper.Bind<Endereco, EnderecoDTO.Retorno>();
            TinyMapper.Bind<EnderecoDTO.Retorno, Endereco>();
            TinyMapper.Bind<EnderecoDTO.Dados, Endereco>();
            TinyMapper.Bind<List<EnderecoDTO.Retorno>, List<Endereco>>();
            TinyMapper.Bind<List<Endereco>, List<EnderecoDTO.Retorno>>();
        }
    }
}
