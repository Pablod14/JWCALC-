using Negocios.EntityFramework.DML.JWCALC;
using System.Web.Mvc;

namespace JWCalc.Areas.Donativos.Controllers
{
    public class DonativosController : Controller
    {
        // GET: Donativos
        public ActionResult Index()
        {
            return View("IncluirDonativo");
        }    

        [HttpPost]
        public ActionResult IncluirNovoDonativo(DONATIVO donativo)
        {
            ModelState.Clear();
            return View("IncluirDonativo");
        }

    }
}
