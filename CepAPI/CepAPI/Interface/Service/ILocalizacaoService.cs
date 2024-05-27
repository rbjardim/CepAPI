using CepAPI.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CepAPI.Interface.Service
{
    public interface ILocalizacaoService
    {
        Task<bool> CreateLocalizacao(Localizacao localizacao);
        Task<bool> DeleteLocalAsync(int Idlocal);
        Task<Localizacao> GetLocalizacaoById(int id);
        Task<List<Localizacao>> ListLocal();
        Task<int> UpdateLocalizacao(Localizacao localizacao);
        Task<Endereco> BuscarEnderecoPorCEP(string cep);
    }
}
