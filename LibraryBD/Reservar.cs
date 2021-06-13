using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LibraryBD
{
    public partial class Reservar : Form
    {
        private SqlConnection cn;
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
        public Reservar()
        {
            cn = getSGBDConnection();
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
