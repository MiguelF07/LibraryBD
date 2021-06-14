using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryBD
{
    [Serializable()]
    class Revista
    {
        private String _id;
        private String _seccao;
        private String _marca;
        private String _tipo;
        private String _dataL;
        private String _edicao;

        public string Id { get => _id; set => _id = value; }
        public string Seccao { get => _seccao; set => _seccao = value; }
        public string Marca { get => _marca; set => _marca = value; }
        public string Tipo { get => _tipo; set => _tipo = value; }
        public string DataL { get => _dataL; set => _dataL = value; }
        public string Edicao { get => _edicao; set => _edicao = value; }
        public override String ToString()
        {
            return _id + "   " + _marca; // mudar string que vai aparecer na lista
        }
        public Revista() : base()
        {
        }
    }
}
