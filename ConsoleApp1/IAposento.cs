using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public interface IAposento
    {
        public string nombre { get; set; }
        public decimal medida { get; set; }

        public List<string> muebles { get; set; }
    }
}
