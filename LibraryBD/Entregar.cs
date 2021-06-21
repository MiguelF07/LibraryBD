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
    public partial class Entregar : Form
    {
        private SqlConnection cn;
        private SqlConnection cn2;
        private int currentEntity;
        private int currentItem;
        public Entregar()
        {
            InitializeComponent();
            loadEmp();

        }
        private SqlConnection getSGBDConnection()
        {
            return new SqlConnection("Data Source = " + "tcp:mednat.ieeta.pt\\SQLSERVER, 8101" + " ;" + "Initial Catalog = " + "p9g4" +
                                                      "; uid = " + "p9g4" + ";" + "password = " + "-1341259381@BD");
        }
        private bool verifySGBDConnection()
        {
            if (cn == null)
                cn = getSGBDConnection();

            if (cn.State != ConnectionState.Open)
                cn.Open();

            return cn.State == ConnectionState.Open;
        }
        private bool verifySGBDConnection2()
        {
            if (cn2 == null)
                cn2 = getSGBDConnection();

            if (cn2.State != ConnectionState.Open)
                cn2.Open();

            return cn2.State == ConnectionState.Open;
        }

        private void loadEmp()
        {
            if (!verifySGBDConnection())
            {
                Debug.WriteLine("no conn");
                return;
            };
            SqlCommand cmd = new SqlCommand("SELECT * FROM BiblioBD.emprestimo", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            emprestimos.Items.Clear();
            itens.Items.Clear();
            while (reader.Read())
            {
                Emprestimo C = new Emprestimo();
                C.Id1 = reader["funcionario"].ToString();
                C.Id2 = reader["membro"].ToString();
                C.Num = reader["numero"].ToString();
                C.Emp = reader["emprestimo"].ToString();
                C.Limite = reader["limite"].ToString();
                emprestimos.Items.Add(C);
            }
            cn.Close();
            this.currentEntity = 0;

        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
            {
                Debug.WriteLine("no conn");
                return;
            }
            currentEntity = emprestimos.SelectedIndex;
            if (emprestimos.Items.Count == 0 | currentEntity < 0)
                return;
            Emprestimo m = new Emprestimo();
            m = (Emprestimo)emprestimos.Items[currentEntity];
            //buscar id emprestimo
            SqlCommand cmd = new SqlCommand("BiblioBD.EstenderEmprestimo", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@num", m.Num));
            cmd.ExecuteNonQuery();
            cn.Close();
            System.Windows.Forms.MessageBox.Show("O seu emprestimo foi estendido por mais 15 dias.");
            loadEmp();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void procurar_Click(object sender, EventArgs e)
        {
            String _idm = idm.Text;
            if (!String.IsNullOrEmpty(_idm))
            {
                loadEmpId(_idm);
            }
            else
            {
                loadEmp();
            }
        }

        private void emprestimos_SelectedIndexChanged(object sender, EventArgs e)
        {
            showItem();
        }
        private void showItem()
        {
            currentEntity = emprestimos.SelectedIndex;
            itens.Items.Clear();
            if (emprestimos.Items.Count == 0 | currentEntity < 0)
                return;
            Emprestimo m = new Emprestimo();
            m = (Emprestimo)emprestimos.Items[currentEntity];
            //executar comandos para ir buscar itens
            if (!verifySGBDConnection())
            {
                Debug.WriteLine("no conn");
                return;
            }
            SqlCommand cmd = new SqlCommand("SELECT * FROM BiblioBD.emprestimoItem WHERE numero=" + m.Num, cn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Item C = new Item();
                C.Id = reader["id"].ToString();
                if (!verifySGBDConnection2())
                {
                    Debug.WriteLine("no conn");
                    return;
                };
                SqlCommand cmd2 = new SqlCommand("BiblioBD.getItem", cn2);
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.Add(new SqlParameter("@id", reader["id"].ToString()));
                cmd2.Parameters.Add("@nome", SqlDbType.VarChar, 60);
                cmd2.Parameters["@nome"].Direction = ParameterDirection.Output;
                cmd2.ExecuteNonQuery();
                C.Nome = Convert.ToString(cmd2.Parameters["@nome"].Value);
                cn2.Close();
                itens.Items.Add(C);
            }
            cn.Close();
        }
        private void loadEmpId(String _idm)
        {
            if (!verifySGBDConnection())
            {
                Debug.WriteLine("no conn");
                return;
            };
            SqlCommand cmd = new SqlCommand("SELECT * FROM BiblioBD.emprestimo WHERE membro=" + _idm, cn);
            SqlDataReader reader = cmd.ExecuteReader();
            emprestimos.Items.Clear();
            while (reader.Read())
            {
                Emprestimo C = new Emprestimo();
                C.Id1 = reader["funcionario"].ToString();
                C.Id2 = reader["membro"].ToString();
                C.Num = reader["numero"].ToString();
                C.Emp = reader["emprestimo"].ToString();
                C.Limite = reader["limite"].ToString();
                emprestimos.Items.Add(C);
            }
            cn.Close();
            this.currentEntity = 0;
            idm.Text = "";
        }

        private void ent1_Click(object sender, EventArgs e)
        {
            currentItem = itens.SelectedIndex;
            if (itens.Items.Count == 0 | currentItem < 0)
                return;
            Item m = new Item();
            m = (Item)itens.Items[currentItem];
            if (!verifySGBDConnection())
            {
                Debug.WriteLine("no conn");
                return;
            }
            SqlCommand cmd = new SqlCommand("BiblioBD.EliminarItemEmprestimo", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@item", m.Id));
            cmd.ExecuteNonQuery();
            cn.Close();
            itens.Items.Remove(m);
            loadEmp();

        }

        private void enttodos_Click(object sender, EventArgs e)
        {

            if (!verifySGBDConnection())
            {
                Debug.WriteLine("no conn");
                return;
            }
            currentEntity = emprestimos.SelectedIndex;
            if (emprestimos.Items.Count == 0 | currentEntity < 0)
                return;
            Emprestimo m = new Emprestimo();
            m = (Emprestimo)emprestimos.Items[currentEntity];
            //buscar id emprestimo
            SqlCommand cmd = new SqlCommand("BiblioBD.EliminarEmprestimo", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", m.Num));
            cmd.ExecuteNonQuery();
            cn.Close();
            loadEmp();


        }
    }
}
