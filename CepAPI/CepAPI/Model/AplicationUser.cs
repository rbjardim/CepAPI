using Microsoft.AspNetCore.Identity;

namespace CepAPI.Model
{
    public class AplicationUser : IdentityUser
    {
        public string Nome { get; set;} 
    
    }
}
