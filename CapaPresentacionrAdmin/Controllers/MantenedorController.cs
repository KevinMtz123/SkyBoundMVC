using CapaEntidad;
using CapaNegocio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapaPresentacionrAdmin.Controllers
{
    public class MantenedorController : Controller
    {
        // GET: Mantenedor
        public ActionResult EstatusProteccion()
        {
            return View();
        }

        public ActionResult CategoriaEstacional()
        {
            return View();
        }
        public ActionResult Familia()
        {
            return View();
        }
        public ActionResult Habitat()
        {
            return View();
        }
        public ActionResult Ave()
        {
            return View();
        }

        #region Estatus de Proteccion
        //******************************************************Estatus************************************************************************

        [HttpGet]
        public JsonResult ListarEstatus()
        {
            List<EstatusProteccion> oLista = new List<EstatusProteccion>();

            oLista = new CN_Estatus().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult GuardarEstatus(EstatusProteccion objeto)
        {
            object resultado;//almacena el resultado esta variable
            string mensaje = string.Empty;

            if (objeto.IdEstatus == 0) //si no hay ningun id con ese tipo procedemos a registrar
            {
                resultado = new CN_Estatus().Registrar(objeto, out mensaje);

            }
            else //en caso que exista este id procedemos a editar
            {
                resultado = new CN_Estatus().Editar(objeto, out mensaje);
            }
            //devolvemos la lgica obtenida
            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult EliminarEstatus(int id)
        {

            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_Estatus().Eliminar(id, out mensaje);
            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }

        #endregion

        #region Categoria Estacional
        //******************************************************Categoria Estacional************************************************************************

        [HttpGet]
        public JsonResult ListarCategoria()
        {
            List<CategoriaEstacional> oLista = new List<CategoriaEstacional>();

            oLista = new CN_Categoria().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult GuardarCategoria(CategoriaEstacional objeto)
        {
            object resultado;//almacena el resultado esta variable
            string mensaje = string.Empty;

            if (objeto.IdCategoria == 0) //si no hay ningun id con ese tipo procedemos a registrar
            {
                resultado = new CN_Categoria().Registrar(objeto, out mensaje);

            }
            else //en caso que exista este id procedemos a editar
            {
                resultado = new CN_Categoria().Editar(objeto, out mensaje);
            }
            //devolvemos la lgica obtenida
            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult EliminarCategoria(int id)
        {

            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_Categoria().Eliminar(id, out mensaje);
            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }

        #endregion

        #region Familia
        //******************************************************Familia************************************************************************

        [HttpGet]
        public JsonResult ListarFamilia()
        {
            List<Familia> oLista = new List<Familia>();

            oLista = new CN_Familia().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult GuardarFamilia(Familia objeto)
        {
            object resultado;//almacena el resultado esta variable
            string mensaje = string.Empty;

            if (objeto.IdFamilia == 0) //si no hay ningun id con ese tipo procedemos a registrar
            {
                resultado = new CN_Familia().Registrar(objeto, out mensaje);

            }
            else //en caso que exista este id procedemos a editar
            {
                resultado = new CN_Familia().Editar(objeto, out mensaje);
            }
            //devolvemos la lgica obtenida
            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult EliminarFamilia(int id)
        {

            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_Familia().Eliminar(id, out mensaje);
            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }

        #endregion

        #region Habitat
        //******************************************************Habitat************************************************************************

        [HttpGet]
        public JsonResult ListarHabitat()
        {
            List<Habitat> oLista = new List<Habitat>();

            oLista = new CN_Habitat().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult GuardarHabitat(Habitat objeto)
        {
            object resultado;//almacena el resultado esta variable
            string mensaje = string.Empty;

            if (objeto.IdHabitat == 0) //si no hay ningun id con ese tipo procedemos a registrar
            {
                resultado = new CN_Habitat().Registrar(objeto, out mensaje);

            }
            else //en caso que exista este id procedemos a editar
            {
                resultado = new CN_Habitat().Editar(objeto, out mensaje);
            }
            //devolvemos la lgica obtenida
            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult EliminarHabitat(int id)
        {

            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_Habitat().Eliminar(id, out mensaje);
            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }

        #endregion

        #region AVES
        [HttpGet]
        public JsonResult ListarAve()
        {
            List<Ave> oLista = new List<Ave>();

            oLista = new CN_Ave().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult GuardarAve(string objeto, HttpPostedFileBase archivoImagen)
        {
            string mensaje = string.Empty;
            bool operacion_exitosa = true;
            bool guardar_imagen_exito = true;

            Ave oAve = new Ave();
            oAve = JsonConvert.DeserializeObject<Ave>(objeto);


            if (oAve.IdAve == 0) //si no hay ningun id con ese tipo procedemos a registrar
            {
                int idAveGenerado = new CN_Ave().Registrar(oAve, out mensaje);


                if (idAveGenerado != 0)
                {
                    oAve.IdAve = idAveGenerado;

                }
                else
                {
                    operacion_exitosa = false;
                }
            }
            else //en caso que exista este id procedemos a editar
            {
                operacion_exitosa = new CN_Ave().Editar(oAve, out mensaje);
            }

            if (operacion_exitosa)
            {
                if (archivoImagen != null)
                {
                    string ruta_guardar = ConfigurationManager.AppSettings["ServidorFotos"];
                    string extension = Path.GetExtension(archivoImagen.FileName);
                    string nombre_imagen = string.Concat(oAve.IdAve.ToString(), extension);


                    try
                    {
                        archivoImagen.SaveAs(Path.Combine(ruta_guardar, nombre_imagen));
                    }
                    catch (Exception ex)
                    {
                        string msg = ex.Message;
                        guardar_imagen_exito = false;
                    }
                    if (guardar_imagen_exito)
                    {
                        oAve.RutaImagen = ruta_guardar;
                        oAve.NombreImagen = nombre_imagen;
                        bool rspta = new CN_Ave().GuardarDatosImagen(oAve, out mensaje);
                    }
                    else
                    {
                        mensaje = "Se guardo el ave pero hubo problemas con la imagen";
                    }
                }
            }


            //devolvemos la logica obtenida
            return Json(new { operacionExitosa = operacion_exitosa, idGenerado = oAve.IdAve, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult ImagenAve(int id)
        {

            bool conversion;
            Ave oave = new CN_Ave().Listar().Where(a => a.IdAve == id).FirstOrDefault();

            string textoBase64 = CN_Recursos.ConvertirBase64(Path.Combine(oave.RutaImagen, oave.NombreImagen), out conversion);

            return Json(new
            {
                conversion = conversion,
                textobase64 = textoBase64,
                extension = Path.GetExtension(oave.NombreImagen)
            },
                JsonRequestBehavior.AllowGet
                );
        }


        [HttpPost]
        public JsonResult EliminarAve(int id)
        {

            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_Ave().Eliminar(id, out mensaje);
            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }

        #endregion
    }
}
