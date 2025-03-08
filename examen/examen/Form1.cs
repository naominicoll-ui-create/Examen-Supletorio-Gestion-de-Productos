using System;
using System.Drawing;
using System.Windows.Forms;
using examen.Clases;
using examen.Controles;  // Controles personalizados: DatosProductoPanel, AccionesPanel, ListadoPanel

namespace examen
{
    public class Form1 : Form
    {
        // Controles personalizados
        private DatosProductoPanel datosPanel;
        private AccionesPanel accionesPanel;
        private ListadoPanel listadoPanel;

        // Controles para Modificaciones y Filtros (como se mostró anteriormente)
        private GroupBox gbModificaciones;
        private Label lblNuevoPrecio;
        private TextBox txtNuevoPrecio;
        private Button btnModificarPrecio;
        private Label lblNuevaCantidad;
        private TextBox txtNuevaCantidad;
        private Button btnModificarCantidad;

        private GroupBox gbFiltros;
        private Button btnMostrarEnStock;
        private Button btnMostrarEnAgotados;
        private Label lblPrecioOferta;
        private TextBox txtPrecioOferta;
        private Button btnMostrarEnOferta;

        // Lógica del inventario
        private InventarioManager _inventario;

        /// <summary>
        /// Constructor del formulario.
        /// Muestra el SplashScreen y luego carga la interfaz principal.
        /// </summary>
        public Form1()
        {
            // Mostrar el splash screen antes de cargar el Form1
            using (SplashScreen splash = new SplashScreen())
            {
                splash.ShowDialog();
            }

            // Configuración del formulario principal
            this.Text = "📦 Gestión de Productos";
            this.Size = new Size(850, 650);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(240, 248, 255); // Azul claro

            // Inicializar la lógica del inventario
            _inventario = new InventarioManager();

            // Inicializar todos los controles de la interfaz
            InicializarControles();
        }

        /// <summary>
        /// Instancia y posiciona todos los controles en el formulario.
        /// </summary>
        private void InicializarControles()
        {
            // 1. Sección de datos del producto (control personalizado)
            datosPanel = new DatosProductoPanel();
            datosPanel.Location = new Point(20, 20);
            this.Controls.Add(datosPanel);

            // 2. Sección de acciones (control personalizado)
            accionesPanel = new AccionesPanel();
            accionesPanel.Location = new Point(20, 270);
            accionesPanel.Size = new Size(320, 80);
            this.Controls.Add(accionesPanel);

            // Asignamos los eventos a los botones de acciones
            accionesPanel.BtnAgregar.Click += BtnAgregar_Click;
            accionesPanel.BtnEliminar.Click += BtnEliminar_Click;
            accionesPanel.BtnConsultar.Click += BtnConsultar_Click;

            // 3. Sección de listado de productos (control personalizado)
            listadoPanel = new ListadoPanel();
            listadoPanel.Location = new Point(350, 20);
            this.Controls.Add(listadoPanel);

            // 4. Sección de Modificaciones (para modificar precio y cantidad)
            gbModificaciones = new GroupBox();
            gbModificaciones.Text = "✏️ Modificaciones";
            gbModificaciones.Size = new Size(320, 80);
            gbModificaciones.Location = new Point(20, 400);
            gbModificaciones.BackColor = Color.LavenderBlush;
            this.Controls.Add(gbModificaciones);

            // Nuevo Precio
            lblNuevoPrecio = new Label();
            lblNuevoPrecio.Text = "Nuevo Precio:";
            lblNuevoPrecio.Location = new Point(10, 25);
            lblNuevoPrecio.AutoSize = true;
            gbModificaciones.Controls.Add(lblNuevoPrecio);

            txtNuevoPrecio = new TextBox();
            txtNuevoPrecio.Location = new Point(110, 22);
            txtNuevoPrecio.Width = 80;
            gbModificaciones.Controls.Add(txtNuevoPrecio);

            btnModificarPrecio = new Button();
            btnModificarPrecio.Text = "💲 Modificar Precio";
            btnModificarPrecio.Size = new Size(120, 25);
            btnModificarPrecio.Location = new Point(200, 20);
            btnModificarPrecio.BackColor = Color.LightGoldenrodYellow;
            btnModificarPrecio.Click += BtnModificarPrecio_Click;
            gbModificaciones.Controls.Add(btnModificarPrecio);

            // Nueva Cantidad
            lblNuevaCantidad = new Label();
            lblNuevaCantidad.Text = "Nueva Cantidad:";
            lblNuevaCantidad.Location = new Point(10, 55);
            lblNuevaCantidad.AutoSize = true;
            gbModificaciones.Controls.Add(lblNuevaCantidad);

            txtNuevaCantidad = new TextBox();
            txtNuevaCantidad.Location = new Point(110, 52);
            txtNuevaCantidad.Width = 80;
            gbModificaciones.Controls.Add(txtNuevaCantidad);

            btnModificarCantidad = new Button();
            btnModificarCantidad.Text = "🔢 Modificar Cantidad";
            btnModificarCantidad.Size = new Size(120, 25);
            btnModificarCantidad.Location = new Point(200, 50);
            btnModificarCantidad.BackColor = Color.LightGoldenrodYellow;
            btnModificarCantidad.Click += BtnModificarCantidad_Click;
            gbModificaciones.Controls.Add(btnModificarCantidad);

            // 5. Sección de Filtros (para mostrar en stock, agotados y en oferta)
            gbFiltros = new GroupBox();
            gbFiltros.Text = "🔍 Filtros";
            gbFiltros.Size = new Size(320, 90);
            gbFiltros.Location = new Point(20, 490);
            gbFiltros.BackColor = Color.Honeydew;
            this.Controls.Add(gbFiltros);

            btnMostrarEnStock = new Button();
            btnMostrarEnStock.Text = "Stock";
            btnMostrarEnStock.Size = new Size(90, 30);
            btnMostrarEnStock.Location = new Point(10, 25);
            btnMostrarEnStock.BackColor = Color.LightSkyBlue;
            btnMostrarEnStock.Click += BtnMostrarEnStock_Click;
            gbFiltros.Controls.Add(btnMostrarEnStock);

            btnMostrarEnAgotados = new Button();
            btnMostrarEnAgotados.Text = "Agotados";
            btnMostrarEnAgotados.Size = new Size(90, 30);
            btnMostrarEnAgotados.Location = new Point(110, 25);
            btnMostrarEnAgotados.BackColor = Color.LightSalmon;
            btnMostrarEnAgotados.Click += BtnMostrarEnAgotados_Click;
            gbFiltros.Controls.Add(btnMostrarEnAgotados);

            lblPrecioOferta = new Label();
            lblPrecioOferta.Text = "Precio Oferta:";
            lblPrecioOferta.Location = new Point(10, 60);
            lblPrecioOferta.AutoSize = true;
            gbFiltros.Controls.Add(lblPrecioOferta);

            txtPrecioOferta = new TextBox();
            txtPrecioOferta.Location = new Point(110, 57);
            txtPrecioOferta.Width = 80;
            gbFiltros.Controls.Add(txtPrecioOferta);

            btnMostrarEnOferta = new Button();
            btnMostrarEnOferta.Text = "Oferta";
            btnMostrarEnOferta.Size = new Size(90, 30);
            btnMostrarEnOferta.Location = new Point(200, 55);
            btnMostrarEnOferta.BackColor = Color.LightPink;
            btnMostrarEnOferta.Click += BtnMostrarEnOferta_Click;
            gbFiltros.Controls.Add(btnMostrarEnOferta);
        }

        /// <summary>
        /// Evento para agregar un producto. Lee los datos desde datosPanel y agrega el producto al inventario.
        /// </summary>
        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string codigo = datosPanel.TxtCodigo.Text.Trim();
                string nombre = datosPanel.TxtNombre.Text.Trim();
                decimal precio = decimal.Parse(datosPanel.TxtPrecio.Text.Trim());
                int cantidad = int.Parse(datosPanel.TxtCantidad.Text.Trim());

                var producto = new ProductoBase(codigo, nombre, precio, cantidad);
                _inventario.AgregarProducto(producto);

                MessageBox.Show("✅ Producto agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ActualizarLista();
                datosPanel.LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("⚠️ Error al agregar producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento para eliminar un producto según el código ingresado.
        /// </summary>
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            string codigo = datosPanel.TxtCodigo.Text.Trim();
            if (string.IsNullOrEmpty(codigo))
            {
                MessageBox.Show("⚠️ Debes ingresar un código para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool resultado = _inventario.EliminarProducto(codigo);
            if (resultado)
                MessageBox.Show("🗑️ Producto eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("⚠️ No se encontró el producto.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            ActualizarLista();
            datosPanel.LimpiarCampos();
        }

        /// <summary>
        /// Evento para consultar un producto según el código ingresado.
        /// </summary>
        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            string codigo = datosPanel.TxtCodigo.Text.Trim();
            if (string.IsNullOrEmpty(codigo))
            {
                MessageBox.Show("⚠️ Debes ingresar un código para consultar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var producto = _inventario.ConsultarProducto(codigo);
            if (producto != null)
                MessageBox.Show("ℹ️ " + producto.ToString(), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("⚠️ No se encontró el producto.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            datosPanel.LimpiarCampos();
        }

        /// <summary>
        /// Evento para modificar el precio de un producto.
        /// Usa el código de datosPanel y el nuevo precio ingresado en txtNuevoPrecio.
        /// </summary>
        private void BtnModificarPrecio_Click(object sender, EventArgs e)
        {
            string codigo = datosPanel.TxtCodigo.Text.Trim();
            if (string.IsNullOrEmpty(codigo) || string.IsNullOrWhiteSpace(txtNuevoPrecio.Text))
            {
                MessageBox.Show("⚠️ Debes ingresar un código y un nuevo precio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (decimal.TryParse(txtNuevoPrecio.Text.Trim(), out decimal nuevoPrecio))
            {
                bool resultado = _inventario.ModificarPrecio(codigo, nuevoPrecio);
                if (resultado)
                    MessageBox.Show("💲 Precio modificado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("⚠️ No se encontró el producto.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("⚠️ El precio ingresado no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ActualizarLista();
            datosPanel.LimpiarCampos();
            txtNuevoPrecio.Text = "";
        }

        /// <summary>
        /// Evento para modificar la cantidad de un producto.
        /// Usa el código de datosPanel y la nueva cantidad ingresada en txtNuevaCantidad.
        /// </summary>
        private void BtnModificarCantidad_Click(object sender, EventArgs e)
        {
            string codigo = datosPanel.TxtCodigo.Text.Trim();
            if (string.IsNullOrEmpty(codigo) || string.IsNullOrWhiteSpace(txtNuevaCantidad.Text))
            {
                MessageBox.Show("⚠️ Debes ingresar un código y la nueva cantidad.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (int.TryParse(txtNuevaCantidad.Text.Trim(), out int nuevaCantidad))
            {
                bool resultado = _inventario.ModificarCantidad(codigo, nuevaCantidad);
                if (resultado)
                    MessageBox.Show("🔢 Cantidad modificada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("⚠️ No se encontró el producto.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("⚠️ La cantidad ingresada no es válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ActualizarLista();
            datosPanel.LimpiarCampos();
            txtNuevaCantidad.Text = "";
        }

        /// <summary>
        /// Evento para mostrar los productos en stock (cantidad > 0).
        /// </summary>
        private void BtnMostrarEnStock_Click(object sender, EventArgs e)
        {
            listadoPanel.LstProductos.Items.Clear();
            foreach (var p in _inventario.ListarEnStock())
            {
                listadoPanel.LstProductos.Items.Add(p.ToString());
            }
        }

        /// <summary>
        /// Evento para mostrar los productos agotados (cantidad == 0).
        /// </summary>
        private void BtnMostrarEnAgotados_Click(object sender, EventArgs e)
        {
            listadoPanel.LstProductos.Items.Clear();
            foreach (var p in _inventario.ListarAgotados())
            {
                listadoPanel.LstProductos.Items.Add(p.ToString());
            }
        }

        /// <summary>
        /// Evento para mostrar los productos en oferta (precio < valor ingresado).
        /// </summary>
        private void BtnMostrarEnOferta_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPrecioOferta.Text))
            {
                MessageBox.Show("⚠️ Debes ingresar un precio para oferta.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (decimal.TryParse(txtPrecioOferta.Text.Trim(), out decimal precioOferta))
            {
                listadoPanel.LstProductos.Items.Clear();
                foreach (var p in _inventario.ListarPorOferta(precioOferta))
                {
                    listadoPanel.LstProductos.Items.Add(p.ToString());
                }
            }
            else
            {
                MessageBox.Show("⚠️ El precio de oferta ingresado no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtPrecioOferta.Text = "";
        }

        /// <summary>
        /// Actualiza la lista de productos mostrando todos los productos del inventario.
        /// </summary>
        private void ActualizarLista()
        {
            listadoPanel.LstProductos.Items.Clear();
            foreach (var p in _inventario.ListarProductos())
            {
                listadoPanel.LstProductos.Items.Add(p.ToString());
            }
        }
    }
}
