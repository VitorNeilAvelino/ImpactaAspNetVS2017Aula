using Empresa.Mvc.Models;
using Empresa.Repositorios.SqlServer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Empresa.Mvc.Controllers
{
    public class LoginController : BaseController
    {
        public LoginController(EmpresaDbContext context, IDataProtectionProvider protectionProvider,
            IConfiguration configuration) : base(context, protectionProvider, configuration)
        {

        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var contato = _context.Contatos.SingleOrDefault(c => c.Email == viewModel.Email &&
                _protectorProvider.Unprotect(c.Senha) == viewModel.Senha);

            if (contato == null)
            {
                ModelState.AddModelError(string.Empty, "Email/Senha não encontrados.");

                return View(viewModel);
            }

            // 1. Install-Package Microsoft.AspNetCore.Authentication.Cookies
            // 2. Startup.Configure
            // 3. Configurar as permissões abaixo

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, contato.Nome),
                new Claim(ClaimTypes.Email, contato.Email),

                new Claim(ClaimTypes.Role, "Admin"),
                new Claim(ClaimTypes.Role, "Consultor"),
                new Claim(ClaimTypes.Role, "Contabil"),

                new Claim("Contato", "Excluir")
                // Citar as policies em Startup.ConfigureServices
            };

            var identidade = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identidade);

            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return RedirectToAction("Index", "Contatos");
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Contatos");
        }
    }
}