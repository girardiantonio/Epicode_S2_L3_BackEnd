using ContoCorrrente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContoCorrrente
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ContoCorrente.ContiCorrente.Add(new ContoCorrente("Alessio", "Portacci"));
            ContoCorrente.ContiCorrente.Add(new ContoCorrente("Antonio", "Girardi"));
            ContoCorrente.ContiCorrente.Add(new ContoCorrente("Nino", "Traverso"));
            ContoCorrente.ContiCorrente.Add(new ContoCorrente("Paolo", "Esposito"));

            while (ContoCorrente.Acceso)
                ContoCorrente.Menu();
        }
    }
}
