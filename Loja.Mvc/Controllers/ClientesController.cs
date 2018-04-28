using Loja.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Loja.Mvc.Controllers
{
    public class ClientesController : Controller
    {
        // GET: Clientes
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
                    return View(viewModel);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View(viewModel);
            }
        }

        public ActionResult VerificarDisponibilidadeEmail(string email)
        {
            return Json(email != "avelino.vitor@gmail.com");
        }
    }
}