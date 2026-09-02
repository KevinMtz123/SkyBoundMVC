using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapaPresentacionrAdmin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Usuarios()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ListarUsuario()
        {
            List<Usuario> oLista = new List<Usuario>();

            oLista = new CN_Usuarios().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]               //metodo con los metodos de guardar y editar usuario
        public JsonResult GuardarUsuario(Usuario objeto)
        {
            object resultado;//almacena el resultado esta variable
            string mensaje = string.Empty;

            if (objeto.IdUsuario == 0) //si no hay ningun id con ese tipo procedemos a registrar
            {
                resultado = new CN_Usuarios().Registrar(objeto, out mensaje);

            }
            else //en caso que exista este id procedemos a editar
            {
                resultado = new CN_Usuarios().Editar(objeto, out mensaje);
            }
            //devolvemos la lgica obtenida
            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult EliminarUsuario(int id)
        {

            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_Usuarios().Eliminar(id, out mensaje);
            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }
    }
}