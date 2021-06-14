using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryBD
{
    [Serializable()]
    public class Funcionario
    {

        private String _id;
        private String _nome;
        private String _morada;
        private String _email;
        private String _nif;
        private String _nascimento;
        private String _ssn;
        private String _inicio;
        private String _fim;

        public string Id { get => _id; set => _id = value; }
        public string Nome { get => _nome; set => _nome = value; }
        public string Morada { get => _morada; set => _morada = value; }
        public string Email { get => _email; set => _email = value; }
        public string Nif { get => _nif; set => _nif = value; }
        public string Nascimento
        {
            get => _nascimento; set => _nascimento = value;
        }
        public string Ssn { get => _ssn; set => _ssn = value; }
        public string Inicio { get => _inicio; set => _inicio = value; }
        public string Fim { get => _fim; set => _fim = value; }
    
    public override String ToString()
    {
        return _id + "   " + _nome; // mudar string que vai aparecer na lista
    }

    public Funcionario() : base()
    {
    }

    public Funcionario(String Name) : base()
    {
        this._nome = Name;
    }
    }
}
