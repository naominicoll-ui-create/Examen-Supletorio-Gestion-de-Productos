using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace examen.Clases;


public interface IInventario
{
    void AgregarProducto(IProducto producto);
    bool EliminarProducto(string codigo);
    IProducto ConsultarProducto(string codigo);
    bool ModificarPrecio(string codigo, decimal nuevoPrecio);
    bool ModificarCantidad(string codigo, int nuevaCantidad);

    List<IProducto> ListarProductos();    // Todos
    List<IProducto> ListarEnStock();      // cantidad > 0
    List<IProducto> ListarAgotados();     // cantidad == 0
    List<IProducto> ListarPorOferta(decimal precioMaximo); // precio < precioMaximo
}

