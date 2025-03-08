using System;
using System.Drawing;
using System.Windows.Forms;

namespace examen.Controles
{
    // Este control encapsula los botones de acción.
    public class AccionesPanel : GroupBox
    {
        // Propiedades públicas para acceder a los botones desde Form1.
        public Button BtnAgregar { get; private set; } = null!;
        public Button BtnEliminar { get; private set; } = null!;
        public Button BtnConsultar { get; private set; } = null!;

        public AccionesPanel()
        {
            // Configuración del GroupBox
            this.Text = "⚡ Acciones";
            this.Size = new Size(300, 120);
            this.BackColor = Color.LightCyan;

            InicializarControles();
        }

        private void InicializarControles()
        {
            // Botón Agregar
            BtnAgregar = new Button();
            BtnAgregar.Text = "✅ Agregar";
            BtnAgregar.Size = new Size(90, 35);
            BtnAgregar.Location = new Point(20, 35);
            BtnAgregar.BackColor = Color.LightGreen;
            this.Controls.Add(BtnAgregar);

            // Botón Eliminar
            BtnEliminar = new Button();
            BtnEliminar.Text = "❌ Eliminar";
            BtnEliminar.Size = new Size(90, 35);
            BtnEliminar.Location = new Point(120, 35);
            BtnEliminar.BackColor = Color.LightCoral;
            this.Controls.Add(BtnEliminar);

            // Botón Consultar
            BtnConsultar = new Button();
            BtnConsultar.Text = "🔍 Consultar";
            BtnConsultar.Size = new Size(90, 35);
            BtnConsultar.Location = new Point(220, 35);
            BtnConsultar.BackColor = Color.LightBlue;
            this.Controls.Add(BtnConsultar);
        }
    }
}
