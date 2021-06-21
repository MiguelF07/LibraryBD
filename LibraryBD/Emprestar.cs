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
    public partial class Emprestar : Form
    {
        private SqlConnection cn;
        private String num;
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
        public Emprestar()
        {
            cn = getSGBDConnection();
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void criar_Click(object sender, EventArgs e)
        {   
            lista.Items.Clear();
            String _idm = idm.Text;
            String _idf = idf.Text;
            if (!String.IsNullOrEmpty(_idm) & !String.IsNullOrEmpty(_idf))
            {
                //chamar funcao de criar emprestimo
                //retorna @numero
                //try
                //{
                    if (!verifySGBDConnection())
                    {
                        Debug.WriteLine("no conn");
                        return;
                    }
                    itens.Enabled = true;
                    SqlCommand cmd = new SqlCommand("BiblioBD.AddEmprestimo", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@idF", _idf));
                    cmd.Parameters.Add(new SqlParameter("@idM", _idm));
                    cmd.Parameters.Add("@newnumero", SqlDbType.VarChar, 100);
                    cmd.Parameters["@newnumero"].Direction = ParameterDirection.Output;
                    cmd.ExecuteNonQuery();
                    num = Convert.ToString(cmd.Parameters["@newnumero"].Value);
                    cn.Close();
                //}
                /*catch
                {
                    System.Windows.Forms.MessageBox.Show("IDs inválidos ou membro tem emprestimos em atraso.");
                }*/

            }
            else {
                System.Windows.Forms.MessageBox.Show("Precisa de adicionar um ID membro e ID funcionário para criar o emprestimo.");
            }

        }

        private void adicionar_Click(object sender, EventArgs e)
        {
            String _idi = idi.Text;
            if (!String.IsNullOrEmpty(_idi))
            {
                //chamar func addicionar ao emprestimo
                
                if (!verifySGBDConnection())
                {
                    Debug.WriteLine("no conn");
                    return;
                }
                itens.Enabled = true;
                try { 
                SqlCommand cmd = new SqlCommand("BiblioBD.AddItemEmprestimo", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@num", num));
                cmd.Parameters.Add(new SqlParameter("@idItem", _idi));
                cmd.ExecuteNonQuery();
                lista.Items.Add(_idi);
                }
                catch {
                    System.Windows.Forms.MessageBox.Show("Esse item não está disponível ou você ultrapassou o número máximo de itens que pode levar.");
                }

                cn.Close();
            }
            else {
                System.Windows.Forms.MessageBox.Show("Precisa de adicionar um ID item para adicionar itens ao emprestimo.");
            }

        }
    }
}
