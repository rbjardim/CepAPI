using CepAPI.Interface.Repository;
using CepAPI.Interface.Service;
using CepAPI.Model;
using Microsoft.AspNetCore.Identity;

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
