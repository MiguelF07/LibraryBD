﻿using System;
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
        private SqlConnection cn2;
        private int currentEntity;
        private int currentTipo;
        private int guardartype;
        public Consultar()
        {
            //this.Load += Home_Load;
            InitializeComponent();
            HideAll();
            tipo.Items.Add("Membro");
            tipo.Items.Add("Funcionario");
            tipo.Items.Add("Gerente");
            tipo.Items.Add("Emprestimo");
            tipo.Items.Add("CD");
            tipo.Items.Add("Livro");
            tipo.Items.Add("Revista");
            tipo.Items.Add("Jornal");
            tipo.Items.Add("Periferico");
            tipo.Items.Add("Filme");
            button2.Hide();


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
        private SqlConnection getSGBDConnection()
        {
            //Andreia
            Debug.WriteLine("Tentar conectar");
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
        private void loadMembersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
            {
                Debug.WriteLine("no conn");
                return;
            };


        }

        private void loadMemberData()
        {
            if (!verifySGBDConnection())
            {
                Debug.WriteLine("no conn");
                return;
            };
            unlockButtons();
            membro.Show();
            SqlCommand cmd = new SqlCommand("SELECT * FROM BiblioBD.membro", cn);

            SqlDataReader reader = cmd.ExecuteReader();
            elementos.Items.Clear();
            while (reader.Read())
            {
                Membro C = new Membro();
                C.Id = reader["id"].ToString();
                C.Nome = reader["nome"].ToString();
                C.Email = reader["email"].ToString();
                C.Nif = reader["Nif"].ToString();
                C.Nascimento = reader["nascimento"].ToString();
                C.Morada = reader["morada"].ToString();
                elementos.Items.Add(C);
            }
            cn.Close();
            this.currentEntity = 0;
            ShowMembro();
            LockControls();
        }
        public void ShowMembro()
        {
            if (elementos.Items.Count == 0 | currentEntity < 0)
                return;
            Membro m = new Membro();
            m = (Membro)elementos.Items[currentEntity];
            membro_id.Text = m.Id;
            membro_morada.Text = m.Morada;
            membro_nome.Text = m.Nome;
            membro_email.Text = m.Email;
            membro_nif.Text = m.Nif;
            membro_nasc.Text = m.Nascimento;
        }


        private void loadFuncData()
        {
            if (!verifySGBDConnection())
            {
                Debug.WriteLine("no conn");
                return;
            };
            unlockButtons();
            funcionario.Show();
            SqlCommand cmd = new SqlCommand("SELECT * FROM BiblioBD.funcionario", cn);

            SqlDataReader reader = cmd.ExecuteReader();
            elementos.Items.Clear();
            while (reader.Read())
            {
                Funcionario C = new Funcionario();
                C.Id = reader["id"].ToString();
                C.Nome = reader["nome"].ToString();
                C.Email = reader["email"].ToString();
                C.Nif = reader["Nif"].ToString();
                C.Nascimento = reader["nascimento"].ToString();
                C.Morada = reader["morada"].ToString();
                C.Ssn = reader["ssn"].ToString();
                C.Inicio = reader["inicio"].ToString();
                C.Fim = reader["fim"].ToString();
                elementos.Items.Add(C);
            }
            cn.Close();
            this.currentEntity = 0;
            ShowFunc();
            LockControls();
        }
        public void ShowFunc()
        {
            if (elementos.Items.Count == 0 | currentEntity < 0)
                return;
            Funcionario f = new Funcionario();
            f = (Funcionario)elementos.Items[currentEntity];
            fun_id.Text = f.Id;
            fun_morada.Text = f.Morada;
            fun_nome.Text = f.Nome;
            fun_email.Text = f.Email;
            fun_nif.Text = f.Nif;
            fun_nasc.Text = f.Nascimento;
            fun_ssn.Text = f.Ssn;
            fun_f.Text = f.Fim;
            fun_i.Text = f.Inicio;
        }

        private void loadManagData()
        {
            if (!verifySGBDConnection())
            {
                Debug.WriteLine("no conn");
                return;
            };
            unlockButtons();
            gerente.Show();
            SqlCommand cmd = new SqlCommand("SELECT * FROM BiblioBD.gerente JOIN BiblioBD.funcionario ON BiblioBD.gerente.id=BiblioBD.funcionario.id", cn);

            SqlDataReader reader = cmd.ExecuteReader();
            elementos.Items.Clear();
            while (reader.Read())
            {
                Gerente C = new Gerente();
                C.Id = reader["id"].ToString();
                C.Nome = reader["nome"].ToString();
                C.Inicio = reader["inicio"].ToString();
                C.Fim = reader["fim"].ToString();
                elementos.Items.Add(C);
                //etc etc etc
                //...
            }
            cn.Close();
            this.currentEntity = 0;
            ShowManag();
            LockControls();
        }
        public void ShowManag()
        {
            if (elementos.Items.Count == 0 | currentEntity < 0)
                return;
            Gerente f = new Gerente();
            f = (Gerente)elementos.Items[currentEntity];
            ger_id.Text = f.Id;
            ger_fim.Text = f.Fim;
            ger_inicio.Text = f.Inicio;
        }
        private void loadEmpresData()
        {
            if (!verifySGBDConnection())
            {
                Debug.WriteLine("no conn");
                return;
            };
            emprestimo.Show();
            SqlCommand cmd = new SqlCommand("SELECT * FROM BiblioBD.emprestimo", cn);

            SqlDataReader reader = cmd.ExecuteReader();
            elementos.Items.Clear();
            while (reader.Read())
            {
                Emprestimo C = new Emprestimo();
                C.Id1 = reader["funcionario"].ToString();
                C.Id2 = reader["membro"].ToString();
                C.Num = reader["numero"].ToString();
                C.Emp = reader["emprestimo"].ToString();
                C.Limite = reader["limite"].ToString();
                elementos.Items.Add(C);
            }
            cn.Close();
            this.currentEntity = 0;
            ShowEmp();
            LockControls();
            editar.Enabled = false;
            adicionar.Enabled = false;
            eliminar.Enabled = false;
        }
        private bool verifySGBDConnection2()
        {
            if (cn2 == null)
                cn2 = getSGBDConnection();

            if (cn2.State != ConnectionState.Open)
                cn2.Open();

            return cn2.State == ConnectionState.Open;
        }
        public void ShowEmp()
        {
            if (elementos.Items.Count == 0 | currentEntity < 0)
                return;
            Emprestimo e = new Emprestimo();
            e = (Emprestimo)elementos.Items[currentEntity];
            emp_num.Text = e.Num;
            emp_idf.Text = e.Id1;
            emp_idmem.Text = e.Id2;
            emp_limite.Text = e.Limite;
            emp_dataemp.Text = e.Emp;
            Debug.WriteLine(currentEntity);
            listBox1.Items.Clear();
            if (elementos.Items.Count == 0 | currentEntity < 0)
                return;
            Emprestimo m = new Emprestimo();
            m = (Emprestimo)elementos.Items[currentEntity];
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
                listBox1.Items.Add(C);
            }
            cn.Close();
        }
        private void loadJornData()
        {
            if (!verifySGBDConnection())
            {
                Debug.WriteLine("no conn");
                return;
            };
            unlockButtons();
            revista.Show();
            SqlCommand cmd = new SqlCommand("SELECT * FROM BiblioBD.jornais", cn);

            SqlDataReader reader = cmd.ExecuteReader();
            elementos.Items.Clear();
            while (reader.Read())
            {
                Revista C = new Revista();
                C.DataL = reader["dataL"].ToString();
                C.Edicao = reader["edicao"].ToString();
                C.Id = reader["id"].ToString();
                C.Marca = reader["marca"].ToString();
                C.Seccao = reader["seccao"].ToString();
                C.Tipo = reader["tipo"].ToString();
                elementos.Items.Add(C);
                //etc etc etc
                //...
            }
            cn.Close();
            this.currentEntity = 0;
            ShowRev(); // a vista é a mesma
            LockControls();
        }

        private void loadRevData()
        {
            if (!verifySGBDConnection())
            {
                Debug.WriteLine("no conn");
                return;
            };
            unlockButtons();
            revista.Show();
            SqlCommand cmd = new SqlCommand("SELECT * FROM BiblioBD.revistas", cn);

            SqlDataReader reader = cmd.ExecuteReader();
            elementos.Items.Clear();
            while (reader.Read())
            {
                Revista C = new Revista();
                C.DataL = reader["dataL"].ToString();
                C.Edicao = reader["edicao"].ToString();
                C.Id = reader["id"].ToString();
                C.Marca = reader["marca"].ToString();
                C.Seccao = reader["seccao"].ToString();
                C.Tipo = reader["tipo"].ToString();
                elementos.Items.Add(C);
                //etc etc etc
                //...
            }
            cn.Close();
            this.currentEntity = 0;
            ShowRev();
            LockControls();
        }
        public void ShowRev()
        {
            if (elementos.Items.Count == 0 | currentEntity < 0)
                return;
            Revista r = new Revista();
            r = (Revista)elementos.Items[currentEntity];
            revista_data.Text = r.DataL;
            revista_edicao.Text = r.Edicao;
            revista_id.Text = r.Id;
            revista_marca.Text = r.Marca;
            revista_seccao.Text = r.Seccao;
            revista_tipo.Text = r.Tipo;
            if (!verifySGBDConnection())
            {
                Debug.WriteLine("no conn");
                return;
            };
            SqlCommand cmd = new SqlCommand("BiblioBD.Disponivel", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", revista_id.Text));
            cmd.Parameters.Add("@disp", SqlDbType.VarChar, 100);
            cmd.Parameters["@disp"].Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            String disp = Convert.ToString(cmd.Parameters["@disp"].Value);
            rev_disp.Text = disp;
            cn.Close();
        }

        private void loadFilmData()
        {
            if (!verifySGBDConnection())
            {
                Debug.WriteLine("no conn");
                return;
            };
            unlockButtons();
            filme.Show();
            SqlCommand cmd = new SqlCommand("SELECT * FROM BiblioBD.filme", cn);

            SqlDataReader reader = cmd.ExecuteReader();
            elementos.Items.Clear();
            while (reader.Read())
            {
                Filme F = new Filme();
                F.Id = reader["id"].ToString();
                F.Seccao = reader["seccao"].ToString();
                F.Realizador = reader["realizador"].ToString();
                F.Genero = reader["genero"].ToString();
                F.Ano = reader["ano"].ToString();
                F.Titulo = reader["titulo"].ToString();
                elementos.Items.Add(F);
            }
            cn.Close();
            this.currentEntity = 0;
            ShowFilm();
            LockControls();
        }

        public void ShowFilm()
        {
            if (elementos.Items.Count == 0 | currentEntity < 0)
                return;
            Filme fil = new Filme();
            fil = (Filme)elementos.Items[currentEntity];
            filme_id.Text = fil.Id;
            filme_seccao.Text = fil.Seccao;
            filme_realizador.Text = fil.Realizador;
            filme_genero.Text = fil.Genero;
            filme_ano.Text = fil.Ano;
            filme_titulo.Text = fil.Titulo;
            if (!verifySGBDConnection())
            {
                Debug.WriteLine("no conn");
                return;
            };
            SqlCommand cmd = new SqlCommand("BiblioBD.Disponivel", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", filme_id.Text));
            cmd.Parameters.Add("@disp", SqlDbType.VarChar, 100);
            cmd.Parameters["@disp"].Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            String disp = Convert.ToString(cmd.Parameters["@disp"].Value);
            filme_disp.Text = disp;
            cn.Close();
        }

        private void loadPerData()
        {
            if (!verifySGBDConnection())
            {
                Debug.WriteLine("no conn");
                return;
            };
            unlockButtons();
            periferico.Show();
            SqlCommand cmd = new SqlCommand("SELECT * FROM BiblioBD.perifericos", cn);

            SqlDataReader reader = cmd.ExecuteReader();
            elementos.Items.Clear();
            while (reader.Read())
            {
                Debug.WriteLine("in while");
                Perifericos P = new Perifericos();
                P.Id = reader["id"].ToString();
                P.Marca = reader["marca"].ToString();
                P.Modelo = reader["modelo"].ToString();
                P.Tipo = reader["tipo"].ToString();
                elementos.Items.Add(P);
            }
            cn.Close();
            this.currentEntity = 0;
            ShowPer();
            LockControls();
        }

        public void ShowPer()
        {
            if (elementos.Items.Count == 0 | currentEntity < 0)
                return;
            Perifericos p = new Perifericos();
            p = (Perifericos)elementos.Items[currentEntity];
            per_id.Text = p.Id;
            per_marca.Text = p.Marca;
            per_modelo.Text = p.Modelo;
            per_tipo.Text = p.Tipo; 
            if (!verifySGBDConnection())
            {
                Debug.WriteLine("no conn");
                return;
            };
            SqlCommand cmd = new SqlCommand("BiblioBD.Disponivel", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", per_id.Text));
            cmd.Parameters.Add("@disp", SqlDbType.VarChar, 100);
            cmd.Parameters["@disp"].Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            String disp = Convert.ToString(cmd.Parameters["@disp"].Value);
            per_disp.Text = disp;
            cn.Close();
        }

        private void loadCdData()
        {
            if (!verifySGBDConnection())
            {
                Debug.WriteLine("no conn");
                return;
            };
            unlockButtons();
            cd.Show();
            SqlCommand cmd = new SqlCommand("SELECT * FROM BiblioBD.cd", cn);

            SqlDataReader reader = cmd.ExecuteReader();
            elementos.Items.Clear();
            while (reader.Read())
            {
                CD C = new CD();
                C.Id = reader["id"].ToString();
                C.Artista = reader["artista"].ToString();
                C.Genero = reader["genero"].ToString();
                C.Ano = reader["ano"].ToString();
                C.Titulo = reader["titulo"].ToString();
                C.Seccao = reader["seccao"].ToString();
                elementos.Items.Add(C);
            }
            cn.Close();
            this.currentEntity = 0;
            ShowCd();
            LockControls();
        }

        public void ShowCd()
        {
            if (elementos.Items.Count == 0 | currentEntity < 0)
                return;
            CD c = new CD();
            c = (CD)elementos.Items[currentEntity];
            cd_id.Text = c.Id;
            cd_artista.Text = c.Artista;
            cd_genero.Text = c.Genero;
            cd_ano.Text = c.Ano;
            cd_titulo.Text = c.Titulo;
            cd_seccao.Text = c.Seccao; 
            if (!verifySGBDConnection())
            {
                Debug.WriteLine("no conn");
                return;
            };
            SqlCommand cmd = new SqlCommand("BiblioBD.Disponivel", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", cd_id.Text));
            cmd.Parameters.Add("@disp", SqlDbType.VarChar, 100);
            cmd.Parameters["@disp"].Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            String disp = Convert.ToString(cmd.Parameters["@disp"].Value);
            cd_disp.Text = disp;
            cn.Close();
        }

        private void loadLivroData()
        {
            if (!verifySGBDConnection())
            {
                Debug.WriteLine("no conn");
                return;
            };
            unlockButtons();
            livro.Show();
            SqlCommand cmd = new SqlCommand("SELECT * FROM BiblioBD.livro", cn);

            SqlDataReader reader = cmd.ExecuteReader();
            elementos.Items.Clear();
            while (reader.Read())
            {
                Livro L = new Livro();
                L.Id = reader["id"].ToString();
                L.Titulo = reader["titulo"].ToString();
                L.Autor = reader["autor"].ToString();
                L.Editora = reader["editora"].ToString();
                L.Ano = reader["ano"].ToString();
                L.Isbn = reader["isbn"].ToString();
                L.Genero = reader["genero"].ToString();
                L.Seccao = reader["seccao"].ToString();
                elementos.Items.Add(L);
            }
            cn.Close();
            this.currentEntity = 0;
            ShowLivro();
            LockControls();
        }
        public void ShowLivro()
        {
            if (elementos.Items.Count == 0 | currentEntity < 0)
                return;
            
            Livro l = new Livro();
            l = (Livro)elementos.Items[currentEntity];
            livro_id.Text = l.Id;
            livro_titulo.Text = l.Titulo;
            livro_autor.Text = l.Autor;
            livro_editora.Text = l.Editora;
            livro_ano.Text = l.Ano;
            livro_isbn.Text = l.Isbn;
            livro_genero.Text = l.Genero;
            livro_seccao.Text = l.Seccao;
            if (!verifySGBDConnection())
            {
                Debug.WriteLine("no conn");
                return;
            };
            SqlCommand cmd = new SqlCommand("BiblioBD.Disponivel", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", livro_id.Text));
            cmd.Parameters.Add("@disp", SqlDbType.VarChar, 100);
            cmd.Parameters["@disp"].Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            String disp = Convert.ToString(cmd.Parameters["@disp"].Value);
            livro_disp.Text = disp;
            cn.Close();
        }
        private void unlockButtons() {
            editar.Enabled = true;
            adicionar.Enabled = true;
            eliminar.Enabled = true;
            guardar.Enabled = false;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
            {
                Debug.WriteLine("no conn");
                return;
            };
            HideAll();
            currentTipo = tipo.SelectedIndex;
            switch (currentTipo)
            {
                case 0:
                    loadMemberData();
                    break;
                case 1:
                    loadFuncData();
                    break;
                case 2:
                    loadManagData();
                    break;
                case 3:
                    loadEmpresData();
                    break;
                case 4:
                    loadCdData();
                    break;
                case 5:
                    loadLivroData();
                    break;
                case 6:
                    loadRevData();
                    break;
                case 7:
                    loadJornData();
                    break;
                case 8:
                    loadPerData();
                    break;
                case 9:
                    loadFilmData();
                    break;
            }
        }
        private void elementos_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            currentEntity = elementos.SelectedIndex;
            switch (currentTipo)
            {
                case 0:
                    ShowMembro();
                    break;
                case 1:
                    ShowFunc();
                    break;
                case 2:
                    ShowManag();
                    break;
                case 3:
                    ShowEmp();
                    break;
                case 4:
                    ShowCd();
                    break;
                case 5:
                    ShowLivro();
                    break;
                case 6:
                    ShowRev();
                    break;
                case 7:
                    ShowRev();
                    break;
                case 8:
                    ShowPer();
                    break;
                case 9:
                    ShowFilm();
                    break;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //botao procurar
            EmptyAll();
            UnlockControls();
            button2.Show();

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







        private void editar_Click(object sender, EventArgs e)
        {
            this.guardartype = 1;
            UnlockControls();
            membro_id.Enabled = false;
            guardar.Enabled = true;
        }

        private void guardar_Click(object sender, EventArgs e)
        {
            //botao adicionar nao guardar
            this.guardartype = 0;
            EmptyAll();
            UnlockControls();
            guardar.Enabled = true;
            adicionar.Enabled = false;
            switch (currentTipo) {
                case 0:
                    membro_id.Enabled = false;
                    break;
                case 1:
                    fun_id.Enabled = false;
                    break;}
        }
       
        public void ProcurarEmprestimo() {

            if (!verifySGBDConnection())
            {
                Debug.WriteLine("no conn");
                return;
            };
            String _num =emp_num.Text;
            String _idf = emp_idf.Text;
            String _idm = emp_idmem.Text;
            String command="";
            if (!String.IsNullOrEmpty(_num) & !String.IsNullOrEmpty(_idf) & !String.IsNullOrEmpty(_idm))
            {
                command = "SELECT * FROM BiblioBD.ProcurarEmprestimoNumIDMIDF(" + _num + "," + _idm + "," + _idf + ");";
            }
            else if (!String.IsNullOrEmpty(_num) & !String.IsNullOrEmpty(_idf))
            {
                command = "SELECT * FROM BiblioBD.ProcurarEmprestimoNumIDF(" + _num + "," + _idf + ");";
            }
            else if (!String.IsNullOrEmpty(_num) & !String.IsNullOrEmpty(_idm)) {
                command = "SELECT * FROM BiblioBD.ProcurarEmprestimoNumIDM(" + _num + "," + _idm + ");";
            }
            else if (!String.IsNullOrEmpty(_idm) & !String.IsNullOrEmpty(_idf))
            {
                command = "SELECT * FROM BiblioBD.ProcurarEmprestimoIDMIDF(" + _idm + "," + _idf + ");";
            }
            else if (!String.IsNullOrEmpty(_num))
            {
                command = "SELECT * FROM BiblioBD.ProcurarEmprestimoNum(" + _num +");";
            }
            else if (!String.IsNullOrEmpty(_idm))
            {
                command = "SELECT * FROM BiblioBD.ProcurarEmprestimoIDM(" + _idm + ");";
            }
            else if (!String.IsNullOrEmpty(_idf))
            {
                command = "SELECT * FROM BiblioBD.ProcurarEmprestimoIDF(" + _idf + ");";
            }
            SqlCommand cmd = new SqlCommand(command, cn);// chamar função de add á database com cenas corretas; 
            SqlDataReader reader = cmd.ExecuteReader();
            elementos.Items.Clear();
            while (reader.Read())
            {
                Emprestimo C = new Emprestimo();
                C.Num = reader["numero"].ToString();
                C.Id1 = reader["funcionario"].ToString();
                C.Id2 = reader["membro"].ToString();
                C.Emp = reader["emprestimo"].ToString();
                C.Limite = reader["limite"].ToString();
                elementos.Items.Add(C);
            }
            cn.Close();
            this.currentEntity = 0;
            ShowEmp();
            LockControls();
            button2.Hide();
        }
        public void ProcurarMembro()
        {
            if (!verifySGBDConnection())
            {
                Debug.WriteLine("no conn");
                return;
            };
            String _id = membro_id.Text;
            String _nome = membro_nome.Text;
            String command = "";
            if (!String.IsNullOrEmpty(_id))
            {
                command = "SELECT * FROM BiblioBD.ProcurarMembro(" + _id + ");";
                
            }
            else if (!String.IsNullOrEmpty(_nome))
            {
                command = "SELECT * FROM BiblioBD.ProcurarMembroNome('" + _nome + "');";
                
            }
            SqlCommand cmd = new SqlCommand(command, cn);// chamar função de add á database com cenas corretas; 
            SqlDataReader reader = cmd.ExecuteReader();
            elementos.Items.Clear();
            while (reader.Read())
            {
                Membro C = new Membro();
                C.Id = reader["id"].ToString();
                C.Nome = reader["nome"].ToString();
                C.Email = reader["email"].ToString();
                C.Nif = reader["Nif"].ToString();
                C.Nascimento = reader["nascimento"].ToString();
                C.Morada = reader["morada"].ToString();
                elementos.Items.Add(C);
            }
            cn.Close();
            this.currentEntity = 0;
            ShowMembro();
            LockControls();
            button2.Hide();
        }
        public void EmptyAll()
        {
            membro_id.Text = "";
            membro_morada.Text = "";
            membro_nome.Text = "";
            membro_nif.Text = "";
            membro_email.Text = "";
            membro_nasc.Text = "";
            fun_id.Text = "";
            fun_morada.Text = "";
            fun_nome.Text = "";
            fun_email.Text = "";
            fun_nif.Text = "";
            fun_nasc.Text = "";
            fun_ssn.Text = "";
            fun_f.Text = "";
            fun_i.Text = "";
            ger_id.Text = "";
            ger_fim.Text = "";
            ger_inicio.Text = "";
            livro_id.Text = "";
            livro_titulo.Text = "";
            livro_autor.Text = "";
            livro_editora.Text = "";
            livro_ano.Text = "";
            livro_isbn.Text = "";
            livro_genero.Text = "";
            livro_seccao.Text = "";
            revista_data.Text = "";
            revista_edicao.Text = "";
            revista_id.Text = "";
            revista_marca.Text = "";
            revista_seccao.Text = "";
            revista_tipo.Text = "";
            filme_id.Text = "";
            filme_seccao.Text = "";
            filme_realizador.Text = "";
            filme_genero.Text = "";
            filme_ano.Text = "";
            filme_titulo.Text = "";
            cd_id.Text = "";
            cd_artista.Text = "";
            cd_genero.Text = "";
            cd_ano.Text = "";
            cd_titulo.Text = "";
            cd_seccao.Text = "";
            emp_num.Text = "";
            emp_idf.Text = "";
            emp_dataemp.Text = "";
            emp_idmem.Text = "";
            emp_limite.Text = "";
        }
        public void LockControls()
        {
            membro_id.ReadOnly = true;
            membro_morada.ReadOnly = true;
            membro_nome.ReadOnly = true;
            membro_nif.ReadOnly = true;
            membro_email.ReadOnly = true;
            membro_nasc.Enabled = false;
            fun_id.ReadOnly = true;
            fun_morada.ReadOnly = true;
            fun_nome.ReadOnly = true;
            fun_email.ReadOnly = true;
            fun_nif.ReadOnly = true;
            fun_nasc.Enabled = false;
            fun_ssn.ReadOnly = true;
            fun_f.Enabled = false;
            fun_i.Enabled = false;
            ger_id.ReadOnly = true;
            ger_fim.Enabled = false;
            ger_inicio.Enabled = false;
            livro_id.ReadOnly = true;
            livro_titulo.ReadOnly = true;
            livro_autor.ReadOnly = true;
            livro_editora.ReadOnly = true;
            livro_ano.ReadOnly = true;
            livro_isbn.ReadOnly = true;
            livro_genero.ReadOnly = true;
            livro_seccao.ReadOnly = true;
            revista_data.Enabled = false;
            revista_edicao.ReadOnly = true;
            revista_id.ReadOnly = true;
            revista_marca.ReadOnly = true;
            revista_seccao.ReadOnly = true;
            revista_tipo.ReadOnly = true;
            filme_id.ReadOnly = true;
            filme_seccao.ReadOnly = true;
            filme_realizador.ReadOnly = true;
            filme_genero.ReadOnly = true;
            filme_ano.ReadOnly = true;
            filme_titulo.ReadOnly = true;
            cd_id.ReadOnly = true;
            cd_artista.ReadOnly = true;
            cd_genero.ReadOnly = true;
            cd_ano.ReadOnly = true;
            cd_titulo.ReadOnly = true;
            cd_seccao.ReadOnly = true;


        }
        public void UnlockControls()
        {
            membro_id.ReadOnly = false;
            membro_morada.ReadOnly = false;
            membro_nome.ReadOnly = false;
            membro_nif.ReadOnly = false;
            membro_email.ReadOnly = false;
            membro_nasc.Enabled = true;
            fun_id.ReadOnly = false;
            fun_morada.ReadOnly = false;
            fun_nome.ReadOnly = false;
            fun_email.ReadOnly = false;
            fun_nif.ReadOnly = false;
            fun_nasc.Enabled = true;
            fun_ssn.ReadOnly = false;
            fun_f.Enabled = true;
            fun_i.Enabled = true;
            ger_id.ReadOnly = false;
            ger_fim.Enabled = true;
            ger_inicio.Enabled = true;
            livro_id.ReadOnly = false;
            livro_titulo.ReadOnly = false;
            livro_autor.ReadOnly = false;
            livro_editora.ReadOnly = false;
            livro_ano.ReadOnly = false;
            livro_isbn.ReadOnly = false;
            livro_genero.ReadOnly = false;
            livro_seccao.ReadOnly = false;
            revista_data.Enabled = true;
            revista_edicao.ReadOnly = false;
            revista_id.ReadOnly = false;
            revista_marca.ReadOnly = false;
            revista_seccao.ReadOnly = false;
            revista_tipo.ReadOnly = false;
            filme_id.ReadOnly = false;
            filme_seccao.ReadOnly = false;
            filme_realizador.ReadOnly = false;
            filme_genero.ReadOnly = false;
            filme_ano.ReadOnly = false;
            filme_titulo.ReadOnly = false;
            cd_id.ReadOnly = false;
            cd_artista.ReadOnly = false;
            cd_genero.ReadOnly = false;
            cd_ano.ReadOnly = false;
            cd_titulo.ReadOnly = false;
            cd_seccao.ReadOnly = false;
        }

        private void guardar_Click_1(object sender, EventArgs e)
        {
            adicionar.Enabled = true;
            if (guardartype == 0) {
                //viemos do adicionar
                if (currentTipo == 0)
                {
                    AdicionarMembro();
                }
                if (currentTipo == 1)
                {
                    
                    AdicionarFunc();
                }
            }
            if (guardartype == 1) {
                //viemos do editar
                if (currentTipo == 0)
                { 
                    EditarMembro();
                }
            }
           
            
        }
        private void EditarMembro() {
            if (!verifySGBDConnection())
            {
                Debug.WriteLine("no conn");
                return;
            }
            
            SqlCommand cmd = new SqlCommand("BiblioBD.EditarMembro", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", membro_id.Text));
            cmd.Parameters.Add(new SqlParameter("@nome", membro_nome.Text));
            cmd.Parameters.Add(new SqlParameter("@email", membro_email.Text));
            cmd.Parameters.Add(new SqlParameter("@morada", membro_morada.Text));
            cmd.Parameters.Add(new SqlParameter("@nascimento", membro_nasc.Value.ToString("yyyy-MM-dd")));
            cmd.Parameters.Add(new SqlParameter("@NIF", membro_nif.Text));
            cmd.ExecuteNonQuery();
            cn.Close();
            loadMemberData();
            membro_id.Enabled = true;
            guardar.Enabled = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //botao de concluir pesquisa
            //vai chamar o pesquisar membros
            if (currentTipo == 0) {
                ProcurarMembro();
            }
            if (currentTipo == 3) {
                ProcurarEmprestimo();
            }
        }

        
        private void AdicionarMembro() {
            if (!verifySGBDConnection())
            {
                Debug.WriteLine("no conn");
                return;
            }
            SqlCommand cmd = new SqlCommand("BiblioBD.AdicionarMembro", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@nome", membro_nome.Text));
            cmd.Parameters.Add(new SqlParameter("@email", membro_email.Text));
            cmd.Parameters.Add(new SqlParameter("@morada", membro_morada.Text));
            cmd.Parameters.Add(new SqlParameter("@nascimento", membro_nasc.Value.ToString("yyyy-MM-dd")));
            cmd.Parameters.Add(new SqlParameter("@NIF", membro_nif.Text));
            cmd.ExecuteNonQuery();
            cn.Close();
            loadMemberData();
            membro_id.Enabled = true;
            

        }
        private void EliminarMembro()
        {
            string message = "Deseja mesmo eliminar este membro?";
            string caption = "Confirme";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                if (!verifySGBDConnection())
                {
                    Debug.WriteLine("no conn");
                    return;
                }
                Membro m = new Membro();
                m = (Membro)elementos.Items[elementos.SelectedIndex];
                SqlCommand cmd = new SqlCommand("BiblioBD.EliminarMembro", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@id", m.Id));
                cmd.ExecuteNonQuery();
                cn.Close();
                loadMemberData();
                membro_id.Enabled = true;
            }
            
        }
        private void AdicionarFunc()
        {
            try
            {
                if (!verifySGBDConnection())
                {
                    Debug.WriteLine("no conn");
                    return;
                };
                Debug.WriteLine("ahh");
                SqlCommand cmd = new SqlCommand("BiblioBD.AdicionarFunc", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@nome", fun_nome.Text));
                cmd.Parameters.Add(new SqlParameter("@email", fun_email.Text));
                cmd.Parameters.Add(new SqlParameter("@morada", fun_morada.Text));
                cmd.Parameters.Add(new SqlParameter("@nascimento", fun_nasc.Value.ToString("yyyy-MM-dd")));
                cmd.Parameters.Add(new SqlParameter("@NIF", fun_nif.Text));
                cmd.Parameters.Add(new SqlParameter("@ssn", fun_ssn.Text));
                cmd.Parameters.Add(new SqlParameter("@inicio", fun_i.Value.ToString("yyyy-MM-dd")));
                cmd.Parameters.Add(new SqlParameter("@fim", fun_f.Value.ToString("yyyy-MM-dd")));
                cmd.ExecuteNonQuery();
                cn.Close();
                loadFuncData();
                fun_id.Enabled = true;
            }
            catch {
                System.Windows.Forms.MessageBox.Show("Datas incorretas.Tente de novo.");
            }

        }
        
        private void EliminarFunc()
        {
            string message = "Deseja mesmo eliminar este funcionario?";
            string caption = "Confirme";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(message, caption, buttons);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                if (!verifySGBDConnection())
            {
                Debug.WriteLine("no conn");
                return;
            }
            Funcionario m = new Funcionario();
            m = (Funcionario)elementos.Items[elementos.SelectedIndex];
            SqlCommand cmd = new SqlCommand("BiblioBD.EliminarFunc", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@id", m.Id));
            cmd.ExecuteNonQuery();
            cn.Close();
            loadFuncData();
            fun_id.Enabled = true;
            }
        }
        private void eliminar_Click(object sender, EventArgs e)
        {
            if (currentTipo == 0) {
                EliminarMembro();
            }
            if (currentTipo == 1) {
                EliminarFunc();
            }

        }

    }
}
