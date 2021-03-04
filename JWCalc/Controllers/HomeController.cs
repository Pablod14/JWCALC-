using Negocios.EntityFramework.DML.JWCALC;
using Negocios.Regras;
using System.Web.Mvc;

namespace JWCalc.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DonativoVM()
        {
            return View();
        }

        public ActionResult TipoRecibosVM()
        {
            return View(new DAL_TipoRecibos().ConsultarRegistros());
        }

        public ActionResult CadTipoRecibosVM()
        {
            return View();
        }

        [HttpPost]
        public void CadastrarTipoRecibo(TIPORECIBO pTipoRecibo)
        {
            new DAL_TipoRecibos().AdicionarRegistro(pTipoRecibo);
        }
    }
}