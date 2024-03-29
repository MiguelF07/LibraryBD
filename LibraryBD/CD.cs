﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryBD
{
    public class CD
    {
        private String _id;
        private String _artista;
        private String _genero;
        private String _ano;
        private String _titulo;
        private String _seccao;
        private String _disp;
        public string Id { get => _id; set => _id = value; }
        public string Artista { get => _artista; set => _artista = value; }
        public string Genero { get => _genero; set => _genero = value; }
        public string Ano { get => _ano; set => _ano = value; }
        public string Titulo { get => _titulo; set => _titulo = value; }
        public string Seccao { get => _seccao; set => _seccao = value; }
        public string Disp { get => _disp; set => _disp = value; }

        public override String ToString()
        {
            return _id + "   " + _titulo; // mudar string que vai aparecer na lista
        }
        public CD() : base()
        {
        }
    }
}
