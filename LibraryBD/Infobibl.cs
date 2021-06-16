using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;

namespace LibraryBD
{
    public partial class Infobibl : Form
    {
        private SqlConnection cn;
        public Infobibl()
        {
            InitializeComponent();
            if (!verifySGBDConnection())
            {
                Debug.WriteLine("no conn");
                return;
            };
            nome.ReadOnly = true;
            telefone.ReadOnly = true;
            morada.ReadOnly = true;
            getInfo();
        }
        private SqlConnection getSGBDConnection()
        {
            //Andreia
            Debug.WriteLine("Tentar conectar");
            return new SqlConnection("data source= LAPTOP-1MGUSQ2L;integrated security=true;initial catalog=Projeto");
            //Miguel
            //return new SqlConnection("data source= DESKTOP-3E08FOH\\SQLEXPRESS;integrated security=true;initial catalog=Projeto2");
        }
        private bool verifySGBDConnection()
        {
            if (cn == null)
                cn = getSGBDConnection();

            if (cn.State != ConnectionState.Open)
                cn.Open();

            return cn.State == ConnectionState.Open;
        }
        private void getInfo()
        {
            SqlCommand cmd = new SqlCommand("DECLARE @tel int;DECLARE @mor varchar(60);EXEC dbo.sp_Biblioteca 'Biblioteca Municipal', @tel OUTPUT, @mor OUTPUT;SELECT @tel AS tel ,@mor AS mor", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                telefone.Text = reader["tel"].ToString();
                morada.Text = reader["mor"].ToString();
                nome.Text = "Biblioteca Municipal";
            }
        }
    }
}
