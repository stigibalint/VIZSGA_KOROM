using AutokKonzol;


List<Auto> adatok = new List<Auto>();
File.ReadAllLines("autok.csv").Skip(1).ToList().ForEach(x => adatok.Add(new Auto(x)));

Console.WriteLine($"5. feladat: {adatok.Count} autó található a listában");
Console.WriteLine($"6. feladat: {Math.Round(adatok.Average(x=> x.AtlagosAr),1)}");
Console.WriteLine("7. feladat: Az elmúlt 5 évben gyártott autók:");
adatok.Where(x => x.GyartasiEv >= DateTime.Now.Year - 5).ToList().ForEach(x => Console.WriteLine($"- {x.Marka} {x.Modell}: {x.GyartasiEv}"));
Console.WriteLine("8. feladat: legsikeresebb márkák listája az eladott darabszám alapján:");
adatok.OrderByDescending(x=> x.EladottDb).ThenBy(x => x.Marka).ToList().ForEach(x => Console.WriteLine($"- {x.Marka}: {x.EladottDb} darab"));
