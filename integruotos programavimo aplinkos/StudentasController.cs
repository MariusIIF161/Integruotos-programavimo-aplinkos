﻿using System;
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
                    this.isvestiSarasa(this.medOrVid());
                    this.meniu();
                    break;
                case 3:
                    this.ivestiEgzamina(this.pasirinktiStudenta());
                    this.meniu();
                    break;
                case 4:
                    this.ivestiNamuDarbus(this.pasirinktiStudenta());
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

        public String medOrVid()
        {
            Console.WriteLine("Pasirinkite isvesti pagal mediana ar vidurki (ivedus bloga skaiciu automatiskai pasirenkamas vidurkis)");
            Console.WriteLine("1. Mediana");
            Console.WriteLine("2. Vidurki");
            if (Console.ReadLine() == "1") return "Med";
            return "Vid";
        }

        public void isvestiSarasa(string formatas)
        {
            int a = 1;
            foreach(var stud in this.sarasas)
            {
                // galutinis = 0.3 * (vidurkis arba mediana) + 0.7 * egzaminas
                double galutinis = stud.getEgzaminas() * 0.7 + 0.3 * this.vidurkis(formatas, stud.getND());
                Console.WriteLine(a + ". " + stud.getVardas() + " " + stud.getPavarde() + " " + galutinis);
                a++;
            }
        }

        public double vidurkis(string formatas, List<int> nd)
        {
            double vidurkis = 0;
            int sk = nd.Count();
            if (formatas == "Med") {
                nd.Sort();
                if(sk % 2 == 0)
                {
                    int temp = nd[sk / 2] + nd[sk / 2 - 1];
                    vidurkis = temp / 2;
                } else
                {
                    int temp = nd[sk / 2 + 1];
                    vidurkis = temp;
                }   
            } else {
                foreach (var paz in nd)
                {
                    vidurkis += paz;
                }
                if (sk != 0) vidurkis = vidurkis / sk;
            }
            return vidurkis;
        }

        public int pasirinktiStudenta()
        {
            this.isvestiSarasa("Vid");
            Console.WriteLine("Pasirinkite studenta");
            int b = int.Parse(Console.ReadLine());
            return b;
        }

        public void ivestiEgzamina(int stud)
        {
            Console.WriteLine("Iveskite egzamino pazymi [1-10]");
            int a = int.Parse(Console.ReadLine());
            this.sarasas[stud - 1].setEgzaminas(a);

        }

        public void ivestiNamuDarbus(int stud)
        {
            Console.WriteLine("Irasikyte namu darbo pazymy [1-10]");
            int a = int.Parse(Console.ReadLine());
            this.sarasas[stud - 1].setNewPazimys(a);

        }

        public void atsitiktiniaiPazymiai()
        {

        }
    }
}
