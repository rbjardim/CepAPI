using CepAPI.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace CepAPI.MySqlContext
{
    public class Context : IdentityDbContext<AplicationUser>
    {
        public Context(DbContextOptions<Context> options) : base(options)
        { }
            public DbSet<Localizacao> localizacao { get; set; }
        }
    }

