using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebBanco.Models;
using WebBanco.DAO;
using Microsoft.AspNetCore.Mvc.Rendering;


// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebBanco.Controllers
{
    public class OrdenPagoController : Controller
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


            //listarCombos();
            List<SelectListItem> nombreBancos = new List<SelectListItem>();
            List<Banco> bancos = oBancoDao.Listar().ToList();
            bancos.ForEach(x =>
            {
                nombreBancos.Add(new SelectListItem { Text = x.Nombre, Value = x.Id.ToString() });
            });
            ViewData["Bancos"] = nombreBancos;

            SucursalDao oSucursalDao = new SucursalDao();
            ViewBag.listaSucursal = oSucursalDao.Listar().Select(s => new
            {
                id = s.IdSucursal,
                Nombre = s.Nombre
            });

            ViewBag.ListaEstados = new[]
            {
                 new
                {
                    Id = "1",
                    Nombre = "Pagada"
                },
                new
                {
                    Id = "2",
                    Nombre = "Declinada"
                },
                new
                {
                    Id = "3",
                    Nombre = "Fallida"
                },
                new
                {
                    Id = "4",
                    Nombre = "Anulada"
                }
            };

        }


        // GET: /<controller>/
        public IActionResult Index()
        {
            OrdenPagoDao oOrdenPagoDao = new OrdenPagoDao();
            List<OrdenPago> lista = oOrdenPagoDao.Listar();
            return View(lista);
        }

        [HttpGet]
        public ActionResult Create()
        {
            cargarCombos();
            return View();
        }

        [HttpPost]
        public ActionResult GetSucursal(string idBanco)
        {
            int statId;
            ViewData["Bancos"] = ViewBag.ListaBancos;
            //listarCombos();
            List<SelectListItem> nombresSucursales = new List<SelectListItem>();
            if (!string.IsNullOrEmpty(idBanco))
            {
                statId = Convert.ToInt32(idBanco);
                SucursalDao oSucursalDao = new SucursalDao();
                List<Sucursal> sucursales = oSucursalDao.Listar().Where(x => x.IdBanco == statId).ToList();
                sucursales.ForEach(x =>
                {
                    nombresSucursales.Add(new SelectListItem { Text = x.Nombre, Value = x.IdSucursal.ToString() });
                });
            }
            //ViewBag.listaSucursal = nombresSucursales;
            ViewData["Sucursal"] = nombresSucursales;
            return Json(nombresSucursales);
        }

        [HttpPost]
        public ActionResult Create(OrdenPago op)
        {
            OrdenPagoDao oOrdenPagoDao = new OrdenPagoDao();
            oOrdenPagoDao.insertar(op);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            OrdenPagoDao oOrdenPagoDao = new OrdenPagoDao();
            OrdenPago op = oOrdenPagoDao.Obtener(id);
            cargarCombos();
            return View(op);
        }

        [HttpPost]
        public ActionResult Edit(OrdenPago op)
        {
            OrdenPagoDao oOrdenPagoDao = new OrdenPagoDao();
            oOrdenPagoDao.actualizar(op);
            cargarCombos();
            ViewBag.mensajeExito = "Orden de Pago fue actualizado con exito";
            return View(op);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            OrdenPagoDao oOrdenPagoDao = new OrdenPagoDao();
            oOrdenPagoDao.eliminar(id);

            List<OrdenPago> lista = oOrdenPagoDao.Listar();
            return RedirectToAction("Index");
        }












    }
}
