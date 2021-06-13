using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Diagnostics;

namespace LibraryBD
{
    public partial class Consultar : Form
    {
        private SqlConnection cn;
        private int currentmember;
        public Consultar()
        {
            Debug.WriteLine("Init");
            //this.Load += Home_Load;
            InitializeComponent();


        }
        private void Consultar_Load(Object sender, EventArgs e) {
            Debug.WriteLine("load entered");
            cn = getSGBDConnection();
            Debug.WriteLine("Conexão efetuada");
            loadMembersToolStripMenuItem_Click(sender, e);
        }
        private SqlConnection getSGBDConnection()
        {
            //Andreia
            Debug.WriteLine("Tentar conectar");
            return new SqlConnection("data source= LAPTOP-1MGUSQ2L;integrated security=true;initial catalog=Projeto");
        }
        private bool verifySGBDConnection()
        {
            if (cn == null)
                cn = getSGBDConnection();

            if (cn.State != ConnectionState.Open)
                cn.Open();

            return cn.State == ConnectionState.Open;
        }
        private void loadMembersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Cheguei a funcao load");
            if (!verifySGBDConnection()) { 
                Debug.WriteLine("no conn");
            return; };

            SqlCommand cmd = new SqlCommand("SELECT * FROM BiblioBD.membro", cn);
            
            SqlDataReader reader = cmd.ExecuteReader();
            elementos.Items.Clear();

            while (reader.Read())
            {
                Membro C = new Membro();
                C.Id = reader["id"].ToString();
                C.Morada = reader["morada"].ToString();
                elementos.Items.Add(C);
            }

            cn.Close();
            currentmember = 0;
            ShowMembro();
        }
        public void ShowMembro ()
        {
            if (elementos.Items.Count == 0 | currentmember < 0)
                return;
            Membro contact = new Membro();
            contact = (Membro)elementos.Items[currentmember];
            textBox47.Text = contact.Id;
            textBox46.Text = contact.Morada;
            

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void elementos_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            currentmember = elementos.SelectedIndex;
            ShowMembro();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            loadMembersToolStripMenuItem_Click(
                sender, e);
        }
    }
}
