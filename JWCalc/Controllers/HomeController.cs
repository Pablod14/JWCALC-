using Negocios.EntityFramework;
using Negocios.Regras;
using System.Web.Mvc;

namespace JWCalc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            TIPODONATIVO tpDonativo = new TIPODONATIVO { TIPCOD = 1, TIPDESC = "Teste", TIPID = 1 };

            DONATIVO donativoModelo = new DONATIVO() { DONID = 0, DONTIPO = 1, DONVALOR = 500, TIPODONATIVO = tpDonativo };
            DAL_Donativos donativos = new DAL_Donativos();
            donativos.AdicionarRegistro(donativoModelo);

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult IncluirRecibo()
        {
            return View();
        }
    }
}