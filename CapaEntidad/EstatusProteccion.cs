using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{

    public class EstatusProteccion
    {
        public int IdEstatus { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
    }
}
