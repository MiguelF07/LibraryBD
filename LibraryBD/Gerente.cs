using System;

namespace LibraryBD
{
    [Serializable()]
    class Gerente
    {
        private String _id;
        private String _inicio;
        private String _fim;
        private String _nome;

        public string Id { get => _id; set => _id = value; }
        public string Inicio { get => _inicio; set => _inicio = value; }
        public string Fim { get => _fim; set => _fim = value; }
        public string Nome { get => _nome; set => _nome = value; }

        public override String ToString()
        {
            return _id+" "+_nome; // mudar string que vai aparecer na lista
        }
        public Gerente() : base()
        {
        }
    }

}
