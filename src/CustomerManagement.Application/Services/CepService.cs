﻿using CustomerManagement.Application.DTOs;
using CustomerManagement.Application.Interfaces;
using CustomerManagement.Infrastructure.CrossCuting.Extensions;
using System.Net.Http;
using System.Threading.Tasks;

namespace CustomerManagement.Application.Services
{
    public class CepService : ICepService
    {
        private readonly HttpClient _httpClient;
        private string _uri => "https://viacep.com.br/ws/{0}/json/";

        public CepService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<CepDTO.Retorno> ObterCep(CepDTO.Envio dto)
        {
            var response = await _httpClient.GetAsync(string.Format(_uri, dto.Cep));
            var retornoJson = response.Content.ReadAsStringAsync().Result;
            var endereco = JsonExtensions.Deserialize<CepDTO.Retorno>(retornoJson);
            return endereco;
        }
    }
}
