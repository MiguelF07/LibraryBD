using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryBD
{
    [Serializable()]
    class Emprestimo
    {
        private String _num;
        private String _id1;
        private String _id2;
        private String _inicio;
        private String _fim;

        public string Num { get => _num; set => _num = value; }
        public string Id1 { get => _id1; set => _id1 = value; }
        public string Id2 { get => _id2; set => _id2 = value; }
        public string Emp { get => _inicio; set => _inicio = value; }
        public string Limite { get => _fim; set => _fim = value; }
        public override String ToString()
        {
            return _num; // mudar string que vai aparecer na lista
        }
        public Emprestimo() : base()
        {
        }
    }
}
