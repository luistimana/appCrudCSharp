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
        int idusuario;
        private void Usuarios_Load(object sender, EventArgs e)
        {
            mostrar_usuarios();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            panelUsuario.Visible = true;
            panelUsuario.Dock = DockStyle.Fill;
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
                    mostrar_usuarios();
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
                panelUsuario.Visible = false;
                panelUsuario.Dock = DockStyle.None;
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

        private void mostrar_usuarios()
        {
            DataTable dt;
            dusuarios funcion = new dusuarios();
            dt = funcion.mostrar_usuarios();
            dataListado.DataSource = dt;
        }

        private void dataListado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idusuario = Convert.ToInt32(dataListado.SelectedCells[2].Value.ToString());

            if (e.ColumnIndex == this.dataListado.Columns["Eliminar"].Index)
            {
                DialogResult result;
                result = MessageBox.Show("¿Realmente desea eliminar el usuario?", "Eliminar Usuario", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if(result == DialogResult.OK)
                {
                    eliminar_usuario();
                    mostrar_usuarios();
                }
            }

            if (e.ColumnIndex == this.dataListado.Columns["Editar"].Index)
            {
                
                textUsuario.Text = dataListado.SelectedCells[3].Value.ToString();
                textPass.Text = dataListado.SelectedCells[4].Value.ToString();

                Icono.BackgroundImage = null;
                byte[] b = (Byte[])dataListado.SelectedCells[5].Value;
                System.IO.MemoryStream ms = new System.IO.MemoryStream(b);
                Icono.Image = Image.FromStream(ms);

                panelUsuario.Visible = true;
                panelUsuario.Dock = DockStyle.Fill;
                btnGuardar.Visible = false;
                btnGuardarCambios.Visible = true;
            }
        }
        private void eliminar_usuario()
        {
            lusuarios dt = new lusuarios();
            dusuarios function = new dusuarios();
            dt.Idusuario = idusuario;

            if (function.eliminar_usuarios(dt))
            {
                MessageBox.Show("Usuario Eliminado", "Borrado Correcto");
                panelUsuario.Visible = false;
                panelUsuario.Dock = DockStyle.None;
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            panelUsuario.Visible = false;
            panelUsuario.Dock = DockStyle.None;
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            editar_usuario();
            mostrar_usuarios();
        }

        private void editar_usuario()
        {
            lusuarios dt = new lusuarios();
            dusuarios function = new dusuarios();
            dt.Idusuario = idusuario;
            dt.Usuario = textUsuario.Text;
            dt.Pass = textPass.Text;

            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            Icono.Image.Save(ms, Icono.Image.RawFormat);
            dt.Icono = ms.GetBuffer();
            dt.Estado = "ACTIVO";

            if (function.editar(dt))
            {
                MessageBox.Show("Usuario Modificado", "Registro Correcto");
                panelUsuario.Visible = false;
                panelUsuario.Dock = DockStyle.None;
            }
        }

        private void txtBuscador_TextChanged(object sender, EventArgs e)
        {
            buscar_usuarios();
        }

        private void buscar_usuarios()
        {
            DataTable dt;
            dusuarios funcion = new dusuarios();
            dt = funcion.buscar_usuarios(txtBuscador.Text);
            dataListado.DataSource = dt;
        }
    }
}
