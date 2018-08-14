using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViagensOnline.Repositorios.SqlServer;

namespace ViagensOnline.Mvc.Controllers
{
    public class DestinosController : Controller
    {
        private ViagensOnlineDbContext _db = new ViagensOnlineDbContext();
        // GET: Destinos
        public ActionResult Index()
        {
            return View(_db.Destinos.ToList());
        }
    }
}