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
    public class SucursalController : Controller
    {


        private void cargarCombos()
        {
            BancoDao oBancoDao = new BancoDao();
            List<Banco> listaBancos = oBancoDao.Listar();

            ViewBag.ListaBancos = oBancoDao.Listar().Select(s => new
            {
                id = s.Id,
                Nombre = s.Nombre
            });

        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            SucursalDao oSucursalDao = new SucursalDao();
            List<Sucursal> lista = oSucursalDao.Listar();

            return View(lista);
        }

        [HttpGet]
        public ActionResult Create()
        {
            cargarCombos();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Sucursal suc)
        {
            SucursalDao oSucursalDao = new SucursalDao();
            oSucursalDao.insertar(suc);           
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            SucursalDao oSucursalDao = new SucursalDao();
            Sucursal sucursal = oSucursalDao.Obtener(id);
            cargarCombos();
            return View(sucursal);
        }

        [HttpPost]
        public ActionResult Edit(Sucursal suc)
        {
            SucursalDao oSucursalDao = new SucursalDao();
            oSucursalDao.actualizar(suc);
            cargarCombos();
            ViewBag.mensajeExito = "Sucursal " + suc.Nombre + " fue actualizado con exito";
            return View(suc);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            SucursalDao oSucursalDao = new SucursalDao();
            oSucursalDao.eliminar(id);

            List<Sucursal> listaBancos = oSucursalDao.Listar();
            return RedirectToAction("Index");
        }


        
    }
}
