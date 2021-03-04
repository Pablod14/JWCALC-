using JWCalc.Models;
using Negocios.DAL;
using Negocios.EntityFramework.DML.ACESSOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JWCalc.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CadastrarUsuario()
        {
            return View();
        }

        public ActionResult UsuarioExistente(string UsuarioCadastro)
        {
            return Json(new DAL_Usuarios().VerificaUsuarioExistente(UsuarioCadastro), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult CadastrarNovoUsuario(UsuarioCadastro UsuarioCadastro)
        {
            USUARIOS usuario = new USUARIOS
            {
                USUID = 0,
                USUNOME = UsuarioCadastro.NOME,
                USUSENHA = UsuarioCadastro.SENHA,
                USUULTLOGIN = DateTime.Now
            };

            new DAL_Usuarios().AdicionarRegistro(usuario);

            return View("CadastrarUsuario");
        }
    }
}