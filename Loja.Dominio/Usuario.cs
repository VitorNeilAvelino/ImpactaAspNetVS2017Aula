using Microsoft.AspNet.Identity.EntityFramework;

namespace Loja.Dominio
{
    public class Usuario : IdentityUser
    {
        public string Nome { get; set; }
    }
}
