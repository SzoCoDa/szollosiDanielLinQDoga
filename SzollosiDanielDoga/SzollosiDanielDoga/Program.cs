using System.Text;
using SzollosiDanielDoga;

List<Videojatek> videojatekok = new List<Videojatek>();

const string fajlut = "..\\..\\..\\data\\videogames.csv";
using StreamReader sr = new StreamReader(fajlut);
_ = sr.ReadLine();

while (!sr.EndOfStream) {
    var darabok = sr.ReadLine().Split(',');
    videojatekok.Add(new Videojatek()
    {
        Cim = darabok[0],
        Mufaj = darabok[1],
        KiadasDatum = DateTime.Parse(darabok[2]),
        AktivJatekosok = int.Parse(darabok[3]),
        Ertekeles = double.Parse(darabok[4].Replace('.', ',')),
    });
}

Console.WriteLine("Feladat 1:");
var nagyobbErtekeles = videojatekok.Count(v => v.Ertekeles > 4.5);
Console.WriteLine($"Összesen ennyi játék van 4.5-nél: {nagyobbErtekeles}");

Console.WriteLine("\n--------------------\n");

Console.WriteLine("Feladat 2:");
var legtobbenJatszott = videojatekok.MaxBy(v => v.AktivJatekosok);
Console.WriteLine($"A legtöbben játszott játék az a {legtobbenJatszott.Cim}");

Console.WriteLine("\n--------------------\n");

Console.WriteLine("Feladat 3:");
var janElottMegj = videojatekok.Any(v => (v.KiadasDatum.Month != 1 && v.KiadasDatum.Year < 2020) && (v.KiadasDatum.Day != && 1 v.KiadasDatum.Year < 2020));
Console.WriteLine(janElottMegj ? "Van ilyen játék" : "Nincs ilyen játék");

Console.WriteLine("\n--------------------\n");

Console.WriteLine("Feladat 4:");
var osszAtlag = videojatekok.Average(v => v.Ertekeles);
Console.WriteLine($"Átlagos értékelés: {osszAtlag:0.00}");

Console.WriteLine("\n--------------------\n");

Console.WriteLine("Feladat 5:");
var cybercityKereses = videojatekok.Single(v => v.Cim == "Cyber City 2077");
Console.WriteLine($"{cybercityKereses.Cim}");

Console.WriteLine("\n--------------------\n");

Console.WriteLine("Feladat 6:");
var osszesRpg = videojatekok.Where(v => v.Mufaj == "RPG").OrderByDescending(v => v.KiadasDatum);
foreach (var o in osszesRpg) { Console.WriteLine($"{o.Cim, -20} {o.KiadasDatum:yyyy.MM.dd}"); }

Console.WriteLine("\n--------------------\n");

Console.WriteLine("Feladat 7:");
var legjobbHarom = videojatekok.OrderByDescending(v => v.Ertekeles).Take(3);
foreach (var l in legjobbHarom){ Console.WriteLine($"{l.Cim, -25} {l.Ertekeles}"); }

Console.WriteLine("\n--------------------\n");

Console.WriteLine("Feladat 8:");
var atlagJatekosSzam = videojatekok.Where(v => v.KiadasDatum.Year >= 2022).Average(v => v.AktivJatekosok);
Console.WriteLine($"Átlag aktív játékosok 2022-es/utáni játékoknál {atlagJatekosSzam:0}");

Console.WriteLine("\n--------------------\n");

Console.WriteLine("Feladat 9:");
var mufajSzamolas = videojatekok.GroupBy(v => v.Mufaj);
foreach (var m in mufajSzamolas) { Console.WriteLine($"{m.Key, -15} {m.Count(v => v.Mufaj == m.Key)}"); } ;

Console.WriteLine("\n--------------------\n");

Console.WriteLine("Feladat 10:");

var mufajLegjobbja = videojatekok.GroupBy(v => v.Mufaj);
foreach (var m in mufajLegjobbja)
{
    Console.WriteLine($"{m.Key, -10}: {m.Where(v => v.Mufaj == m.Key).MaxBy(v => v.Ertekeles).Cim, -17} : {m.Where(v => v.Mufaj == m.Key).MaxBy(v => v.Ertekeles).Ertekeles}");
}