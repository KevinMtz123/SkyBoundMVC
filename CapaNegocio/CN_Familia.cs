using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Familia
    {
        private CD_Familia objCapaDato = new CD_Familia();

        public List<Familia> Listar()
        {
            return objCapaDato.Listar();
        }

        public int Registrar(Familia obj, out string Mensaje)
        {

            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Descripcion) || string.IsNullOrWhiteSpace(obj.Descripcion))
            {
                Mensaje = "La Descripcion no puede quedar vacia";

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

        public bool Editar(Familia obj, out string Mensaje)
        {

            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Descripcion) || string.IsNullOrWhiteSpace(obj.Descripcion))
            {
                Mensaje = "La Descripcion no puede quedar vacia";

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

        public bool Eliminar(int id, out string Mensaje)
        {
            return objCapaDato.Eliminar(id, out Mensaje);

        }
        public List<Familia> ListarFamiliaporEstatus(int idestatus)
        {
            return objCapaDato.ListarFamiliaporEstatus(idestatus);

        }
    }
}
