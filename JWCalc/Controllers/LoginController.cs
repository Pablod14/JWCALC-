using Negocios.DAL;
using Negocios.EntityFramework.DML.ACESSOS;
using System.Web.Mvc;

namespace JWCalc.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ValidaLogin(USUARIOS usuario)
        {
            bool usuarioValido = false;

            if (ModelState.IsValid)
                usuarioValido = new DAL_Usuarios().ValidaUsuarioLogin(usuario);

            if (usuarioValido)
                return RedirectToAction("Index", "Home");
            else
                return View("Index");
        }
    }
}