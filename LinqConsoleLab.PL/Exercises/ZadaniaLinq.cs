using System.Data;
using LinqConsoleLab.PL.Data;
using LinqConsoleLab.PL.Models;

namespace LinqConsoleLab.PL.Exercises;

public sealed class ZadaniaLinq {
    /// <summary>
    /// Zadanie:
    /// Wyszukaj wszystkich studentów mieszkających w Warsaw.
    /// Zwróć numer indeksu, pełne imię i nazwisko oraz miasto.
    ///
    /// SQL:
    /// SELECT NumerIndeksu, Imie, Nazwisko, Miasto
    /// FROM Studenci
    /// WHERE Miasto = 'Warsaw';
    /// </summary>
    public IEnumerable<string> Zadanie01_StudenciZWarszawy() {
        // throw Niezaimplementowano(nameof(Zadanie01_StudenciZWarszawy));
        return
            from student in DaneUczelni.Studenci
            where student.Miasto == "Warsaw"
            select student.NumerIndeksu + " " + student.Imie + " " + student.Nazwisko + " -- " + student.Miasto;

    }

    /// <summary>
    /// Zadanie:
    /// Przygotuj listę adresów e-mail wszystkich studentów.
    /// Użyj projekcji, tak aby w wyniku nie zwracać całych obiektów.
    ///
    /// SQL:
    /// SELECT Email
    /// FROM Studenci;
    /// </summary>
    public IEnumerable<string> Zadanie02_AdresyEmailStudentow() {
        // throw Niezaimplementowano(nameof(Zadanie02_AdresyEmailStudentow));
        return
            from student in DaneUczelni.Studenci
            select student.Email;
    }

    /// <summary>
    /// Zadanie:
    /// Posortuj studentów alfabetycznie po nazwisku, a następnie po imieniu.
    /// Zwróć numer indeksu i pełne imię i nazwisko.
    ///
    /// SQL:
    /// SELECT NumerIndeksu, Imie, Nazwisko
    /// FROM Studenci
    /// ORDER BY Nazwisko, Imie;
    /// </summary>
    public IEnumerable<string> Zadanie03_StudenciPosortowani() {
        // throw Niezaimplementowano(nameof(Zadanie03_StudenciPosortowani));
        return
            from student in DaneUczelni.Studenci
            orderby student.Nazwisko, student.Imie
            select student.NumerIndeksu + ' ' + student.Imie + ' ' + student.Nazwisko;

    }

    /// <summary>
    /// Zadanie:
    /// Znajdź pierwszy przedmiot z kategorii Analytics.
    /// Jeżeli taki przedmiot nie istnieje, zwróć komunikat tekstowy.
    ///
    /// SQL:
    /// SELECT TOP 1 Nazwa, DataStartu
    /// FROM Przedmioty
    /// WHERE Kategoria = 'Analytics';
    /// </summary>
    public IEnumerable<string> Zadanie04_PierwszyPrzedmiotAnalityczny() {
        // throw Niezaimplementowano(nameof(Zadanie04_PierwszyPrzedmiotAnalityczny));
        var query =
            from p in DaneUczelni.Przedmioty
            where p.Kategoria == "Analytics"
            select p.Nazwa + " -- " + p.DataStartu;

        if (query.Count() == 0)
            Console.WriteLine("Przedmiot nie istnieje");
            
        return query.Take(1);
    }

    /// <summary>
    /// Zadanie:
    /// Sprawdź, czy w danych istnieje przynajmniej jeden nieaktywny zapis.
    /// Zwróć jedno zdanie z odpowiedzią True/False albo Tak/Nie.
    ///
    /// SQL:
    /// SELECT CASE WHEN EXISTS (
    ///     SELECT 1
    ///     FROM Zapisy
    ///     WHERE CzyAktywny = 0
    /// ) THEN 1 ELSE 0 END;
    /// </summary>
    public IEnumerable<string> Zadanie05_CzyIstniejeNieaktywneZapisanie() {
        // throw Niezaimplementowano(nameof(Zadanie05_CzyIstniejeNieaktywneZapisanie));
        return
            DaneUczelni.Zapisy
                .Any(n => !n.CzyAktywny)
                ? new List<string>(1){"Tak"}
                : new List<string>(1){"Nie"};
    }

    /// <summary>
    /// Zadanie:
    /// Sprawdź, czy każdy prowadzący ma uzupełnioną nazwę katedry.
    /// Warto użyć metody, która weryfikuje warunek dla całej kolekcji.
    ///
    /// SQL:
    /// SELECT CASE WHEN COUNT(*) = COUNT(Katedra)
    /// THEN 1 ELSE 0 END
    /// FROM Prowadzacy;
    /// </summary>
    public IEnumerable<string> Zadanie06_CzyWszyscyProwadzacyMajaKatedre() {
        // throw Niezaimplementowano(nameof(Zadanie06_CzyWszyscyProwadzacyMajaKatedre));
        return 
            DaneUczelni.Prowadzacy
                .Any(n => n.Katedra != null || n.Katedra == "")
                ? new List<string>(1) { "Tak" }
                : new List<string>(1) { "Nie" };
    }

    /// <summary>
    /// Zadanie:
    /// Policz, ile aktywnych zapisów znajduje się w systemie.
    ///
    /// SQL:
    /// SELECT COUNT(*)
    /// FROM Zapisy
    /// WHERE CzyAktywny = 1;
    /// </summary>
    public IEnumerable<string> Zadanie07_LiczbaAktywnychZapisow() {
        // throw Niezaimplementowano(nameof(Zadanie07_LiczbaAktywnychZapisow));
        var query =
            from z in DaneUczelni.Zapisy
            where z.CzyAktywny
            select z;
        return new List<string> {query.Count().ToString()};
    }

    /// <summary>
    /// Zadanie:
    /// Pobierz listę unikalnych miast studentów i posortuj ją rosnąco.
    ///
    /// SQL:
    /// SELECT DISTINCT Miasto
    /// FROM Studenci
    /// ORDER BY Miasto;
    /// </summary>
    public IEnumerable<string> Zadanie08_UnikalneMiastaStudentow() {
        // throw Niezaimplementowano(nameof(Zadanie08_UnikalneMiastaStudentow));
        return
            (from s in DaneUczelni.Studenci
            select s.Miasto)
            .Distinct()
            .OrderBy(s => s);
    }

    /// <summary>
    /// Zadanie:
    /// Zwróć trzy najnowsze zapisy na przedmioty.
    /// W wyniku pokaż datę zapisu, identyfikator studenta i identyfikator przedmiotu.
    ///
    /// SQL:
    /// SELECT TOP 3 DataZapisu, StudentId, PrzedmiotId
    /// FROM Zapisy
    /// ORDER BY DataZapisu DESC;
    /// </summary>
    public IEnumerable<string> Zadanie09_TrzyNajnowszeZapisy() {
        // throw Niezaimplementowano(nameof(Zadanie09_TrzyNajnowszeZapisy));
        return 
            from z in DaneUczelni.Zapisy
                .Take(3)
            orderby z.DataZapisu descending
            select string.Join(", ", z.DataZapisu, "studentID: " + z.StudentId, "przedmiotID: " + z.PrzedmiotId);
        
    }

    /// <summary>
    /// Zadanie:
    /// Zaimplementuj prostą paginację dla listy przedmiotów.
    /// Załóż stronę o rozmiarze 2 i zwróć drugą stronę danych.
    ///
    /// SQL:
    /// SELECT Nazwa, Kategoria
    /// FROM Przedmioty
    /// ORDER BY Nazwa
    /// OFFSET 2 ROWS FETCH NEXT 2 ROWS ONLY;
    /// </summary>
    public IEnumerable<string> Zadanie10_DrugaStronaPrzedmiotow() {
        // throw Niezaimplementowano(nameof(Zadanie10_DrugaStronaPrzedmiotow));
        return DaneUczelni.Przedmioty
            .Skip(2)
            .Take(2)
            .Select(n => string.Join(", ", n.Nazwa, n.Kategoria));
    }

    /// <summary>
    /// Zadanie:
    /// Połącz studentów z zapisami po StudentId.
    /// Zwróć pełne imię i nazwisko studenta oraz datę zapisu.
    ///
    /// SQL:
    /// SELECT s.Imie, s.Nazwisko, z.DataZapisu
    /// FROM Studenci s
    /// JOIN Zapisy z ON s.Id = z.StudentId;
    /// </summary>
    public IEnumerable<string> Zadanie11_PolaczStudentowIZapisy() {
        // throw Niezaimplementowano(nameof(Zadanie11_PolaczStudentowIZapisy));
        return
            from s in DaneUczelni.Studenci
            join z in DaneUczelni.Zapisy on s.Id equals z.StudentId
            select string.Join(", ", s.Imie, s.Nazwisko, z.DataZapisu);
    }

    /// <summary>
    /// Zadanie:
    /// Przygotuj wszystkie pary student-przedmiot na podstawie zapisów.
    /// Użyj podejścia, które pozwoli spłaszczyć dane do jednej sekwencji wyników.
    ///
    /// SQL:
    /// SELECT s.Imie, s.Nazwisko, p.Nazwa
    /// FROM Zapisy z
    /// JOIN Studenci s ON s.Id = z.StudentId
    /// JOIN Przedmioty p ON p.Id = z.PrzedmiotId;
    /// </summary>
    public IEnumerable<string> Zadanie12_ParyStudentPrzedmiot() {
        // throw Niezaimplementowano(nameof(Zadanie12_ParyStudentPrzedmiot));
        return DaneUczelni.Zapisy
            .Join(
                DaneUczelni.Studenci,
                z => z.StudentId,
                s => s.Id,
                (z, s) => new { z, s })
            .Join(
                DaneUczelni.Przedmioty,
                z => z.z.PrzedmiotId,
                p => p.Id,
                (z, p) => new { z, p })
            .Select(n  => string.Join(", ", n.z.s.Imie, n.z.s.Nazwisko, n.p.Nazwa));
    }

    /// <summary>
    /// Zadanie:
    /// Pogrupuj zapisy według przedmiotu i zwróć nazwę przedmiotu oraz liczbę zapisów.
    ///
    /// SQL:
    /// SELECT p.Nazwa, COUNT(*)
    /// FROM Zapisy z
    /// JOIN Przedmioty p ON p.Id = z.PrzedmiotId
    /// GROUP BY p.Nazwa;
    /// </summary>
    public IEnumerable<string> Zadanie13_GrupowanieZapisowWedlugPrzedmiotu() {
        // throw Niezaimplementowano(nameof(Zadanie13_GrupowanieZapisowWedlugPrzedmiotu));
        return
            DaneUczelni.Zapisy
                .Join(
                    DaneUczelni.Przedmioty,
                    z => z.PrzedmiotId,
                    p => p.Id,
                    (z, p) => new { z, p })
                .GroupBy(n => n.p.Nazwa)
                .Select(m => new { Nazwa = m.Key , Count = m.Count()})
                .Select(n =>  string.Join(", ", n.Nazwa, n.Count));
}

    /// <summary>
    /// Zadanie:
    /// Oblicz średnią ocenę końcową dla każdego przedmiotu.
    /// Pomiń rekordy, w których ocena końcowa ma wartość null.
    ///
    /// SQL:
    /// SELECT p.Nazwa, AVG(z.OcenaKoncowa)
    /// FROM Zapisy z
    /// JOIN Przedmioty p ON p.Id = z.PrzedmiotId
    /// WHERE z.OcenaKoncowa IS NOT NULL
    /// GROUP BY p.Nazwa;
    /// </summary>
    public IEnumerable<string> Zadanie14_SredniaOcenaNaPrzedmiot() {
        // throw Niezaimplementowano(nameof(Zadanie14_SredniaOcenaNaPrzedmiot));
         return
                from z in DaneUczelni.Zapisy
                where z.OcenaKoncowa != null
                join p in DaneUczelni.Przedmioty
                    on z.PrzedmiotId equals p.Id
                group z by p.Nazwa into g
                select $"{g.Key}: {g.Average(x => x.OcenaKoncowa)}";
    }

    /// <summary>
    /// Zadanie:
    /// Dla każdego prowadzącego policz liczbę przypisanych przedmiotów.
    /// W wyniku zwróć pełne imię i nazwisko oraz liczbę przedmiotów.
    ///
    /// SQL:
    /// SELECT pr.Imie, pr.Nazwisko, COUNT(p.Id)
    /// FROM Prowadzacy pr
    /// LEFT JOIN Przedmioty p ON p.ProwadzacyId = pr.Id
    /// GROUP BY pr.Imie, pr.Nazwisko;
    /// </summary>
    public IEnumerable<string> Zadanie15_ProwadzacyILiczbaPrzedmiotow() {
        // throw Niezaimplementowano(nameof(Zadanie15_ProwadzacyILiczbaPrzedmiotow));
        return
            from pro in DaneUczelni.Prowadzacy
            join prz in DaneUczelni.Przedmioty
                on pro.Id equals prz.ProwadzacyId into gj
            from prz in gj.DefaultIfEmpty()
            group prz by new { pro.Imie, pro.Nazwisko }
            into g
            select $"{g.Key.Imie} {g.Key.Nazwisko}: {g.Count(x => x != null)}";
    }

    /// <summary>
    /// Zadanie:
    /// Dla każdego studenta znajdź jego najwyższą ocenę końcową.
    /// Pomiń studentów, którzy nie mają jeszcze żadnej oceny.
    ///
    /// SQL:
    /// SELECT s.Imie, s.Nazwisko, MAX(z.OcenaKoncowa)
    /// FROM Studenci s
    /// JOIN Zapisy z ON s.Id = z.StudentId
    /// WHERE z.OcenaKoncowa IS NOT NULL
    /// GROUP BY s.Imie, s.Nazwisko;
    /// </summary>
    public IEnumerable<string> Zadanie16_NajwyzszaOcenaKazdegoStudenta() {
        // throw Niezaimplementowano(nameof(Zadanie16_NajwyzszaOcenaKazdegoStudenta));
        return DaneUczelni.Studenci
            .Join(
                DaneUczelni.Zapisy,
                s => s.Id,
                z => z.StudentId,
                (s, z) => new { s, z })
            .Where(n => n.z.OcenaKoncowa != null)
            .GroupBy(n => new {n.s.Imie, n.s.Nazwisko})
            .Select(x => $"{x.Key.Imie} {x.Key.Nazwisko}: {x.Max(x => x.z.OcenaKoncowa)}");
    }

    /// <summary>
    /// Wyzwanie:
    /// Znajdź studentów, którzy mają więcej niż jeden aktywny zapis.
    /// Zwróć pełne imię i nazwisko oraz liczbę aktywnych przedmiotów.
    ///
    /// SQL:
    /// SELECT s.Imie, s.Nazwisko, COUNT(*)
    /// FROM Studenci s
    /// JOIN Zapisy z ON s.Id = z.StudentId
    /// WHERE z.CzyAktywny = 1
    /// GROUP BY s.Imie, s.Nazwisko
    /// HAVING COUNT(*) > 1;
    /// </summary>
    public IEnumerable<string> Wyzwanie01_StudenciZWiecejNizJednymAktywnymPrzedmiotem() {
        throw Niezaimplementowano(nameof(Wyzwanie01_StudenciZWiecejNizJednymAktywnymPrzedmiotem));
    }

    /// <summary>
    /// Wyzwanie:
    /// Wypisz przedmioty startujące w kwietniu 2026, dla których żaden zapis nie ma jeszcze oceny końcowej.
    ///
    /// SQL:
    /// SELECT p.Nazwa
    /// FROM Przedmioty p
    /// JOIN Zapisy z ON p.Id = z.PrzedmiotId
    /// WHERE MONTH(p.DataStartu) = 4 AND YEAR(p.DataStartu) = 2026
    /// GROUP BY p.Nazwa
    /// HAVING SUM(CASE WHEN z.OcenaKoncowa IS NOT NULL THEN 1 ELSE 0 END) = 0;
    /// </summary>
    public IEnumerable<string> Wyzwanie02_PrzedmiotyStartujaceWKwietniuBezOcenKoncowych() {
        throw Niezaimplementowano(nameof(Wyzwanie02_PrzedmiotyStartujaceWKwietniuBezOcenKoncowych));
    }

    /// <summary>
    /// Wyzwanie:
    /// Oblicz średnią ocen końcowych dla każdego prowadzącego na podstawie wszystkich jego przedmiotów.
    /// Pomiń brakujące oceny, ale pozostaw samych prowadzących w wyniku.
    ///
    /// SQL:
    /// SELECT pr.Imie, pr.Nazwisko, AVG(z.OcenaKoncowa)
    /// FROM Prowadzacy pr
    /// LEFT JOIN Przedmioty p ON p.ProwadzacyId = pr.Id
    /// LEFT JOIN Zapisy z ON z.PrzedmiotId = p.Id
    /// WHERE z.OcenaKoncowa IS NOT NULL
    /// GROUP BY pr.Imie, pr.Nazwisko;
    /// </summary>
    public IEnumerable<string> Wyzwanie03_ProwadzacyISredniaOcenNaIchPrzedmiotach() {
        throw Niezaimplementowano(nameof(Wyzwanie03_ProwadzacyISredniaOcenNaIchPrzedmiotach));
    }

    /// <summary>
    /// Wyzwanie:
    /// Pokaż miasta studentów oraz liczbę aktywnych zapisów wykonanych przez studentów z danego miasta.
    /// Posortuj wynik malejąco po liczbie aktywnych zapisów.
    ///
    /// SQL:
    /// SELECT s.Miasto, COUNT(*)
    /// FROM Studenci s
    /// JOIN Zapisy z ON s.Id = z.StudentId
    /// WHERE z.CzyAktywny = 1
    /// GROUP BY s.Miasto
    /// ORDER BY COUNT(*) DESC;
    /// </summary>
    public IEnumerable<string> Wyzwanie04_MiastaILiczbaAktywnychZapisow() {
        throw Niezaimplementowano(nameof(Wyzwanie04_MiastaILiczbaAktywnychZapisow));
    }

    private static NotImplementedException Niezaimplementowano(string nazwaMetody) {
        return new NotImplementedException(
            $"Uzupełnij metodę {nazwaMetody} w pliku Exercises/ZadaniaLinq.cs i uruchom polecenie ponownie.");
    }
}