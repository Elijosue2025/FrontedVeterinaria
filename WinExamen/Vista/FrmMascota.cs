using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinExamen.Vista
{
    public partial class FrmMascota : Form
    {
        public partial class FrmTipoProducto : Form
        {
            //   private readonly ApiClienteEmbutidos _apiClienteEmbutidos; // Instancia del cliente API
            private const string ApiUrl = "https://localhost:7157/api/"; // URL base del API



            public FrmTipoProducto()
            {

            }


            private async Task CargarTipoProducto()
            {

            }


            private void btGuardar_Click(object sender, EventArgs e)
            {
                // Aquí puedes agregar la lógica para guardar un nuevo tipo de producto
            }




        }

        public FrmMascota()
        {
            InitializeComponent();
        }

        private void FrmPacientes_Load(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
