using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Empresa.Dominio;
using Empresa.Repositorios.SqlServer;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Configuration;

namespace Empresa.Mvc.Controllers
{
    public class ContatosController : BaseController
    {
        public ContatosController(EmpresaDbContext context, IDataProtectionProvider protectionProvider,
            IConfiguration configuration) : base(context, protectionProvider, configuration)
        {

        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Contatos.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contato = await _context.Contatos
                .SingleOrDefaultAsync(m => m.Id == id);
            if (contato == null)
            {
                return NotFound();
            }

            return View(contato);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Contato contato)
        {
            if (ModelState.IsValid)
            {
                contato.Senha = _protectorProvider.Protect(contato.Senha);

                _context.Add(contato);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contato);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contato = await _context.Contatos.SingleOrDefaultAsync(m => m.Id == id);

            if (contato == null)
            {
                return NotFound();
            }
            return View(contato);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Email,Assunto,Mensagem")] Contato viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var contato = _context.Contatos.Find(viewModel.Id);

                    _context.Entry(contato).CurrentValues.SetValues(viewModel);
                    _context.Entry(contato).Property(c => c.Senha).IsModified = false;
                    _context.Update(contato);

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContatoExists(viewModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contato = await _context.Contatos
                .SingleOrDefaultAsync(m => m.Id == id);
            if (contato == null)
            {
                return NotFound();
            }

            return View(contato);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contato = await _context.Contatos.SingleOrDefaultAsync(m => m.Id == id);
            _context.Contatos.Remove(contato);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContatoExists(int id)
        {
            return _context.Contatos.Any(e => e.Id == id);
        }
    }
}