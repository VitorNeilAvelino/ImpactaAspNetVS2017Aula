using Empresa.Mvc.Models;
using Empresa.Repositorios.SqlServer;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Linq;

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

            return RedirectToAction("Index", "Contatos");
        }
    }
}