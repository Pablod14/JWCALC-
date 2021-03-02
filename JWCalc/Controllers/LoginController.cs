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
            new DAL_Usuarios().AdicionarRegistro(usuario);
        }
    }
}