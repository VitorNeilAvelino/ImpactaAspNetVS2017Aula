using Loja.Mvc.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Loja.Mvc.Controllers
{
    public class ClientesController : Controller
    {
        public ActionResult Index()
        {
            return View(new List<ClienteViewModel>());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ClienteViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            return RedirectToAction("Index");
        }

        public ActionResult VerificarDisponibilidadeEmail(string email)
        {
            return Json(email != "avelino.vitor@gmail.com");
        }
    }
}