using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCSSdkClient.Demo
{
    public partial class BaseForm : Form
    {
        // Define el título aquí, o hazlo estático si quieres cambiarlo en tiempo de ejecución
        private const string TituloAplicacion = "Mi Gran Aplicación 1.0";
        //private const string TituloAplicacion = "Radiaktive - ETS/ATS Events to Streamer.Bot";

        public BaseForm()
        {
            InitializeComponent();

            // Asigna el título al crear el formulario base
            this.Text = TituloAplicacion;
        }

        // Opcional: Si quieres que todos los títulos se compongan de una base más un subtítulo
        public BaseForm(string subtitulo) : this()
        {
            this.Text = TituloAplicacion + " - " + subtitulo;
        }
    }
}
