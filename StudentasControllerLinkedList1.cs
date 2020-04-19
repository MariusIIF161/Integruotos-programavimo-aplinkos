using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;


namespace integruotos_programavimo_aplinkos
{
    class StudentasController
    {
        public LinkedList<Studentas> sarasas;
        public LinkedList<Studentas> geri;
        public LinkedList<Studentas> blogi;

        public StudentasController() {
            sarasas = new LinkedList<Studentas>();
            geri = new LinkedList<Studentas>();
            blogi = new LinkedList<Studentas>();
            this.nuskaitytIsFailo("studentai.txt");
        }

        public void meniu()
        {
            Stopwatch sw = new Stopwatch();
            Console.WriteLine("Pasirinkite ka norite daryti");
            Console.WriteLine("1. Prideti nauja studenta");
            Console.WriteLine("2. Isvesti studentu ir ju vidurkiu sarasa");
            Console.WriteLine("3. Ivesti egzamino rezultatus");
            Console.WriteLine("4. Ivesti namu darbu rezultatus");
            Console.WriteLine("5. Atsitiktinai priskirti pazymi studentui");
            Console.WriteLine("6. Sugeneruoti faila su studentais [1-10000000]");
            Console.WriteLine("7. Iskirstyti gerus ir blogus studentus");
            Console.WriteLine("8. Isvesti isskirstytus studentus i faila");
            Console.WriteLine("0. Baigti darba");
            int a = int.Parse(Console.ReadLine());
            switch (a)
            {
                case 1:
                    sw.Start();
                    this.pridetiStudenta();
                    sw.Stop();
                    Console.WriteLine(sw.Elapsed);
                    this.meniu();
                    break;
                case 2:
                    sw.Start();
                    this.isvestiSarasa(this.medOrVid());
                    sw.Stop();
                    Console.WriteLine(sw.Elapsed);
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
                    this.atsitiktiniaiPazymiai(this.pasirinktiStudenta());
                    this.meniu();
                    break;
                case 6:
                    Console.WriteLine("Kiek studentu sugeneruoti?");
                    String temp = Console.ReadLine();
                    this.failuGeneravimas(temp);
                    this.meniu();
                    break;
                case 7:
                    this.skirstymas();
                    this.meniu();
                    break;
                case 8:
                    this.geriBlogiIsvedimas();
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
            this.sarasas.AddLast(new Studentas());
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
            //this.sarasas = this.sarasas.OrderBy(o => o.getVardas()).ToList();
            int a = 1;
            Console.WriteLine("Vardas          Pavarde         Galutinis(" + formatas + ".)");
            //47
            for (int x = 0; x < 47; x++) Console.Write("-");
            Console.WriteLine("");
            foreach(var stud in this.sarasas)
            {
                // galutinis = 0.3 * (vidurkis arba mediana) + 0.7 * egzaminas
                double galutinis = stud.getEgzaminas() * 0.7 + 0.3 * this.vidurkis(formatas, stud.getND());
                Console.Write(stud.getVardas());
                for (int x = 0; x < 16 - stud.getVardas().Length; x++) Console.Write(" ");
                Console.Write(stud.getPavarde());
                for (int x = 0; x < 16 - stud.getPavarde().Length; x++) Console.Write(" ");
                Console.WriteLine(galutinis);
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
            Stopwatch sw = new Stopwatch();
            sw.Start();
            this.sarasas.ElementAt(stud - 1).setEgzaminas(a);
            sw.Stop();
            Console.WriteLine(sw.Elapsed);


        }

        public void ivestiNamuDarbus(int stud)
        {
            Console.WriteLine("Irasikyte namu darbo pazymy [1-10]");
            int a = int.Parse(Console.ReadLine());
            Stopwatch sw = new Stopwatch();
            sw.Start();
            this.sarasas.ElementAt(stud - 1).setNewPazimys(a);
            sw.Stop();
            Console.WriteLine(sw.Elapsed);

        }

        public void atsitiktiniaiPazymiai(int stud)
        {
            Random rnd = new Random();
            this.sarasas.ElementAt(stud - 1).setEgzaminas(rnd.Next(1, 11));
            Console.WriteLine("Kiek namu darbu pazymiu sugeneruoti? [1-100]");
            int a = int.Parse(Console.ReadLine());
            Stopwatch sw = new Stopwatch();
            sw.Start();
            while (a > 0)
            {
                this.sarasas.ElementAt(stud - 1).setNewPazimys(rnd.Next(1, 11));
                a--; 
            }
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
        }

        public void nuskaitytIsFailo(String file)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            try
            {
                String[] lines = File.ReadAllLines("studentai.txt");
                bool firstLine = true;
                foreach(String line in lines)
                {
                    String[] words = line.Split(' ');
                    if(!firstLine)
                    {
                        words = words.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                        this.sarasas.AddLast(new Studentas(words[0], words[1]));
                        for(int x=2; x<words.Length - 1;x++)
                        {
                            this.sarasas.ElementAt(this.sarasas.Count - 1).setNewPazimys(int.Parse(words[x]));
                        }
                        this.sarasas.ElementAt(this.sarasas.Count - 1).setEgzaminas(int.Parse(words[words.Length - 1]));
                    }
                    firstLine = false;
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
        }

        public void failuGeneravimas(String skaicius)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int sk = int.Parse(skaicius);
            StreamWriter writeText = new StreamWriter("studentaigen.txt");
            StreamWriter badPaz = new StreamWriter("blogi.txt");
            StreamWriter gerPaz = new StreamWriter("geri.txt");
            Random rnd = new Random();
            int a, b, c, d, e, f;
            for (int i = 1 ; i <= sk; i++)
            {
                a = rnd.Next(1, 11);
                b = rnd.Next(1, 11);
                c = rnd.Next(1, 11);
                d = rnd.Next(1, 11);
                e = rnd.Next(1, 11);
                f = rnd.Next(1, 11);
                writeText.WriteLine("Vardas" + i + " Pavarde" + i + " " + a + " " + b + " " + c + " " + d + " " + e + " " + f);
                if(((a+b+c+d+e)/5)*0.3 + f*0.7 < 5) badPaz.WriteLine("Vardas" + i + " Pavarde" + i + " " + a + " " + b + " " + c + " " + d + " " + e + " " + f);
                else gerPaz.WriteLine("Vardas" + i + " Pavarde" + i + " " + a + " " + b + " " + c + " " + d + " " + e + " " + f);
            }
            writeText.Close();
            gerPaz.Close();
            badPaz.Close();
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
        }

        public void skirstymas()
        {
            for(int x = 0; x < this.sarasas.Count; x++)
            {
                if(this.sarasas.ElementAt(x).getEgzaminas() * 0.7 + 0.3 * this.vidurkis("Vid", this.sarasas.ElementAt(x).getND()) < 5)
                {
                    blogi.AddLast(this.sarasas.ElementAt(x));
                    this.sarasas.Remove(this.sarasas.ElementAt(x));
                    x--;
                }
            }
        }

        public void geriBlogiIsvedimas()
        {
            StreamWriter badPaz = new StreamWriter("blogi.txt");
            StreamWriter gerPaz = new StreamWriter("geri.txt");
            foreach(var stud in this.sarasas)
            {
                gerPaz.WriteLine(stud.getVardas() + " " + stud.getPavarde());
            }
            foreach(var stud in this.blogi)
            {
                badPaz.WriteLine(stud.getVardas() + " " + stud.getPavarde());
            }
            badPaz.Close();
            gerPaz.Close();
        }
    }
}
