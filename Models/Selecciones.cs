using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TP04_ALBUM.Models
{
    public class Selecciones
    {
        public int idSeleccion { get; set; }
        public string nombre { get; set; }

        public Selecciones()
        {
            
        }
        public Selecciones(int idSeleccion, string nombre)
        {
            this.idSeleccion = idSeleccion;
            this.nombre = nombre;
        }
    }
}