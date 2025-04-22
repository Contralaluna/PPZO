using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n=== MENU ===");
            Console.WriteLine("1. Kalkulator dwóch liczb");
            Console.WriteLine("2. Konwerter temperatur");
            Console.WriteLine("3. Średnia ocen");
            Console.WriteLine("0. Wyjście");

            Console.Write("Wybierz opcję: ");
            string wybor = Console.ReadLine();

            switch (wybor)
            {
                case "1":
                    Kalkulator();
                    break;
                case "2":
                    KonwerterTemperatur();
                    break;
                case "3":
                    SredniaOcen();
                    break;
                case "0":
                    Console.WriteLine("KONIEC!");
                    return;
                default:
                    Console.WriteLine("Nieprawidłowy wybór, spróbuj ponownie.");
                    break;
            }
        }
    }

    static void Kalkulator()
    {
        try
        {
            Console.Write("Podaj pierwszą liczbę: ");
            double liczba1 = double.Parse(Console.ReadLine());

            Console.Write("Podaj drugą liczbę: ");
            double liczba2 = double.Parse(Console.ReadLine());

            Console.Write("Wybierz operację (+, -, *, /): ");
            string operacja = Console.ReadLine();

            double wynik;

            switch (operacja)
            {
                case "+":
                    wynik = liczba1 + liczba2;
                    break;
                case "-":
                    wynik = liczba1 - liczba2;
                    break;
                case "*":
                    wynik = liczba1 * liczba2;
                    break;
                case "/":
                    if (liczba2 != 0)
                        wynik = liczba1 / liczba2;
                    else
                    {
                        Console.WriteLine("Błąd: Dzielenie przez zero!");
                        return;
                    }
                    break;
                default:
                    Console.WriteLine("Nieznana operacja!");
                    return;
            }

            Console.WriteLine($"Wynik: {wynik}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Błąd: Wprowadź prawidłowe liczby!");
        }
    }

    static void KonwerterTemperatur()
    {
        try
        {
            Console.Write("Wybierz kierunek konwersji (C = Celsjusz → Fahrenheit, F = Fahrenheit → Celsjusz): ");
            string kierunek = Console.ReadLine().ToUpper();

            switch (kierunek)
            {
                case "C":
                    Console.Write("Podaj temperaturę w stopniach Celsjusza: ");
                    double celsius = double.Parse(Console.ReadLine());
                    double fahrenheit = celsius * 1.8 + 32;
                    Console.WriteLine($"{celsius}°C = {fahrenheit:F2}°F");
                    break;
                case "F":
                    Console.Write("Podaj temperaturę w stopniach Fahrenheita: ");
                    fahrenheit = double.Parse(Console.ReadLine());
                    celsius = (fahrenheit - 32) / 1.8;
                    Console.WriteLine($"{fahrenheit}°F = {celsius:F2}°C");
                    break;
                default:
                    Console.WriteLine("Nieprawidłowy wybór. Wybierz 'C' lub 'F'.");
                    break;
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Błąd: Podano nieprawidłową wartość temperatury!");
        }
    }

    static void SredniaOcen()
    {
        try
        {
            Console.Write("Podaj liczbę ocen: ");
            int liczbaOcen = int.Parse(Console.ReadLine());

            if (liczbaOcen <= 0)
            {
                Console.WriteLine("Liczba ocen musi być większa od 0.");
                return;
            }

            double sumaOcen = 0;

            for (int i = 0; i < liczbaOcen; i++)
            {
                Console.Write($"Podaj ocenę {i + 1}: ");
                double ocena = double.Parse(Console.ReadLine());

                if (ocena < 1 || ocena > 6)
                {
                    Console.WriteLine("Ocena musi być w zakresie od 1 do 6.");
                    return;
                }

                sumaOcen += ocena;
            }

            double srednia = sumaOcen / liczbaOcen;
            Console.WriteLine($"Średnia: {srednia:F2}");

            if (srednia >= 3.0)
                Console.WriteLine("Uczeń zdał.");
            else
                Console.WriteLine("Uczeń nie zdał.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Błąd: Wprowadź prawidłową liczbę!");
        }
    }
}
