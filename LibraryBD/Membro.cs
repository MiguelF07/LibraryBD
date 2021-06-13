using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryBD
{   
    [Serializable()]
    public class Membro
    {
        private String _id;
        private String _nome;
        private String _morada;
        private String _mail;
        private String _nif;
        private String _nascimento;

        public string Id { get => _id; set => _id = value; }
        public string Nome { get => _nome; set => _nome = value; }
        public string Morada { get => _morada; set => _morada = value; }
        public string Mail { get => _mail; set => _mail = value; }
        public string Nif { get => _nif; set => _nif = value; }
        public string Nascimento { get => _nascimento; set => _nascimento = value; }
    
    public override String ToString()
    {
        return _id + "   " + _nome;
    }

    public Membro() : base()
    {
    }

    public Membro(String Morada, String Name) : base()
    {
        this._nome = Name;
        this._morada = Morada;
    }

    public Membro(String Name) : base()
    {
        this._nome = Name;
    }
    }
}
