using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsandoDapper
{
    public class Familiar
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNasc { get; set; }

        public IEnumerable<Contato> Contatos { get; set; }
    }
}
