using System;
using System.Windows.Forms;

namespace examen
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Si usas .NET 6 o superior, ApplicationConfiguration.Initialize() configura opciones como DPI, fuente, etc.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}
