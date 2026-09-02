using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;


namespace CapaPresentacionClientee.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DetalleAve(int idave = 0)
        {
            Ave oAve = new Ave();
            bool conversion;

            oAve = new CN_Ave().Listar().Where(a => a.IdAve == idave).FirstOrDefault();

            if (oAve != null)
            {
                oAve.Base64 = CN_Recursos.ConvertirBase64(Path.Combine(oAve.RutaImagen, oAve.NombreImagen), out conversion);
                oAve.Extension = Path.GetExtension(oAve.NombreImagen);
            }

            return View(oAve);
        }

        [HttpGet]

        public JsonResult ListarEstatus()
        {
            List<EstatusProteccion> lista = new List<EstatusProteccion>();

            lista = new CN_Estatus().Listar();

            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);

        }
        [HttpGet]
        public JsonResult ListarCategoria()
        {
            List<CategoriaEstacional> lista = new List<CategoriaEstacional>();

            lista = new CN_Categoria().Listar();

            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);

        }


        [HttpGet]
        public JsonResult ListarFamilia()
        {
            List<Familia> lista = new List<Familia>();

            lista = new CN_Familia().Listar();

            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public JsonResult ListarHabitat()
        {
            List<Habitat> lista = new List<Habitat>();

            lista = new CN_Habitat().Listar();

            return Json(new { data = lista }, JsonRequestBehavior.AllowGet);

        }



        [HttpPost]
        public JsonResult ListarAve(int idestatus, int idcategoria, int idfamilia, int idhabitat)
        {
            List<Ave> lista = new List<Ave>();

            bool conversion;

            lista = new CN_Ave().Listar().Select(a => new Ave() {
                IdAve = a.IdAve,
                Nombre = a.Nombre,
                Descripcion = a.Descripcion,
                oEstatusProteccion = a.oEstatusProteccion,
                oCategoriaEstacional = a.oCategoriaEstacional,
                oFamilia = a.oFamilia,
                oHabitat = a.oHabitat,
                Alimentacion = a.Alimentacion,
                FuncionEcos = a.FuncionEcos,
                RutaImagen = a.RutaImagen,
                Base64 = CN_Recursos.ConvertirBase64(Path.Combine(a.RutaImagen, a.NombreImagen), out conversion),
                Extension = Path.GetExtension(a.NombreImagen),
                Activa = a.Activa,
                ListaRoja = a.ListaRoja

            }).Where(a =>
            a.oEstatusProteccion.IdEstatus == (idestatus == 0 ? a.oEstatusProteccion.IdEstatus : idestatus) &&
            a.oCategoriaEstacional.IdCategoria == (idcategoria == 0 ? a.oCategoriaEstacional.IdCategoria : idcategoria) &&
            a.oFamilia.IdFamilia == (idfamilia == 0 ? a.oFamilia.IdFamilia : idfamilia) &&
            a.oHabitat.IdHabitat == (idhabitat == 0 ? a.oHabitat.IdHabitat : idhabitat) &&
            a.Activa == true && a.ListaRoja == false
            ).ToList();

            var jsonresult = Json(new { data = lista }, JsonRequestBehavior.AllowGet);
            jsonresult.MaxJsonLength = int.MaxValue;
            return jsonresult;

        }

    }
}