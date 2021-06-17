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
    public partial class Atividades : Form
    {
        private SqlConnection cn;
        private int currentEntity;
        public Atividades()
        {
            InitializeComponent();
            adicionargroup.Hide();
            add_tipo.Items.Add("Pintura");
            add_tipo.Items.Add("Teatro");
            add_tipo.Items.Add("Leitura");
            carregarAtividades();

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
        private void carregarAtividades()
        {
            if (!verifySGBDConnection())
            {
                Debug.WriteLine("no conn");
                return;
            }
            SqlCommand cmd = new SqlCommand("SELECT * FROM BiblioBD.obterAtividades()", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            atividades_lista.Items.Clear();
            while (reader.Read())
            {
                Atividade C = new Atividade();
                C.Id = reader["id"].ToString();
                C.Nome = reader["nome"].ToString();
                C.Email = reader["email"].ToString();
                C.Nif = reader["Nif"].ToString();
                C.Nascimento = reader["nascimento"].ToString();
                C.Morada = reader["morada"].ToString();
                atividades_lista.Items.Add(C);
            }
            cn.Close();
        }
        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            adicionargroup.Show();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
            {
                Debug.WriteLine("no conn");
                return;
            }
            SqlCommand cmd = new SqlCommand("BiblioBD.adicionarAtividade", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@nome", add_nome.Text));
            cmd.Parameters.Add(new SqlParameter("@tipo", add_tipo.Text));
            cmd.Parameters.Add(new SqlParameter("@dataAti", add_data.Value.ToString("yyyy-MM-dd")));
            cmd.Parameters.Add(new SqlParameter("@horario", add_hora.Text));
            cmd.ExecuteNonQuery();
            cn.Close();
            adicionargroup.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            adicionargroup.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            detalhes.Show();
            currentEntity = atividades_lista.SelectedIndex;
            if (atividades_lista.Items.Count == 0 | currentEntity < 0)
                return;
            Atividade m = new Atividade();
            m = (Atividade)atividades_lista.Items[currentEntity];
            det__nome.Text = m.Nome;
            det_tipo.Text = m.Tipo;
            det_hora.Text = m.Hora;
            det_data.Text = m.Data;
            //executar comandos para ir buscar membros
        }
    }
}
