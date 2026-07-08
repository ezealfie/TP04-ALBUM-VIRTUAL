using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TP04_ALBUM.Models
{
    public class FiguritaXUsuario
    {
        public int idFiguritasXUsuario { get; set; }
        public int cantidad { get; set; }
        public int idFigurita { get; set; }
        public FiguritaXUsuario()
        {

        }
        public FiguritaXUsuario(int idFiguritasXUsuario, int cantidad, int idFigurita)
        {
            this.idFiguritasXUsuario = idFiguritasXUsuario;
            this.cantidad = cantidad;
            this.idFigurita = idFigurita;
        }
    }
}