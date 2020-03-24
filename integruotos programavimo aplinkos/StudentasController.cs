using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace integruotos_programavimo_aplinkos
{
    class StudentasController
    {
        public List<Studentas> sarasas;

        public StudentasController() {
            sarasas = new List<Studentas>();
        }

        public void meniu()
        {
            Console.WriteLine("Pasirinkite ka norite daryti");
            Console.WriteLine("1. Prideti nauja studenta");
            Console.WriteLine("2. Isvesti studentu ir ju vidurkiu sarasa");
            Console.WriteLine("3. Ivesti egzamino rezultatus");
            Console.WriteLine("4. Ivesti namu darbu rezultatus");
            Console.WriteLine("5. Atsitiktinai priskirti pazymi studentui");
            Console.WriteLine("0. Baigti darba");
            int a = int.Parse(Console.ReadLine());
            switch (a)
            {
                case 1:
                    this.pridetiStudenta();
                    this.meniu();
                    break;
                case 2:
                    this.isvestiSarasa();
                    this.meniu();
                    break;
                case 3:
                    this.ivestiEgzamina();
                    this.meniu();
                    break;
                case 4:
                    this.ivestiNamuDarbus();
                    this.meniu();
                    break;
                case 5:
                    this.atsitiktiniaiPazymiai();
                    this.meniu();
                    break;
                case 0:
                    break;
                default:
                    Console.WriteLine("ivedete netinkama skaiciu");
                    this.meniu();
                    break;
            }

            
        }

        public void pridetiStudenta()
        {
            this.sarasas.Add(new Studentas());
        }

        public void isvestiSarasa()
        {
            int a = 1;
            foreach(var stud in this.sarasas)
            {
                Console.WriteLine(a + ". " + stud.getVardas() + " " + stud.getPavarde() + " " + stud.getEgzaminas());
                a++;
            }
        }

        public void ivestiEgzamina()
        {
            this.isvestiSarasa();
            Console.WriteLine("Pasirinkite studenta");
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine("Iveskite egzamino pazymi [1-10]");
            int a = int.Parse(Console.ReadLine());
            this.sarasas[b - 1].setEgzaminas(a);

        }

        public void ivestiNamuDarbus()
        {

        }

        public void atsitiktiniaiPazymiai()
        {

        }
    }
}
