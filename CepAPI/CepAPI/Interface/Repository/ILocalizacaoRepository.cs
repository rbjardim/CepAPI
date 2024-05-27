using System.Threading.Tasks;
using System.Collections.Generic;
using CepAPI.Model;

namespace CepAPI.Interface.Repository
{
    public interface ILocalizacaoRepository
    {
        Task<int> UpdateLocalizacao(Localizacao local);
        Task<bool> DeleteLocalAsync(int Id);
        Task<Localizacao> CreateLocalizacao(Localizacao localizacao);
        Task<List<Localizacao>> ListLocal();
        Task<Localizacao> GetLocalizacaoById(int id);
    }
}
