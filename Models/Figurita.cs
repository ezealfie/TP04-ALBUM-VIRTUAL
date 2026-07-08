using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TP04_ALBUM.Models
{
    public class Figurita
    {
        public int id { get; set; }
        public string img { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int FKEquipo { get; set; }
        public string numeroCamiseta { get; set; }

        public Figurita()
        {

        }
        public Figurita(int id, string img, string nombre, string descripcion, int FKEquipo, string numeroCamiseta)
        {
            this.id = id;
            this.img = img;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.FKEquipo = FKEquipo;
            this.numeroCamiseta = numeroCamiseta;
        }


    }
}