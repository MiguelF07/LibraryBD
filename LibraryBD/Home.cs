using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryBD
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        { //botao consultar
            Consultar cons = new Consultar();
            cons.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //botao reservar
            Reservar cons = new Reservar();
            cons.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void entregar_Click(object sender, EventArgs e)
        {
            //botao entregar
            Entregar cons = new Entregar();
            cons.ShowDialog();
        }

        private void atividades_Click(object sender, EventArgs e)
        {
            //botao atividades
            Atividades cons = new Atividades();
            cons.ShowDialog();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            //botao info
            Infobibl cons = new Infobibl();
            cons.ShowDialog();
        }
    }
}
