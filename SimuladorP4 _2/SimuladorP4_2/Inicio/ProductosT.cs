using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inicio
{
    internal class ProductosT
    { 
            public string NoProducto { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad {  get; set; }

        public ProductosT(string noProducto, string nombre, decimal precio,int cantidad)
        {
            NoProducto = noProducto;
            Nombre = nombre;
            Precio = precio;
            Cantidad = cantidad;
        }

        public override string ToString()
        {
            return $"{NoProducto} - {Nombre}";
        }
    }
}
