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
    
    public partial class formLogin : Form
    {
        public formLogin()
        {
            InitializeComponent();
        }
        string connexion = "Data Source=DESKTOP-2F4NVAS\\SQLEXPRESS;Initial Catalog=super;Integrated Security=True";

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn =new SqlConnection(connexion))
            {
                SqlCommand cmd = new SqlCommand("insert into Login2(usuarios,Contraseña) values('"+txtUser.Text+"','"+txtPassword.Text +"')",cn);
                cmd.CommandType = CommandType.Text;

                cn.Open();//abrir la conneccion

                cmd.ExecuteNonQuery();//ejecutar la linea de codigo para llenar 

            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
