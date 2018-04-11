using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Loja.Dominio;
using Loja.Mvc.Models;
using Loja.Repositorios.SqlServer.EF.CodeFirst;

namespace Loja.Mvc.Controllers
{
    public class ProdutosController : Controller
    {
        private LojaDbContext db = new LojaDbContext();

        // GET: Produtos
        public ActionResult Index()
        {
            return View(Mapear(db.Produtos.ToList()));
        }

        private List<ProdutoViewModel> Mapear(List<Produto> produtos)
        {
            var produtosViewModel = new List<ProdutoViewModel>();

            foreach (var produto in produtos)
            {
                produtosViewModel.Add(Mapear(produto));
            }

            return produtosViewModel;
        }

        private ProdutoViewModel Mapear(Produto produto)
        {
            var viewModel = new ProdutoViewModel();

            viewModel.Ativo = produto.Ativo;
            viewModel.CategoriaId = produto.Categoria?.Id;
            viewModel.CategoriaNome = produto.Categoria?.Nome;
            viewModel.Categorias = Mapear(db.Categorias.ToList());
            viewModel.Id = produto.Id;
            viewModel.Nome = produto.Nome;
            viewModel.Preco = produto.Preco;
            viewModel.QuantidadeEstoque = produto.QuantidadeEstoque;

            return viewModel;
        }

        private List<SelectListItem> Mapear(List<Categoria> categorias)
        {
            return categorias.Select(c => new SelectListItem { Text = c.Nome, Value = c.Id.ToString() }).ToList();
        }

        // GET: Produtos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var produto = db.Produtos.Find(id);

            if (produto == null)
            {
                return HttpNotFound();
            }

            return View(Mapear(produto));
        }

        // GET: Produtos/Create
        public ActionResult Create()
        {
            return View(Mapear(new Produto()));
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProdutoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var produto = Mapear(viewModel);

                db.Produtos.Add(produto);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        private Produto Mapear(ProdutoViewModel viewModel)
        {
            var produto = new Produto();

            produto.Ativo = viewModel.Ativo;
            produto.Categoria = db.Categorias.Find(viewModel.CategoriaId);
            produto.Id = viewModel.Id;
            produto.Nome = viewModel.Nome;
            produto.Preco = viewModel.Preco;
            produto.QuantidadeEstoque = viewModel.QuantidadeEstoque;            

            return produto;
        }

        // GET: Produtos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var produto = db.Produtos.Find(id);

            if (produto == null)
            {
                return HttpNotFound();
            }

            return View(Mapear(produto));
        }

        // POST: Produtos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProdutoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var produto = db.Produtos.Find(viewModel.Id);

                Mapear(viewModel, produto);

                db.Entry(produto).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        private void Mapear(ProdutoViewModel viewModel, Produto produto)
        {
            db.Entry(produto).CurrentValues.SetValues(viewModel);

            produto.Categoria = db.Categorias.Find(viewModel.CategoriaId);
        }

        // GET: Produtos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var produto = db.Produtos.Find(id);

            if (produto == null)
            {
                return HttpNotFound();
            }

            return View(Mapear(produto));
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produto produto = db.Produtos.Find(id);
            db.Produtos.Remove(produto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
