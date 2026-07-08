using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TP04_ALBUM.Models
{
    public class Selecciones
    {
        public int id { get; set; }
        public string nombre { get; set; }

        public Selecciones()
        {
            
        }
        public Selecciones(int id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }
    }
}