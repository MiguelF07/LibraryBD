using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryBD
{
    public class Filme
    {
		private String _id;
		private String _seccao;
		private String _realizador;
		private String _genero;
		private String _ano;
		private String _titulo;
        private String _disp;
        public string Id { get => _id; set => _id = value; }
        public string Seccao { get => _seccao; set => _seccao = value; }
        public string Realizador { get => _realizador; set => _realizador = value; }
        public string Genero { get => _genero; set => _genero = value; }
        public string Ano { get => _ano; set => _ano = value; }
        public string Titulo { get => _titulo; set => _titulo = value; }
        public string Disp { get => _disp; set => _disp = value; }

        public override String ToString()
        {
            return _id + "   " + _titulo; // mudar string que vai aparecer na lista
        }
        public Filme() : base()
        {
        }
    }
}
