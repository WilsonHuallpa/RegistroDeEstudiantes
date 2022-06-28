using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logica.libreria
{
    public class TexBoxEvent
    {
        public void textKeyPress(KeyPressEventArgs e)
        {
            //vamos a captura el campo de texto.
            //Isletter con este metodo vamos a verificar si el siguiente 
            // caracter le corresponde al siguiente caracter de texto.
            if (char.IsLetter(e.KeyChar)) { e.Handled = false; }
            //e.KeyChar: Porpiedad que me va obtener el siguiente caracter del siguiente tecla precionada. 
            //e.Handled = false --> hacemos esto para permitir ingresar el siguien tecla en el campo de texto, false nos permite, true es negado. . 
            //condicion que permite no dar salto de linea cuando se oprime Enter.
            else if (e.KeyChar == Convert.ToChar(Keys.Enter)) { e.Handled = true; }
            //condicion que nos permite utilizar la tecla backspace
            else if (char.IsControl(e.KeyChar)) { e.Handled = false; }
            //Condicion que nos permite utilizar la tecla de espacio
            else if (char.IsSeparator(e.KeyChar)) { e.Handled = false; }
            else { e.Handled = true; }
        }
        public void numberKeyPress(KeyPressEventArgs e)
        {
            //vamos a captura el campo de texto.
            //Isletter con este metodo vamos a verificar si el siguiente 
            // caracter le corresponde al siguiente caracter de texto.
            if (char.IsDigit(e.KeyChar)) { e.Handled = false; }
            //e.KeyChar: Porpiedad que me va obtener el siguiente caracter del siguiente tecla precionada. 
            //e.Handled = false --> hacemos esto para permitir ingresar el siguien tecla en el campo de texto, false nos permite, true es negado. . 
            //condicion que permite no dar salto de linea cuando se oprime Enter.
            else if (e.KeyChar == Convert.ToChar(Keys.Enter)) { e.Handled = true; }
            //Condicion que no permite ingresar datos de tipos textos.
            else if (char.IsLetter(e.KeyChar)) { e.Handled = true; }
            //condicion que nos permite utilizar la tecla backspace
            else if (char.IsControl(e.KeyChar)) { e.Handled = false; }
            //Condicion que nos permite utilizar la tecla de espacio
            else if (char.IsSeparator(e.KeyChar)) { e.Handled = false; }
            else { e.Handled = true; }
        }

        public bool ComprobarFormatoEmail(string email)
        {
            //con esta clase podemos invocar un metodo para poder verificar si el email que viene por parametro es valido. true si. false no. 
            return new EmailAddressAttribute().IsValid(email);

        }

    }
}
