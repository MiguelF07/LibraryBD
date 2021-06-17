using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryBD
{
    class Atividade
    {
        private String _nome;
        private String _tipo;
        private String _data;
        private String _hora;

        public string Nome { get => _nome; set => _nome = value; }
        public string Tipo { get => _tipo; set => _tipo = value; }
        public string Data { get => _data; set => _data = value; }
        public string Hora { get => _hora; set => _hora = value; }
        public override String ToString()
        {
            return _tipo + " : "+ _nome; // mudar string que vai aparecer na lista
        }
    }
}
