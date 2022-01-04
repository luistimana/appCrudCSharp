using appKaraoke.Logica;
using appKaraoke.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace appKaraoke.Presentacion
{
    public partial class Usuarios : Form
    {
        public Usuarios()
        {
            InitializeComponent();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            panelUsuario.Visible = true;
            btnGuardar.Visible = true;
            btnGuardarCambios.Visible = false;
            textUsuario.Clear();
            textPass.Clear();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(textUsuario.Text !="")
            {
                if(textPass.Text !="")
                {
                    insertar_usuario();
                }
                else
                {
                    MessageBox.Show("Ingrese una contraseña", "Sin Contraseña", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Ingrese un usuario", "Sin Usuario", MessageBoxButtons.OK);
            }

        }

        private void insertar_usuario()
        {
            lusuarios dt = new lusuarios();
            dusuarios function = new dusuarios();
            dt.Usuario = textUsuario.Text;
            dt.Pass = textPass.Text;

            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            Icono.Image.Save(ms, Icono.Image.RawFormat);
            dt.Icono = ms.GetBuffer();
            dt.Estado = "ACTIVO";
            
            if(function.insertar (dt))
            {
                MessageBox.Show("Usuario Registrado", "Registro Correcto");
            }
        }

        private void Icono_Click(object sender, EventArgs e)
        {
            dlg.InitialDirectory = "";
            dlg.Filter = "Imagenes|*.jpg;*.png";
            dlg.FilterIndex = 2;
            dlg.Title = "Cargador de Imagenes";
            if(dlg.ShowDialog()==DialogResult.OK)
            {
                Icono.BackgroundImage = null;
                Icono.Image = new Bitmap(dlg.FileName);
            }
        }
    }
}
