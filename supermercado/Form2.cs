using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace supermercado
{
    public partial class Form2 : Form
    {
        string connexion = "Data Source=DESKTOP-2F4NVAS\\SQLEXPRESS;Initial Catalog=super;Integrated Security=True";
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'registroDataSet.Registro' Puede moverla o quitarla según sea necesario.
            this.registroTableAdapter.Fill(this.registroDataSet.Registro);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(connexion))
            {
                SqlCommand cmd = new SqlCommand("update Registro set Nombre= '" + txtNombre.Text + "', Contraseña= '" + txtContraseña.Text + "', Telefono='" + txtTelefono.Text + "'where DNI="+txtDNI.Text+"", cn);
                cmd.CommandType = CommandType.Text;

                cn.Open();//abrir la conneccion

                cmd.ExecuteNonQuery();//ejecutar la linea de codigo para llenar 

            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(connexion))
            {
                SqlCommand cmd = new SqlCommand("insert into Registro(DNI,Nombre,Contraseña,Telefono) values('"+txtDNI.Text+"','" + txtNombre.Text + "','" + txtContraseña.Text + "','"+txtTelefono.Text+"')", cn);
                cmd.CommandType = CommandType.Text;

                cn.Open();//abrir la conneccion

                cmd.ExecuteNonQuery();//ejecutar la linea de codigo para llenar 

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(connexion))
            {
                SqlCommand cmd = new SqlCommand("delete from Registro where DNI ="+txtDNI.Text, cn);
                cmd.CommandType = CommandType.Text;

                cn.Open();//abrir la conneccion

                cmd.ExecuteNonQuery();//ejecutar la linea de codigo para llenar 

            }
        }
    }
}
