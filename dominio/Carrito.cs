using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Carrito
    {
        int id;
        public int cantidad { get; set; }
        public Articulo articulo { get; set; }
        public string imagenArt { get; set; }

        public Carrito()
        {

        }
        public Carrito(Articulo articulo, string imagenArt, int cantidad = 1)
        {
            this.id = 10;
            this.cantidad = cantidad;
            this.articulo = articulo;
            this.imagenArt = imagenArt;
        }

    }
}
