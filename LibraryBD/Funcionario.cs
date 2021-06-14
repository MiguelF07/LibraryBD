﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryBD
{
    [Serializable()]
    public class Funcionario
    {
SSN
Mail
Morada
Nasc
NIF
FK_Bibl
Inicio
Fim

        private String _id;
        private String _nome;
        private String _morada;
        private String _email;
        private String _nif;
        private String _nascimento;

        public string Id { get => _id; set => _id = value; }
        public string Nome { get => _nome; set => _nome = value; }
        public string Morada { get => _morada; set => _morada = value; }
        public string Email { get => _email; set => _email = value; }
        public string Nif { get => _nif; set => _nif = value; }
        public string Nascimento
        {
            get => _nascimento; set => _nascimento = value;
        }
}
