using CepAPI.Interface.Repository;
using CepAPI.Model;
using CepAPI.MySqlContext;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CepAPI.Repository
{
    public class LocalizacaoRepository : ILocalizacaoRepository
    {
        private readonly Context _context;

        public LocalizacaoRepository(Context context)
        {
            _context = context;
        }

        public async Task<Localizacao> CreateLocalizacao(Localizacao localizacao)
        {
            var ret = await _context.Localizacao.AddAsync(localizacao);
            await _context.SaveChangesAsync();
            ret.State = EntityState.Detached;
            return ret.Entity;
        }

        public async Task<bool> DeleteLocalAsync(int Id)
        {
            var item = await _context.Localizacao.FindAsync(Id);
            if (item == null)
                return false;

            _context.Localizacao.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Localizacao>> ListLocal()
        {
            List<Localizacao> list = await _context.Localizacao.OrderBy(p => p.Id).ToListAsync();
            return list;
        }

        public async Task<int> UpdateLocalizacao(Localizacao user)
        {
            _context.Entry(user).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        public async Task<Localizacao> GetLocalizacaoById(int id)
        {
            return await _context.Localizacao.FirstOrDefaultAsync(l => l.Id == id);
        }
    }
}
