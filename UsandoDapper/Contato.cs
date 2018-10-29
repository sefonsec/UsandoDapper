using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsandoDapper
{
    public class Contato
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Logradouro { get; set; }

        public Familiar Familiar { get; set; }
    }
}
