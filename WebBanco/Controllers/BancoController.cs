using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebBanco.Models;
using WebBanco.DAO;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebBanco.Controllers
{
    public class BancoController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            BancoDao oBancoDao = new BancoDao();
            List<Banco> listaBancos = oBancoDao.Listar();

            return View(listaBancos);
        }

        [HttpGet]
        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Banco banco)
        {
            BancoDao oBancoDao = new BancoDao();
            oBancoDao.insertar(banco);
            ViewBag.mensajeExito = "Banco " + banco.Nombre + " fue registrado con exito";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            BancoDao oBancoDao = new BancoDao();
            Banco banco = oBancoDao.Obtener(id);
            return View(banco);
        }

        [HttpPost]
        public ActionResult Edit(Banco banco)
        {
            BancoDao oBancoDao = new BancoDao();
            oBancoDao.actualizar(banco);
            ViewBag.mensajeExito = "Banco " + banco.Nombre + " fue actualizado con exito";
            return View(banco);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            BancoDao oBancoDao = new BancoDao();
            oBancoDao.eliminar(id);

            List<Banco> listaBancos = oBancoDao.Listar();
            return RedirectToAction("Index");
        }
    }
}
