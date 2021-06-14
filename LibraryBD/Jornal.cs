using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryBD
{
    public class Jornal
    {
		private String _id;
		private String _seccao;
		private String _marca;
		private String _tipo;
		private String _data;
		private String _edicao;

        public string Id { get => _id; set => _id = value; }
        public string Seccao { get => _seccao; set => _seccao = value; }
        public string Marca { get => _marca; set => _marca = value; }
        public string Tipo { get => _tipo; set => _tipo = value; }
        public string Data { get => _data; set => _data = value; }
        public string Edicao { get => _edicao; set => _edicao = value; }

        public Jornal() : base()
        {
        }
        public override String ToString()
        {
            return _id + "   " + _marca; // mudar string que vai aparecer na lista
        }
    }
}
