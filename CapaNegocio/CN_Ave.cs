using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Ave
    {
        private CD_Ave objCapaDato = new CD_Ave();

        public List<Ave> Listar()
        {
            return objCapaDato.Listar();
        }

        public int Registrar(Ave obj, out string Mensaje)
        {

            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Nombre))
            {
                Mensaje = "No puede quedar vacio el nombre del Ave";

            }
            else if (string.IsNullOrEmpty(obj.Descripcion) || string.IsNullOrWhiteSpace(obj.Descripcion))
            {
                Mensaje = "La Descripcion del ave no puede quedar vacia";

            }
            else if (obj.oFamilia.IdFamilia == 0)
            {
                Mensaje = "Debe seleccionar su familia";

            }
            else if (obj.oCategoriaEstacional.IdCategoria == 0)
            {
                Mensaje = "Debe seleccionar una categoria";

            }
            else if (obj.oEstatusProteccion.IdEstatus == 0)
            {
                Mensaje = "Debe seleccionar el estatus";

            }
            else if (obj.oHabitat.IdHabitat == 0)
            {
                Mensaje = "Debe seleccionar el habitat";

            }
            else if (string.IsNullOrEmpty(obj.Alimentacion) || string.IsNullOrWhiteSpace(obj.Alimentacion))
            {
                Mensaje = "La alimentacion del ave no puede quedar vacia";

            }
            else if (string.IsNullOrEmpty(obj.FuncionEcos) || string.IsNullOrWhiteSpace(obj.FuncionEcos))
            {
                Mensaje = "La funcion del ave no puede quedar vacia";

            }


            if (string.IsNullOrEmpty(Mensaje))
            {

                return objCapaDato.Registrar(obj, out Mensaje);


            }
            else
            {
                return 0;
            }

        }

        public bool Editar(Ave obj, out string Mensaje)
        {

            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Nombre))
            {
                Mensaje = "No puede quedar vacio el nombre del Ave";

            }
            else if (string.IsNullOrEmpty(obj.Descripcion) || string.IsNullOrWhiteSpace(obj.Descripcion))
            {
                Mensaje = "La Descripcion del ave no puede quedar vacia";

            }
            else if (obj.oFamilia.IdFamilia == 0)
            {
                Mensaje = "Debe seleccionar su familia";

            }
            else if (obj.oCategoriaEstacional.IdCategoria == 0)
            {
                Mensaje = "Debe seleccionar una categoria";

            }
            else if (obj.oEstatusProteccion.IdEstatus == 0)
            {
                Mensaje = "Debe seleccionar el estatus";

            }
            else if (obj.oHabitat.IdHabitat == 0)
            {
                Mensaje = "Debe seleccionar el habitat";

            }
            else if (string.IsNullOrEmpty(obj.Alimentacion) || string.IsNullOrWhiteSpace(obj.Alimentacion))
            {
                Mensaje = "La alimentacion del ave no puede quedar vacia";

            }
            else if (string.IsNullOrEmpty(obj.FuncionEcos) || string.IsNullOrWhiteSpace(obj.FuncionEcos))
            {
                Mensaje = "La funcion del ave no puede quedar vacia";

            }



            if (string.IsNullOrEmpty(Mensaje))
            {

                return objCapaDato.Editar(obj, out Mensaje);


            }
            else
            {
                return false;
            }

        }

        public bool GuardarDatosImagen(Ave obj, out string Mensaje)
        {
            return objCapaDato.GuardarDatosImagen(obj, out Mensaje);
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return objCapaDato.Eliminar(id, out Mensaje);

        }
    }
}
