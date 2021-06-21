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
            detalhes.Hide();
            add_tipo.Items.Add("Pintura");
            add_tipo.Items.Add("Teatro");
            add_tipo.Items.Add("Leitura");
            pes_tipo.Items.Add("Pintura");
            pes_tipo.Items.Add("Teatro");
            pes_tipo.Items.Add("Leitura");
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
                C.Nome = reader["nome"].ToString();
                C.Tipo = reader["tipo"].ToString();
                C.Data = reader["dataAti"].ToString();
                C.Hora = reader["horario"].ToString();
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
            principal.Hide();
            clearAll();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
            {
                Debug.WriteLine("no conn");
                return;
            }
            try
            {
                SqlCommand cmd = new SqlCommand("BiblioBD.adicionarAtividade", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@nome", add_nome.Text));
                cmd.Parameters.Add(new SqlParameter("@tipo", add_tipo.Text));
                cmd.Parameters.Add(new SqlParameter("@dataAti", add_data.Value.ToString("yyyy-MM-dd")));
                cmd.Parameters.Add(new SqlParameter("@horario", add_hora.Text));
                Debug.WriteLine(add_data.Value.ToString("yyyy-MM-dd"));
                Debug.WriteLine(add_tipo.Text);
                cmd.ExecuteNonQuery();
                cn.Close();
                carregarAtividades();
            }
            catch (SqlException se)
            {
                System.Windows.Forms.MessageBox.Show("Não foi possível adicionar a atividade. Verifique que não existe outra atividade desse tipo no mesmo dia.");

            }
            adicionargroup.Hide();
            principal.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            adicionargroup.Hide();
            principal.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            detalhes.Show();
            principal.Hide();
            clearAll();
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
            if (!verifySGBDConnection())
            {
                Debug.WriteLine("no conn");
                return;
            }
            SqlCommand cmd = new SqlCommand("SELECT * FROM BiblioBD.membrosAtividade('" + m.Nome + "')", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Membro C = new Membro();
                C.Id = reader["id"].ToString();
                C.Nome = reader["nome"].ToString();
                C.Email = reader["email"].ToString();
                C.Nif = reader["Nif"].ToString();
                C.Nascimento = reader["nascimento"].ToString();
                C.Morada = reader["morada"].ToString();
                det_membros.Items.Add(C);
            }
            cn.Close();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            detalhes.Hide();
            principal.Show();
        }
        private void clearAll()
        {
            det__nome.Text = "";
            det_tipo.Text = "";
            det_hora.Text = "";
            det_data.Text = "";
            add_data.Text = "";
            add_nome.Text = "";
            add_hora.Text = "";
            add_tipo.Text = "";
            det_membros.Items.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Atividade m = new Atividade();
            if (atividades_lista.SelectedIndex >= 0)
            {
                m = (Atividade)atividades_lista.Items[atividades_lista.SelectedIndex];
                Debug.WriteLine(m.Nome);
                if (!verifySGBDConnection())
                {
                    Debug.WriteLine("no conn");
                    return;
                }
                SqlCommand cmd = new SqlCommand("BiblioBD.eliminarAtividade", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@nome", m.Nome));
                cmd.ExecuteNonQuery();
                cn.Close();
                carregarAtividades();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Selecione uma atividade para eliminar.");
            }
        }

        private void pesquisar_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
            {
                Debug.WriteLine("no conn");
                return;
            }
            String _membro = pes_nome.Text;
            String _tipo = pes_tipo.Text;
            String comando = "";
            if (!String.IsNullOrEmpty(_membro) & !String.IsNullOrEmpty(_tipo))
            {
                comando = "SELECT * FROM BiblioBD.obterAtividadesMembroTipo(" + _membro + ",'" + _tipo + "');";
            }
            else if (!String.IsNullOrEmpty(_membro))
            {
                comando = "SELECT * FROM BiblioBD.obterAtividadesMembro(" + _membro + ");";
            }
            else if (!String.IsNullOrEmpty(_tipo))
            {
                comando = "SELECT * FROM BiblioBD.obterAtividadesTipo('" + _tipo + "');";
            }
            else
            {
                cn.Close();
                carregarAtividades();
                return;
            }
            Debug.WriteLine(_membro);
            SqlCommand cmd = new SqlCommand(comando, cn);
            SqlDataReader reader = cmd.ExecuteReader();
            atividades_lista.Items.Clear();
            while (reader.Read())
            {
                Atividade C = new Atividade();
                C.Nome = reader["nome"].ToString();
                C.Tipo = reader["tipo"].ToString();
                C.Data = reader["dataAti"].ToString();
                C.Hora = reader["horario"].ToString();
                atividades_lista.Items.Add(C);
            }
            cn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //adicionar membro

            if (atividades_lista.SelectedIndex >= 0)
            {
                try
                {
                    Atividade m = new Atividade();
                    m = (Atividade)atividades_lista.Items[atividades_lista.SelectedIndex];
                    Debug.WriteLine(m.Nome);
                    if (!verifySGBDConnection())
                    {
                        Debug.WriteLine("no conn");
                        return;
                    }
                    SqlCommand cmd = new SqlCommand("BiblioBD.adicionarMembroAtividade", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@id", add_membro.Text));
                    cmd.Parameters.Add(new SqlParameter("@nome", m.Nome));
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    add_membro.Text = "";
                }
                catch {
                    System.Windows.Forms.MessageBox.Show("O membro já participa numa atividade nesse dia.");
                }
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Selectione uma atividade.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //remover membro
            if (atividades_lista.SelectedIndex >= 0)
            {
                string message = "Deseja mesmo remover este membro?";
                string caption = "Confirme";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;
                result= MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                Atividade m = new Atividade();
                m = (Atividade)atividades_lista.Items[atividades_lista.SelectedIndex];
                Debug.WriteLine(m.Nome);
                if (!verifySGBDConnection())
                {
                    Debug.WriteLine("no conn");
                    return;
                }
                SqlCommand cmd = new SqlCommand("BiblioBD.removerMembroAtividade", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@id", rem_membro.Text));
                cmd.Parameters.Add(new SqlParameter("@nome", m.Nome));
                cmd.ExecuteNonQuery();
                cn.Close();
                rem_membro.Text = "";
            }}
            else
            {
                System.Windows.Forms.MessageBox.Show("Selecione uma atividade.");
            }
        }

        private void pesquisar_Click_1(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
            {
                Debug.WriteLine("no conn");
                return;
            }
            String _membro = pes_nome.Text;
            String _tipo = pes_tipo.Text;
            String comando = "";
            if (!String.IsNullOrEmpty(_membro) & !String.IsNullOrEmpty(_tipo))
            {
                comando = "SELECT * FROM BiblioBD.obterAtividadesMembroTipo(" + _membro + ",'" + _tipo + "');";
            }
            else if (!String.IsNullOrEmpty(_membro))
            {
                comando = "SELECT * FROM BiblioBD.obterAtividadesMembro(" + _membro + ");";
            }
            else if (!String.IsNullOrEmpty(_tipo))
            {
                comando = "SELECT * FROM BiblioBD.obterAtividadesTipo('" + _tipo + "');";
            }
            else
            {
                cn.Close();
                carregarAtividades();
                return;
            }
            Debug.WriteLine(_membro);
            SqlCommand cmd = new SqlCommand(comando, cn);
            SqlDataReader reader = cmd.ExecuteReader();
            atividades_lista.Items.Clear();
            while (reader.Read())
            {
                Atividade C = new Atividade();
                C.Nome = reader["nome"].ToString();
                C.Tipo = reader["tipo"].ToString();
                C.Data = reader["dataAti"].ToString();
                C.Hora = reader["horario"].ToString();
                atividades_lista.Items.Add(C);
            }
            cn.Close();
        }
    }
}
