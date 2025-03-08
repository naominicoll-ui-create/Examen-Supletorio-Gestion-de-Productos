using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examen.Clases;

public interface IProducto
{
    string Codigo { get; set; }
    string Nombre { get; set; }
    decimal Precio { get; set; }
    int Cantidad { get; set; }
}

