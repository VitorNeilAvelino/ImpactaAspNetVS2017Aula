using System.Linq;
using System.Security.Claims;
using System.Security.Principal;

namespace Loja.Mvc.Helpers
{
    public static class IdentityHelper
    {
        public static bool HasClaim(this IPrincipal user, string tipo, string valor)
        {
            return ((ClaimsIdentity)user.Identity).FindAll(c => c.Type == tipo && c.Value == valor).Any();
        }
    }
}