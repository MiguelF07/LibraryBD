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
        private int currentEntity;
        public Consultar()
        {
            Debug.WriteLine("Init");
            //this.Load += Home_Load;
            InitializeComponent();
            HideAll();


        }
        private void HideAll()
        {
            membro.Hide();
            funcionario.Hide();
            gerente.Hide();
            emprestimo.Hide();
            revista.Hide();
            revista.Hide();
            filme.Hide();
            periferico.Hide();
            cd.Hide();
            livro.Hide();
        }
        private void Consultar_Load(Object sender, EventArgs e)
        {
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
            //Miguel
            //return new SqlConnection("data source= DESKTOP-3E08FOH\\SQLEXPRESS;integrated security=true;initial catalog=Projeto");
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
            if (!verifySGBDConnection())
            {
                Debug.WriteLine("no conn");
                return;
            };

            //Fazer switch(?) para sabermos qual queremos apresentar
            
            loadMemberData();
            /*loadFuncData();
            loadManagData();
            loadEmpresData();
            loadJornData();
            loadRevData();
            loadFilmData();
            loadPerData();
            loadCdData();
            loadLivroData();*/
            //    membro.Show();
            //    SqlCommand cmd = new SqlCommand("SELECT * FROM BiblioBD.membro", cn);

            //    SqlDataReader reader = cmd.ExecuteReader();
            //    elementos.Items.Clear();

            //    while (reader.Read())
            //    {
            //        Membro C = new Membro();
            //        C.Id = reader["id"].ToString();
            //        C.Morada = reader["morada"].ToString();
            //        elementos.Items.Add(C);
            //    }

            //    cn.Close();
            //    currentEntity = 0;
            //    ShowMembro();
        }

        private void loadMemberData()
        {
            membro.Show();
            SqlCommand cmd = new SqlCommand("SELECT * FROM BiblioBD.membro", cn);

            SqlDataReader reader = cmd.ExecuteReader();
            elementos.Items.Clear();
            while (reader.Read())
            {
                Membro C = new Membro();
                C.Id = reader["id"].ToString();
                C.Morada = reader["morada"].ToString();
                //etc etc etc
                //...
                elementos.Items.Add(C);
            }
            cn.Close();
            this.currentEntity = 0;
            ShowMembro();
        }

        private void loadFuncData()
        {
            funcionario.Show();
            SqlCommand cmd = new SqlCommand("SELECT * FROM BiblioBD.funcionario", cn);

            SqlDataReader reader = cmd.ExecuteReader();
            elementos.Items.Clear();
            while (reader.Read())
            {
                //etc etc etc
                //...
            }
            cn.Close();
            this.currentEntity = 0;
            //ShowFunc(); Implementar
        }

        private void loadManagData()
        {
            gerente.Show();
            SqlCommand cmd = new SqlCommand("SELECT * FROM BiblioBD.gerente", cn);

            SqlDataReader reader = cmd.ExecuteReader();
            elementos.Items.Clear();
            while (reader.Read())
            {
                //etc etc etc
                //...
            }
            cn.Close();
            this.currentEntity = 0;
            //ShowManag(); Implementar
        }

        private void loadEmpresData()
        {
            emprestimo.Show();
            SqlCommand cmd = new SqlCommand("SELECT * FROM BiblioBD.emprestimo", cn);

            SqlDataReader reader = cmd.ExecuteReader();
            elementos.Items.Clear();
            while (reader.Read())
            {
                //etc etc etc
                //...
            }
            cn.Close();
            this.currentEntity = 0;
            //ShowEmpres(); Implementar
        }

        private void loadJornData()
        {
            revista.Show();
            SqlCommand cmd = new SqlCommand("SELECT * FROM BiblioBD.jornal", cn);

            SqlDataReader reader = cmd.ExecuteReader();
            elementos.Items.Clear();
            while (reader.Read())
            {
                //etc etc etc
                //...
            }
            cn.Close();
            this.currentEntity = 0;
            //ShowJorn(); Implementar
        }

        private void loadRevData()
        {
            revista.Show();
            SqlCommand cmd = new SqlCommand("SELECT * FROM BiblioBD.revista", cn);

            SqlDataReader reader = cmd.ExecuteReader();
            elementos.Items.Clear();
            while (reader.Read())
            {
                //etc etc etc
                //...
            }
            cn.Close();
            this.currentEntity = 0;
            //ShowRev(); Implementar
        }

        private void loadFilmData()
        {
            filme.Show();
            SqlCommand cmd = new SqlCommand("SELECT * FROM BiblioBD.filme", cn);

            SqlDataReader reader = cmd.ExecuteReader();
            elementos.Items.Clear();
            while (reader.Read())
            {
                //etc etc etc
                //...
            }
            cn.Close();
            this.currentEntity = 0;
            //ShowFilm(); Implementar
        }

        private void loadPerData()
        {
            periferico.Show();
            SqlCommand cmd = new SqlCommand("SELECT * FROM BiblioBD.periferico", cn);

            SqlDataReader reader = cmd.ExecuteReader();
            elementos.Items.Clear();
            while (reader.Read())
            {
                //etc etc etc
                //...
            }
            cn.Close();
            this.currentEntity = 0;
            //ShowPer(); Implementar
        }

        private void loadCdData()
        {
            cd.Show();
            SqlCommand cmd = new SqlCommand("SELECT * FROM BiblioBD.cd", cn);

            SqlDataReader reader = cmd.ExecuteReader();
            elementos.Items.Clear();
            while (reader.Read())
            {
                //etc etc etc
                //...
            }
            cn.Close();
            this.currentEntity = 0;
            //ShowCd(); Implementar
        }

        private void loadLivroData()
        {
            livro.Show();
            SqlCommand cmd = new SqlCommand("SELECT * FROM BiblioBD.livro", cn);

            SqlDataReader reader = cmd.ExecuteReader();
            elementos.Items.Clear();
            while (reader.Read())
            {
                //etc etc etc
                //...
            }
            cn.Close();
            this.currentEntity = 0;
            //ShowLivro(); Implementar
        }





        public void ShowMembro()
        {
            if (elementos.Items.Count == 0 | currentEntity < 0)
                return;
            Membro contact = new Membro();
            contact = (Membro)elementos.Items[currentEntity];
            membro_id.Text = contact.Id;
            membro_morada.Text = contact.Morada;


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
            currentEntity = elementos.SelectedIndex;
            ShowMembro();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            loadMembersToolStripMenuItem_Click(
                sender, e);
        }
    }
}
