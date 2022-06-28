using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica;
using Logica.libreria;

namespace Estudiantes
{
    public partial class Form1 : Form
    {
        private LEstudiantes estudiante;

        public Form1()
        {
            InitializeComponent();
            //librerias = new Librerias();
            //va contener uns lista de objeto de la clase textbox
            var listaTextBox = new List<TextBox>();
            listaTextBox.Add(TBoxID);
            listaTextBox.Add(TBoxNombre);
            listaTextBox.Add(TBoxApellido);
            listaTextBox.Add(TboxEmail);
            var listaLabel = new List<Label>();
            listaLabel.Add(lbNId);
            listaLabel.Add(lbNombre);
            listaLabel.Add(lbApellido);
            listaLabel.Add(lbEmail);
            listaLabel.Add(lbPaginas);
            object[] objetos =
            {
                pcBoxImagen,
                Properties.Resources.logo,
                dataGridView1,
                numericUpDown1
            };
            estudiante = new LEstudiantes(listaTextBox, listaLabel, objetos);
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pcBoxImagen_Click(object sender, EventArgs e)
        {
            estudiante.uploadImage.CargarImagen(pcBoxImagen);
        }

        private void TBoxID_TextChanged(object sender, EventArgs e)
        {
            //si la propiedad text es igual a vacio.
            if (TBoxID.Text.Equals(""))
            {
                lbNId.ForeColor = Color.LightSlateGray;
            }
            else
            {
                lbNId.ForeColor = Color.Green;
                lbNId.Text = "Nid"; 
            }
        }

        private void TBoxID_KeyPress(object sender, KeyPressEventArgs e)
        {
            estudiante.texBoxEvent.numberKeyPress(e);
        }

        private void TBoxNombre_TextChanged(object sender, EventArgs e)
        {
            if (TBoxNombre.Text.Equals(""))
            {
                
                lbNombre.ForeColor = Color.LightSlateGray;
            }
            else
            {
                lbNombre.ForeColor = Color.Green;
                lbNombre.Text = "Nombre";
            }

        }

        private void TBoxNombre_KeyPress(object sender, KeyPressEventArgs e)
        {

            estudiante.texBoxEvent.textKeyPress(e);
        }

        private void TBoxApellido_TextChanged(object sender, EventArgs e)
        {
            if (TBoxApellido.Text.Equals(""))
            {
                //Obtenemos el color del label en gris.
                lbApellido.ForeColor = Color.LightSlateGray;
            }
            else
            {
                lbApellido.ForeColor = Color.Green;
                lbApellido.Text = "Apellido";
            }

        }

        private void TBoxApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            estudiante.texBoxEvent.textKeyPress(e);
        }

        private void TboxEmail_TextChanged(object sender, EventArgs e)
        {
            //El siguiente evento lo vamos a utilizar para verificar los cambios que estan surgiendo en el campo de texto. 
            if (TboxEmail.Text.Equals(""))
            {
                lbEmail.ForeColor = Color.LightSlateGray;
            }
            else
            {
                lbEmail.ForeColor = Color.Green;
                lbEmail.Text = "Email";
            }
        }

        private void btbAgregar_Click(object sender, EventArgs e)
        {
             estudiante.Registrar();
        }
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            estudiante.SearchEstudiente(txtBuscar.Text);
        }

        private void btnPrimero_Click(object sender, EventArgs e)
        {
            estudiante.Paginador("Primero");
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            estudiante.Paginador("Anterior");
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            estudiante.Paginador("Siguiente");
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            estudiante.Paginador("Ultimo");
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            estudiante.Registro_Paginas();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.Rows.Count != 0)
                estudiante.GetEstudiante();
        }

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
                estudiante.GetEstudiante();
        }

        private void btnElminar_Click(object sender, EventArgs e)
        {
            estudiante.Eliminar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            estudiante.Restablecer();
        }
    }
}
