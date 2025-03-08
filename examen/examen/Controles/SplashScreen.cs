using System;
using System.Drawing;
using System.Windows.Forms;

namespace examen
{
    public class SplashScreen : Form
    {
        private System.Windows.Forms.Timer fadeTimer;
        private System.Windows.Forms.Timer progressTimer;
        private Label lblMensaje;
        private Panel progressBarContainer;
        private Panel progressBarFill;
        private int progressValue = 0;
        private float opacityIncrement = 0.05f;

        public SplashScreen()
        {
            // Configuración de la ventana
            this.FormBorderStyle = FormBorderStyle.None; // Sin bordes
            this.StartPosition = FormStartPosition.CenterScreen; // Centrado en pantalla
            this.BackColor = Color.White;
            this.Size = new Size(500, 350);
            this.TopMost = true; // Mantener en frente
            this.Opacity = 0; // Iniciar transparente

            // Crear un Label con el mensaje de bienvenida
            lblMensaje = new Label
            {
                Text = "Cargando... 🚀",
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                AutoSize = true,
                ForeColor = Color.Black,
                TextAlign = ContentAlignment.MiddleCenter
            };
            this.Controls.Add(lblMensaje);

            // Contenedor de la barra de carga
            progressBarContainer = new Panel
            {
                Size = new Size(300, 20),
                Location = new Point((this.ClientSize.Width - 300) / 2, 250),
                BackColor = Color.LightGray, // Color de fondo de la barra
                BorderStyle = BorderStyle.FixedSingle
            };
            this.Controls.Add(progressBarContainer);

            // Barra de progreso (Panel interno)
            progressBarFill = new Panel
            {
                Size = new Size(0, 20), // Empieza sin tamaño
                BackColor = Color.DarkBlue // Color de la barra de progreso
            };
            progressBarContainer.Controls.Add(progressBarFill);

            // Timer para la animación de opacidad (fade in)
            fadeTimer = new System.Windows.Forms.Timer
            {
                Interval = 50 // Aumenta opacidad cada 50ms
            };
            fadeTimer.Tick += FadeIn_Tick;
            fadeTimer.Start();

            // Timer para animar la barra de carga
            progressTimer = new System.Windows.Forms.Timer
            {
                Interval = 30 // Velocidad de carga
            };
            progressTimer.Tick += ProgressTimer_Tick;
            progressTimer.Start();
        }

        // Animación Fade In
        private void FadeIn_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1)
                this.Opacity += opacityIncrement;
            else
                fadeTimer.Stop();
        }

        // Barra de progreso animada
        private void ProgressTimer_Tick(object sender, EventArgs e)
        {
            if (progressValue < 100)
            {
                progressValue += 1;
                progressBarFill.Width = (progressValue * progressBarContainer.Width) / 100; // Expande la barra
            }
            else
            {
                progressTimer.Stop();
                FadeOut();
            }
        }

        // Animación Fade Out
        private void FadeOut()
        {
            fadeTimer = new System.Windows.Forms.Timer
            {
                Interval = 50
            };
            fadeTimer.Tick += (s, e) =>
            {
                if (this.Opacity > 0)
                    this.Opacity -= opacityIncrement;
                else
                {
                    fadeTimer.Stop();
                    this.Close();
                }
            };
            fadeTimer.Start();
        }

        // Ajustar la posición del Label cuando el formulario se muestra
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            lblMensaje.Location = new Point((this.ClientSize.Width - lblMensaje.Width) / 2, 50);
        }
    }
}
