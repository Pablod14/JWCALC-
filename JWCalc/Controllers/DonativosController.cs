using Negocios.EntityFramework;
using Negocios.Regras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JWCalc.Controllers
{
    public class DonativosController : Controller
    {
        // GET: Donativos
        public ActionResult Index()
        {
            //TIPODONATIVO tpDonativo = new TIPODONATIVO { TIPCOD = 1, TIPDESC = "Teste", TIPID = 1 };

            //DONATIVO donativoModelo = new DONATIVO() { DONID = 0, DONTIPO = 1, DONVALOR = 500, TIPODONATIVO = tpDonativo };
            //DAL_Donativos donativos = new DAL_Donativos();
            //donativos.AdicionarRegistro(donativoModelo);

            return View();
        }

        // GET: Donativos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Donativos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Donativos/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Donativos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Donativos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Donativos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Donativos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
