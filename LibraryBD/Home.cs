using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LibraryBD
{
    public partial class Home : Form
    {
        private SqlConnection cn;
        public Home()
        {
            cn = getSGBDConnection();
            InitializeComponent();
        }
        /*private SqlConnection getSGBDConnection()
        {
            return new SqlConnection("data source= DESKTOP-3E08FOH\SQLEXPRESS;integrated security=true;initial catalog=Northwind");
        }*/
        private SqlConnection getSGBDConnection()
        {   
            //Andreia
            return new SqlConnection("data source= LAPTOP-1MGUSQ2L/SQLEXPRESS;integrated security=true;initial catalog=Projeto");
        }
        private bool verifySGBDConnection()
        {
            if (cn == null)
                cn = getSGBDConnection();

            if (cn.State != ConnectionState.Open)
                cn.Open();

            return cn.State == ConnectionState.Open;
        }
        private void button1_Click(object sender, EventArgs e)
        { //botao consultar
            Consultar cons = new Consultar();
            cons.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //botao reservar
            Reservar cons = new Reservar();
            cons.ShowDialog();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void entregar_Click(object sender, EventArgs e)
        {
            //botao entregar
            Entregar cons = new Entregar();
            cons.ShowDialog();
        }

        private void atividades_Click(object sender, EventArgs e)
        {
            //botao atividades
            Atividades cons = new Atividades();
            cons.ShowDialog();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            //botao info
            Infobibl cons = new Infobibl();
            cons.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
