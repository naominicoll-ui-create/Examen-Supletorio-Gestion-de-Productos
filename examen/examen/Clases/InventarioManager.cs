using System;
using System.Collections.Generic;
using System.Linq;
using examen.Clases; // Asegúrate de que el namespace es correcto

namespace examen.Clases
{
    // Implementa la interfaz IInventario para gestionar los productos.
    public class InventarioManager : IInventario
    {
        // Lista interna de productos.
        private List<IProducto> _productos;

        // Constructor que inicializa la lista de productos.
        public InventarioManager()
        {
            _productos = new List<IProducto>();
        }

        // Agrega un producto al inventario. Lanza una excepción si ya existe un producto con el mismo código.
        public void AgregarProducto(IProducto producto)
        {
            if (_productos.Any(p => p.Codigo == producto.Codigo))
            {
                throw new Exception("Ya existe un producto con ese código.");
            }
            _productos.Add(producto);
        }

        // Elimina un producto del inventario según su código. Retorna true si se elimina, false si no se encuentra.
        public bool EliminarProducto(string codigo)
        {
            var producto = _productos.FirstOrDefault(p => p.Codigo == codigo);
            if (producto != null)
            {
                _productos.Remove(producto);
                return true;
            }
            return false;
        }

        // Consulta y retorna un producto según su código, o null si no existe.
        public IProducto ConsultarProducto(string codigo)
        {
            return _productos.FirstOrDefault(p => p.Codigo == codigo);
        }

        // Modifica el precio de un producto. Retorna true si se modifica, false si el producto no existe.
        public bool ModificarPrecio(string codigo, decimal nuevoPrecio)
        {
            var producto = ConsultarProducto(codigo);
            if (producto != null)
            {
                producto.Precio = nuevoPrecio;
                return true;
            }
            return false;
        }

        // Modifica la cantidad de un producto. Retorna true si se modifica, false si el producto no existe.
        public bool ModificarCantidad(string codigo, int nuevaCantidad)
        {
            var producto = ConsultarProducto(codigo);
            if (producto != null)
            {
                producto.Cantidad = nuevaCantidad;
                return true;
            }
            return false;
        }

        // Retorna la lista completa de productos.
        public List<IProducto> ListarProductos()
        {
            return _productos;
        }

        // Retorna los productos que tienen cantidad mayor a 0.
        public List<IProducto> ListarEnStock()
        {
            return _productos.Where(p => p.Cantidad > 0).ToList();
        }

        // Retorna los productos que tienen cantidad igual a 0.
        public List<IProducto> ListarAgotados()
        {
            return _productos.Where(p => p.Cantidad == 0).ToList();
        }

        // Retorna los productos cuyo precio es menor al valor especificado.
        public List<IProducto> ListarPorOferta(decimal precioMaximo)
        {
            return _productos.Where(p => p.Precio < precioMaximo).ToList();
        }
    }
}
