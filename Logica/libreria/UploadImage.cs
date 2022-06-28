using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logica.libreria
{
    public class UploadImage
    {
        //abrimos una ventana para buscar una imagen desde la pc.
        private OpenFileDialog fd = new OpenFileDialog();

        public void CargarImagen(PictureBox pictureBox)
        {
            //Establecer la propíedad de WaitOnLoad a true significa que la imagen
        
            pictureBox.WaitOnLoad = true;
            fd.Filter = "Imagenes|*.jpg;*.gif;*.png;*.bmp";
            fd.ShowDialog();
            if (fd.FileName != string.Empty)
            {
                pictureBox.ImageLocation = fd.FileName;
            }
        }
        public byte[] ImageToByte (Image  img)
        {
            var converter = new ImageConverter();
            //Le estamos especificando que lo vamos a convertir ese objeto imagen en byte. 
            //lo que van a retornar un objeto y los vamos a convertir en byte. 
            return (byte[])converter.ConvertTo(img, typeof(byte[]));

        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            return Image.FromStream(ms);
        }
    }
}
