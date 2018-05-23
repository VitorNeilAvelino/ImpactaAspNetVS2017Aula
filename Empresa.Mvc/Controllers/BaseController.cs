using Empresa.Repositorios.SqlServer;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Empresa.Mvc.Controllers
{
    public class BaseController : Controller
    {
        protected readonly EmpresaDbContext _context;
        protected readonly IDataProtector _protectorProvider;
        protected IConfiguration _configuration;

        public BaseController(EmpresaDbContext context, IDataProtectionProvider protectionProvider,
            IConfiguration configuration)
        {
            _context = context;
            _protectorProvider = protectionProvider.CreateProtector(configuration.GetSection("ChaveCriptografia").Value);
            _configuration = configuration;
        }
    }
}