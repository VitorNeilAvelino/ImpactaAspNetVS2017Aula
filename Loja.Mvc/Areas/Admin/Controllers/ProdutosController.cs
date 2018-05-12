using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Loja.Dominio;
using Loja.Mvc.Areas.Admin.Models;
using Loja.Repositorios.SqlServer.EFCodeFirst;

namespace Loja.Mvc.Areas.Admin.Controllers
{
    [Authorize]
    public class ProdutosController : Controller
    {
        private LojaDbContext db = new LojaDbContext();

        [AllowAnonymous]
        public ActionResult Index()
        {
            //throw new Exception("Teste");
            return View(Mapear(db.Produtos.ToList()));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="produtos"></param>
        /// <returns></returns>
        private List<ProdutoViewModel> Mapear(List<Produto> produtos)
        {
            var viewModel = new List<ProdutoViewModel>();

            foreach (var produto in produtos)
            {
                viewModel.Add(Mapear(produto));
            }

            return viewModel;
        }

        private ProdutoViewModel Mapear(Produto produto)
        {
            var viewModel = new ProdutoViewModel();

            viewModel.Ativo = produto.Ativo;
            viewModel.Estoque = produto.Estoque;
            viewModel.Id = produto.Id;
            viewModel.Nome = produto.Nome;
            viewModel.Preco = produto.Preco;

            viewModel.CategoriaId = produto.Categoria?.Id;
            viewModel.CategoriaNome = produto.Categoria?.Nome;
            viewModel.Categorias = Mapear(db.Categorias.ToList());

            return viewModel;
        }

        private List<SelectListItem> Mapear(List<Categoria> categorias)
        {
            return categorias.Select(c =>
                new SelectListItem { Text = c.Nome, Value = c.Id.ToString() }).ToList();
        }

        [AllowAnonymous]
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
            ViewBag.Titulo = "Novo Produto";

            return View("~/Areas/Admin/Views/Produtos/CreateOrEdit.cshtml", Mapear(new Produto()));
        }

        // POST: Produtos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProdutoViewModel viewModel)
        //public ActionResult Create(int id, string nome, decimal preco)
        //public ActionResult Create(FormCollection formulario)
        {
            //var nome = formulario["nome"];

            if (ModelState.IsValid)
            {
                var produto = Mapear(viewModel);

                db.Produtos.Add(produto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("~/Areas/Admin/Views/Produtos/CreateOrEdit.cshtml", viewModel);
        }

        private Produto Mapear(ProdutoViewModel viewModel)
        {
            var produto = new Produto();

            produto.Categoria = db.Categorias.Find(viewModel.CategoriaId);
            produto.Ativo = viewModel.Ativo;
            produto.Estoque = viewModel.Estoque;
            produto.Id = viewModel.Id;
            produto.Nome = viewModel.Nome;
            produto.Preco = viewModel.Preco;

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

            return View("~/Areas/Admin/Views/Produtos/CreateOrEdit.cshtml", Mapear(produto));
        }

        // POST: Produtos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
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

            return View("~/Areas/Admin/Views/Produtos/CreateOrEdit.cshtml", viewModel);
        }

        private void Mapear(ProdutoViewModel viewModel, Produto produto)
        {
            db.Entry(produto).CurrentValues.SetValues(viewModel);

            produto.Categoria = db.Categorias.Find(viewModel.CategoriaId);
        }

        //[Authorize(Roles = "Chefe")]
        [Authorize(Roles = "Admin, Gerente")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(Mapear(produto));
        }

        [Authorize(Roles = "Admin, Gerente")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produto produto = db.Produtos.Find(id);
            db.Produtos.Remove(produto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [ActionName("Categoria")]
        public JsonResult ObterProdutoPorCategoria(int? categoriaId)
        {
            return Json(db.Produtos
                .Where(p => p.Categoria.Id == categoriaId)
                .ToList(), JsonRequestBehavior.AllowGet);
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
