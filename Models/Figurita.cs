using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TP04_ALBUM.Models
{
    public class Figurita
    {
        public int idFigurita { get; set; }
        public string img { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int idSeleccion { get; set; }
        public string numeroCamiseta { get; set; }
    public string nombreSeleccion { get; set; }  

        public Figurita() 
        {

        }
        public Figurita(int idFigurita, string img, string nombre, string descripcion, int idSeleccion, string numeroCamiseta)
        {
            this.idFigurita = idFigurita;
            this.img = img;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.idSeleccion = idSeleccion;
            this.numeroCamiseta = numeroCamiseta;
        }


    }
}