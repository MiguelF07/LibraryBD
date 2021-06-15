using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryBD
{
    public class Perifericos
    {
        private String _id;
        private String _marca;
        private String _modelo;
        private String _tipo;

        public string Id { get => _id; set => _id = value; }
        public string Marca { get => _marca; set => _marca = value; }
        public string Modelo { get => _modelo; set => _modelo = value; }
        public string Tipo { get => _tipo; set => _tipo = value; }

        public override String ToString()
        {
            return _id + "   " + _marca + "   " + _modelo; // mudar string que vai aparecer na lista
        }
        public Perifericos() : base()
        {
        }
    }
}