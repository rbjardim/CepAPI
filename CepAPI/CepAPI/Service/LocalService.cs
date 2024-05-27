using CepAPI.Interface.Repository;
using CepAPI.Interface.Service;
using CepAPI.Model;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CepAPI.Service
{
    public class LocalService : ILocalizacaoService
    {
        private readonly ILocalizacaoRepository _localizacaoRepository;
        private readonly UserManager<AplicationUser> _userManager;

        public LocalService(ILocalizacaoRepository localizacaoRepository, UserManager<AplicationUser> userManager)
        {
            _localizacaoRepository = localizacaoRepository;
            _userManager = userManager;
        }

        // Método para buscar dados de endereço com base no CEP usando a API ViaCEP
        public async Task<Endereco> BuscarEnderecoPorCEP(string cep)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json/");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var endereco = JsonSerializer.Deserialize<Endereco>(content);
                    return endereco;
                }
                else
                {
                    // Tratar o caso de falha na solicitação para a API ViaCEP
                    return null;
                }
            }
        }

        public async Task<bool> CreateLocalizacao(Localizacao localizacao)
        {
            var local = new Localizacao();

            var result = await _localizacaoRepository.CreateLocalizacao(localizacao);
            return true;
        }

        public async Task<bool> DeleteLocalAsync(int Idlocal)
        {

            await _localizacaoRepository.DeleteLocalAsync(Idlocal);
            return true;
        }

        public async Task<Localizacao> GetLocalizacaoById(int id)
        {
            return await _localizacaoRepository.GetLocalizacaoById(id);
        }

        public async Task<List<Localizacao>> ListLocal()
        {
            var local = await _localizacaoRepository.ListLocal();

            return local;
        }

        public async Task<int> UpdateLocalizacao(Localizacao localizacao)
        {
            var local = new Localizacao();

            return await _localizacaoRepository.UpdateLocalizacao(localizacao);
        }
    }
}
