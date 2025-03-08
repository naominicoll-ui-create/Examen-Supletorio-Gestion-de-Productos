using System;
using System.Drawing;
using System.Windows.Forms;

namespace examen.Controles
{
    // Este control encapsula la sección de datos del producto.
    public class DatosProductoPanel : GroupBox
    {
        // Propiedades públicas para acceder a los TextBox desde Form1.
        public TextBox? TxtCodigo { get; private set; }
        public TextBox? TxtNombre { get; private set; }
        public TextBox? TxtPrecio { get; private set; }
        public TextBox? TxtCantidad { get; private set; }

        public DatosProductoPanel()
        {
            // Configuración del GroupBox
            this.Text = "🛒 Datos del Producto";
            this.Size = new Size(300, 240);
            this.BackColor = Color.LightYellow;
            this.ForeColor = Color.DarkSlateGray;

            // Inicializar controles internos
            InicializarControles();
        }

        private void InicializarControles()
        {
            // Etiqueta y TextBox para Código
            Label lblCodigo = new Label();
            lblCodigo.Text = "🔢 Código:";
            lblCodigo.Location = new Point(20, 30);
            lblCodigo.AutoSize = true;
            this.Controls.Add(lblCodigo);

            TxtCodigo = new TextBox();
            TxtCodigo.Location = new Point(120, 27);
            TxtCodigo.Width = 150;
            this.Controls.Add(TxtCodigo);

            // Etiqueta y TextBox para Nombre
            Label lblNombre = new Label();
            lblNombre.Text = "🏷️ Nombre:";
            lblNombre.Location = new Point(20, 70);
            lblNombre.AutoSize = true;
            this.Controls.Add(lblNombre);

            TxtNombre = new TextBox();
            TxtNombre.Location = new Point(120, 67);
            TxtNombre.Width = 150;
            this.Controls.Add(TxtNombre);

            // Etiqueta y TextBox para Precio
            Label lblPrecio = new Label();
            lblPrecio.Text = "💰 Precio:";
            lblPrecio.Location = new Point(20, 110);
            lblPrecio.AutoSize = true;
            this.Controls.Add(lblPrecio);

            TxtPrecio = new TextBox();
            TxtPrecio.Location = new Point(120, 107);
            TxtPrecio.Width = 150;
            this.Controls.Add(TxtPrecio);

            // Etiqueta y TextBox para Cantidad
            Label lblCantidad = new Label();
            lblCantidad.Text = "📦 Cantidad:";
            lblCantidad.Location = new Point(20, 150);
            lblCantidad.AutoSize = true;
            this.Controls.Add(lblCantidad);

            TxtCantidad = new TextBox();
            TxtCantidad.Location = new Point(120, 147);
            TxtCantidad.Width = 150;
            this.Controls.Add(TxtCantidad);
        }

        /// <summary>
        /// Limpia todos los campos de entrada.
        /// </summary>
        public void LimpiarCampos()
        {
            TxtCodigo.Text = "";
            TxtNombre.Text = "";
            TxtPrecio.Text = "";
            TxtCantidad.Text = "";
        }
    }
}
