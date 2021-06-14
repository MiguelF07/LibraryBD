using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryBD
{
    [Serializable()]
    public class Livro
    {
        private String _id;
        private String _titulo;
        private String _autor;
        private String _editora;
        private String _ano;
        private String _isbn;
        private String _genero;
        private String _seccao;

        public string Id { get => _id; set => _id = value; }
        public string Titulo { get => _titulo; set => _titulo = value; }
        public string Autor { get => _autor; set => _autor = value; }
        public string Editora { get => _editora; set => _editora = value; }
        public string Ano { get => _ano; set => _ano = value; }
        public string Isbn { get => _isbn; set => _isbn = value; }
        public string Genero { get => _genero; set => _genero = value; }
        public string Seccao { get => _seccao; set => _seccao = value; }

        public Livro() : base()
        {
        }
        public override String ToString()
        {
            return _id + "   " + _titulo; // mudar string que vai aparecer na lista
        }
    }
}
