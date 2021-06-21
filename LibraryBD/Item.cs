using System;

namespace LibraryBD
{
    [Serializable()]
    class Item
    {
        private String _id;
        private String _nome;
        public string Id { get => _id; set => _id = value; }
        public string Nome { get => _nome; set => _nome = value; }

        public override String ToString()
        {
            return _id + " " + _nome; // mudar string que vai aparecer na lista
        }
    }

}
