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
        public Task<Localizacao> CreateLocalizacao(Localizacao localizacao)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteLocalAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Localizacao>> ListLocal()
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateLocalizacao(Localizacao local)
        {
            throw new NotImplementedException();
        }
    }
}
