using Data;
using LinqToDB;
using Logica.libreria;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logica
{
    public class LEstudiantes : Librerias
    {
        private List<TextBox> listaTextBox;
        private List<Label> listaLabel;
        private PictureBox image;
        private Bitmap _imagBitmap;
        private DataGridView _dataGridView;
        private NumericUpDown _numericupDown;
        private Paginador<Estudiant> _paginador;
        private string _accion =  "insert";
        //private Librerias librerias;
        public LEstudiantes(List<TextBox> listaTextBox, List<Label> listaLabel, object[] objetos)
        {
            this.listaTextBox = listaTextBox;
            this.listaLabel = listaLabel;
            this.image = (PictureBox)objetos[0];
            _imagBitmap = (Bitmap)objetos[1];
            _dataGridView = (DataGridView)objetos[2];
            _numericupDown = (NumericUpDown)objetos[3];
            Restablecer();
           // librerias = new Librerias();

        }

        public void Registrar()
        {
            if (listaTextBox[0].Text.Equals(""))
            {
                listaLabel[0].Text = "Este campo es requerido";
                listaLabel[0].ForeColor = Color.Red;
                listaTextBox[0].Focus();
            }
            else
            {
                if (listaTextBox[1].Text.Equals(""))
                {
                    listaLabel[1].Text = "Este campo es requerido";
                    listaLabel[1].ForeColor = Color.Red;
                    listaTextBox[1].Focus();
                }
                else
                {
                    if (listaTextBox[2].Text.Equals(""))
                    {
                        listaLabel[2].Text = "Este campo es requerido";
                        listaLabel[2].ForeColor = Color.Red;
                        listaTextBox[2].Focus();
                    }
                    else
                    {

                        if (listaTextBox[3].Text.Equals(""))
                        {
                            listaLabel[3].Text = "Este campo es requerido";
                            listaLabel[3].ForeColor = Color.Red;
                            listaTextBox[3].Focus();
                        }
                        else
                        {
                            if (texBoxEvent.ComprobarFormatoEmail(listaTextBox[3].Text))
                            {
                                //Aca buscamos entre los objeto si ya exite un email registrado. De ultima lo convertimos en tolista.
                                var user = _Estudiante.Where(u => u.email.Equals(listaTextBox[3].Text)).ToList();
                                if (user.Count.Equals(0))
                                {
                                    save();
                                }
                                else
                                {
                                    if (user[0].id.Equals(_idEstudiante))
                                    {
                                        save();
                                    }
                                    else
                                    {
                                        listaLabel[3].Text = "Email ya registrado.";
                                        listaLabel[3].ForeColor = Color.Red;
                                        listaTextBox[3].Focus();
                                    }
                                    
                                }
                            }
                            else
                            {
                                listaLabel[3].Text = "Email no valido";
                                listaLabel[3].ForeColor = Color.Red;
                                listaTextBox[3].Focus();
                            }
                        }
                    }
                }
            }
        
        }
        private List<Estudiant> listaEstudiante;
        public void Paginador(string metodo)
        {
            switch (metodo)
            {
                case "Primero":
                    _num_pagina = _paginador.primero();
                    break;
                case "Anterior":
                    _num_pagina = _paginador.anterior();
                    break;
                case "Siguiente":
                    _num_pagina = _paginador.siguiente();
                    break;
                case "Ultimo":
                    _num_pagina = _paginador.ultimo();
                    break;
            }
            SearchEstudiente("");
        }

        public void Eliminar()
        {
            if (_idEstudiante.Equals(0))
            {
                MessageBox.Show("Selecciones un estudiante");
            }
            else
            {
                if(MessageBox.Show("Estas seguro de eliminar el estudiante?","Eliminar Estudiante", 
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _Estudiante.Where(c => c.id.Equals(_idEstudiante)).Delete();
                    Restablecer();
                }
            }
        }



        public void Restablecer()
        {
            _accion = "insert";
            _num_pagina = 1;
            _idEstudiante = 0;
            image.Image = _imagBitmap;
            listaTextBox[0].Text = "";
            listaTextBox[1].Text = "";
            listaTextBox[2].Text = "";
            listaTextBox[3].Text = "";
            listaLabel[0].ForeColor = Color.LightSlateGray;
            listaLabel[1].ForeColor = Color.LightSlateGray;
            listaLabel[2].ForeColor = Color.LightSlateGray;
            listaLabel[3].ForeColor = Color.LightSlateGray;
            listaLabel[0].Text = "Nid";
            listaLabel[1].Text = "Nombre";
            listaLabel[2].Text = "Apellido";
            listaLabel[3].Text = "Email";
            listaEstudiante = _Estudiante.ToList();
            if (0 < listaEstudiante.Count)
            {
                _paginador = new Paginador<Estudiant>(listaEstudiante, listaLabel[4], _reg_por_pagina);
            }
            SearchEstudiente("");
        }

        private void save()
        {
            //inicia una transaccion de base de datos.
            BeginTransactionAsync();
            try
            {
                //Obtenemos el objeto imagen almacenada el imagen con la propiedad Image.
                var imageArray = uploadImage.ImageToByte(image.Image);
                switch (_accion)
                {
                    case "insert":
                        _Estudiante.Value(e => e.nid, listaTextBox[0].Text)
                            .Value(e => e.nombre, listaTextBox[1].Text)
                            .Value(e => e.apellido, listaTextBox[2].Text)
                            .Value(e => e.email, listaTextBox[3].Text)
                            .Value(e => e.image, imageArray)
                            .Insert();
                        break;
                    case "update":
                        //set el metodo para asignar datos.
                        _Estudiante.Where(e => e.id.Equals(_idEstudiante))
                            .Set(e => e.nombre, listaTextBox[1].Text)
                            .Set(e => e.apellido, listaTextBox[2].Text)
                            .Set(e => e.email, listaTextBox[3].Text)
                            .Set(e => e.image, imageArray)
                            .Update();
                        break;
                  
                }
                //En este metodo le incamos que esta operacion de transacion que ha realizado sastifatoriamente. 
                CommitTransaction();
                Restablecer();


            }
            catch (Exception)
            {

                //reinvierto toda la operacion de inserte que tiene en memoria que se a efectuado sastifatoriamente. 
                RollbackTransaction();
            }
        }

        private int _reg_por_pagina = 2, _num_pagina = 1;
        public void SearchEstudiente(string campo)
        {
            List<Estudiant> query = new List<Estudiant>();
            int inicio = (_num_pagina - 1) * _reg_por_pagina;
            if (campo.Equals(""))
            {
                query = _Estudiante.ToList();
            }
            else
            {
                query = _Estudiante.Where(c => c.nid.StartsWith(campo) || c.nombre.StartsWith(campo) || c.apellido.StartsWith(campo)).ToList();
            }
            if (0 < query.Count)
            {
                _dataGridView.DataSource = query.Select(c => new { 
                    c.id,
                    c.nid,
                    c.nombre,
                    c.apellido,
                    c.email,
                    c.image
                }).Skip(inicio).Take(_reg_por_pagina).ToList();
                _dataGridView.Columns[0].Visible = false;
                _dataGridView.Columns[5].Visible = false;
                _dataGridView.Columns[1].DefaultCellStyle.BackColor = Color.WhiteSmoke;
                _dataGridView.Columns[3].DefaultCellStyle.BackColor = Color.WhiteSmoke;

            }
            else
            {
                _dataGridView.DataSource = query.Select(c => new
                {
                    c.id,
                    c.nombre,
                    c.apellido,
                    c.email,
                }).ToList(); 
            }
        }

        public void Registro_Paginas()
        {
            _num_pagina = 1;
            _reg_por_pagina = (int)_numericupDown.Value;
            var list = _Estudiante.ToList();
            if(0 < list.Count)
            {
                _paginador = new Paginador<Estudiant>(listaEstudiante, listaLabel[4], _reg_por_pagina);
                SearchEstudiente("");
            }
        }
        private int _idEstudiante = 0;
        public void GetEstudiante()
        {
            _accion = "update";
            _idEstudiante = Convert.ToInt16(_dataGridView.CurrentRow.Cells[0].Value);
            listaTextBox[0].Text = Convert.ToString(_dataGridView.CurrentRow.Cells[1].Value);
            listaTextBox[1].Text = Convert.ToString(_dataGridView.CurrentRow.Cells[2].Value);
            listaTextBox[2].Text = Convert.ToString(_dataGridView.CurrentRow.Cells[3].Value);
            listaTextBox[3].Text = Convert.ToString(_dataGridView.CurrentRow.Cells[4].Value);
            try
            {
                byte[] arrayImagen = (byte[])_dataGridView.CurrentRow.Cells[5].Value;
                image.Image = uploadImage.byteArrayToImage(arrayImagen);
            }
            catch (Exception)
            {
                image.Image = _imagBitmap;
            }

        }

    }
}
