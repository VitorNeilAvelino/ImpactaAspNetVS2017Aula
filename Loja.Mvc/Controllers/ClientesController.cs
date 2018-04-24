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
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult VerificarDisponibilidadeEmail(string email)
        {
            return Json(email != "avelino.vitor@gmail.com");
        }
    }
}