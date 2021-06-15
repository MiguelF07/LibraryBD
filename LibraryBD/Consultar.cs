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
        private int currentEntity;
        private int currentTipo;
        public Consultar()
        {
            Debug.WriteLine("Init");
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
        /*private void Consultar_Load(Object sender, EventArgs e)
        {
            Debug.WriteLine("load entered");
            cn = getSGBDConnection();
            Debug.WriteLine("Conexão efetuada");
            loadMembersToolStripMenuItem_Click(sender, e);
        }*/
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
        private void loadMembersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Cheguei a funcao load");
            if (!verifySGBDConnection())
            {
                Debug.WriteLine("no conn");
                return;
            };

            //Fazer switch(?) para sabermos qual queremos apresentar
            Debug.WriteLine("Começar a carregar");
            
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
                C.Nome = reader["nome"].ToString();
                C.Email = reader["email"].ToString();
                C.Nif = reader["Nif"].ToString();
                C.Nascimento= reader["nascimento"].ToString();
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
                C.Ssn= reader["ssn"].ToString();
                C.Inicio= reader["inicio"].ToString();
                C.Fim= reader["fim"].ToString();
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
            gerente.Show();
            SqlCommand cmd = new SqlCommand("SELECT * FROM BiblioBD.gerente", cn);

            SqlDataReader reader = cmd.ExecuteReader();
            elementos.Items.Clear();
            while (reader.Read())
            {
                Gerente C = new Gerente();
                C.Id = reader["id"].ToString();
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
        public void ShowManag() {
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
            ShowEmpres(); 
            LockControls();
            editar.Enabled = false;
            adicionar.Enabled = false;
            eliminar.Enabled = false;
        }
        public void ShowEmpres() {
            if (elementos.Items.Count == 0 | currentEntity < 0)
                return;
            Emprestimo e = new Emprestimo();
            e = (Emprestimo)elementos.Items[currentEntity];
            emp_num.Text = e.Num;
            emp_idf.Text = e.Id1;
            emp_idmem.Text = e.Id2;
            emp_limite.Text = e.Limite;
            emp_dataemp.Text = e.Emp;
        }
        private void loadJornData()
        {
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
            revista.Show();
            SqlCommand cmd = new SqlCommand("SELECT * FROM BiblioBD.revistas", cn);

            SqlDataReader reader = cmd.ExecuteReader();
            elementos.Items.Clear();
            while (reader.Read())
            {
                Revista C = new Revista();
                C.DataL= reader["dataL"].ToString();
                C.Edicao= reader["edicao"].ToString();
                C.Id= reader["id"].ToString();
                C.Marca= reader["marca"].ToString();
                C.Seccao= reader["seccao"].ToString();
                C.Tipo= reader["tipo"].ToString();
                elementos.Items.Add(C);
                //etc etc etc
                //...
            }
            cn.Close();
            this.currentEntity = 0;
            ShowRev(); 
            LockControls();
        }
        public void ShowRev() {
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
        }

        private void loadFilmData()
        {
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
            Filme f = new Filme();
            f = (Filme)elementos.Items[currentEntity];
            filme_id.Text = f.Id;
            filme_seccao.Text = f.Seccao;
            filme_realizador.Text = f.Realizador;
            filme_genero.Text = f.Genero;
            filme_ano.Text = f.Ano;
            filme_titulo.Text = f.Titulo;
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
            LockControls();
        }

        private void loadCdData()
        {
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
        }

        private void loadLivroData()
        {
            Debug.WriteLine("cheguei ao load livro");
            livro.Show();
            SqlCommand cmd = new SqlCommand("SELECT * FROM BiblioBD.livro", cn);
            Debug.WriteLine("fiz o select do load livro");

            SqlDataReader reader = cmd.ExecuteReader();
            elementos.Items.Clear();
            while (reader.Read())
            {
                Debug.WriteLine("Estou no while");
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
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!verifySGBDConnection())
            {
                Debug.WriteLine("no conn");
                return;
            };
            HideAll();
            currentTipo = tipo.SelectedIndex;
            switch (currentTipo) {
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
            }
        }
        private void elementos_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            currentEntity = elementos.SelectedIndex;
            Debug.WriteLine(currentTipo);
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
                    ShowEmpres();
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
                /*case 8:
                    ShowPer();
                    break;*/
            }

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





private void button2_Click(object sender, EventArgs e)
{
loadMembersToolStripMenuItem_Click(
    sender, e);
}

private void editar_Click(object sender, EventArgs e)
{
UnlockControls();
}

private void guardar_Click(object sender, EventArgs e)
{
LockControls();
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
}
}
