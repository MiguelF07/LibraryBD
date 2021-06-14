using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryBD
{
    [Serializable()]
    class Gerente
    {
        private String _id;
        private String _inicio;
        private String _fim;

        public string Id { get => _id; set => _id = value; }
        public string Inicio { get => _inicio; set => _inicio = value; }
        public string Fim { get => _fim; set => _fim = value; }
        public override String ToString()
        {
            return _id; // mudar string que vai aparecer na lista
        }
        public Gerente() : base()
        {
        }
    }

}
