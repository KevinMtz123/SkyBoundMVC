using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Ave
    {
        public int IdAve { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Familia oFamilia { get; set; }
        public CategoriaEstacional oCategoriaEstacional { get; set; }
        public EstatusProteccion oEstatusProteccion { get; set; }
        public Habitat oHabitat { get; set; }
        public string Alimentacion { get; set; }
        public string FuncionEcos { get; set; }
        public string RutaImagen { get; set; }
        public string NombreImagen { get; set; }
        public bool Activa { get; set; }
        public bool ListaRoja { get; set; }

        public string Base64 { get; set; }
        public string Extension { get; set; }
    }
}
