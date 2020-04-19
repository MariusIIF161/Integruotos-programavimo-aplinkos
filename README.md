# Integruotos-programavimo-aplinkos

v0.1

- List'as
- Matematinis vidurkis/Mediana isvedimas
- atsitiktinis pazymiu generavimas
- Studento pridejimas
- Namu darbu, egzaminu ivedimas
- Studento klase

v0.2(turi ir 0.3 reikalavimus)

- Exception'ai
- Pasirinkimas tarp medianos ar vidurkio
- Nuskaitymas is failo 'studentai.txt'

v0.4

- sugeneruojamas failas su iki 10 milijonu sabloniniu studentu su pazymiais
- studentu isskirstimas i blogus ir gerus
- atlikta failu generavimo spartos analize

v0.5

-List:
- Prideti studenta 0.4s-0.7s
- Pazymio egzamino ivedimas .0000013s
- Pazymio namu darbo rezultatas .0000015s
- atsitiktiniai pazymiai 100 namu darbu pazymiu .0000069s
- failo nuskaitymas (pavyzdinis failas moodle) 0.53s
- vidurkiu isvedimas su pavyzdinio failo studentais 42.008s

-LinkedList:
- Prideti studenta 0.4s-0.7s
- Pazymio egzamino ivedimas  .000002s
- Pazymio namu darbo rezultatas .0000021s
- atsitiktiniai pazymiai 100 namu darbu pazymiu .0000144s
- failo nuskaitymas (pavyzdinis failas moodle) - laukiau virs 10 minuciu nenuskaite, su kitu failu kur yra 2 studentai uztruko 0.0007s
- vidurkiu isvedimas su pavyzdinio failo studentais - kadangi pavyzdinio failo nepamatavau, dvieju studentu failo vidurki isvede per 0.4845s

-Queue:
- Prideti studenta 0.4s-0.7s
- Pazymio egzamino ivedimas .0000022s
- Pazymio namu darbo rezultatas .0000023s
- atsitiktiniai pazymiai 100 namu darbu pazymiu .0000137
- failo nuskaitymas (pavyzdinis failas moodle) 4:57.008
- vidurkiu isvedimas su pavyzdinio failo studentais 40.685s

Mano realizacija veika su visais trijais konteineriais, tačiau kadangi pradžioje buvo kuriama List konteiniariui nera keista, kad List konteineris buvo greičiausias kada realizacija buvo orentuota i List konteineri

v1.0

- Realizuota trys konteineriu tipai dviejomis strategijomis
