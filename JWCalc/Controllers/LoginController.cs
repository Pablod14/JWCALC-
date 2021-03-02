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

        public void CadUsuario(USUARIOS usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.USUULTLOGIN = System.DateTime.Now;
                new DAL_Usuarios().AdicionarRegistro(usuario);
            }

            RedirectToAction("Index", "Home");
        }
    }
}