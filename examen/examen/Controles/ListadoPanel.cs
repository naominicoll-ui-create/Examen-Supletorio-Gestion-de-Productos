using System;
using System.Drawing;
using System.Windows.Forms;

namespace examen.Controles
{
    // Este control encapsula el ListBox para mostrar los productos.
    public class ListadoPanel : GroupBox
    {
        public ListBox LstProductos { get; private set; } = null!;

        public ListadoPanel()
        {
            this.Text = "📋 Lista de Productos";
            this.Size = new Size(450, 370);
            this.BackColor = Color.LightGray;

            InicializarControles();
        }

        private void InicializarControles()
        {
            LstProductos = new ListBox();
            LstProductos.Size = new Size(430, 330);
            LstProductos.Location = new Point(10, 30);
            LstProductos.Font = new Font("Segoe UI", 10);
            LstProductos.BackColor = Color.White;
            this.Controls.Add(LstProductos);
        }
    }
}
