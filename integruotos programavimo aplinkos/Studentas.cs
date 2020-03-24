using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace integruotos_programavimo_aplinkos
{
    class Studentas
    {
        private String vardas;
        private String pavarde;
        private List<int> nd;
        private int egzaminas;

        public Studentas ()
        {
            Console.WriteLine("Iveskite varda");
            vardas = Console.ReadLine();
            Console.WriteLine("Iveskite pavarde");
            pavarde = Console.ReadLine();
        }


    }
}
