using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Sala : IAposento
    {
        public string nombre { get; set; }
        public decimal medida { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<string> muebles { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
