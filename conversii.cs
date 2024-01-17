using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Introduceți numărul în virgulă fixă:");
        string numarInVirgulaFixa = Console.ReadLine();

        Console.WriteLine("Introduceți baza inițială (b1):");
        int b1 = int.Parse(Console.ReadLine());

        Console.WriteLine("Introduceți baza de destinație (b2):");
        int b2 = int.Parse(Console.ReadLine());

        try
        {
            string rezultat = ConversieBaza(numarInVirgulaFixa, b1, b2);
            Console.WriteLine($"Rezultatul conversiei: {rezultat}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Eroare: {ex.Message}");
        }
    }

    static string ConversieBaza(string numarInVirgulaFixa, int bazaInitiala, int bazaDestinatie)
    {
        if (bazaInitiala < 2 || bazaInitiala > 16 || bazaDestinatie < 2 || bazaDestinatie > 16)
        {
            throw new ArgumentException("Bazele trebuie să fie între 2 și 16.");
        }

        // Converteste numarul din baza initiala in baza 10
        double numarDecimal = 0;
        int putere = 0;
        for (int i = numarInVirgulaFixa.Length - 1; i >= 0; i--)
        {
            int cifra = CaracterInCifra(numarInVirgulaFixa[i]);
            numarDecimal += cifra * Math.Pow(bazaInitiala, putere);
            putere++;
        }

        // Converteste numarul din baza 10 in baza destinatie
        string rezultat = "";
        while (numarDecimal > 0)
        {
            int rest = (int)(numarDecimal % bazaDestinatie);
            rezultat = CifraInCaracter(rest) + rezultat;
            numarDecimal /= bazaDestinatie;
        }

        return rezultat;
    }

    static int CaracterInCifra(char caracter)
    {
        if (char.IsDigit(caracter))
        {
            return int.Parse(caracter.ToString());
        }
        else
        {
            return char.ToUpper(caracter) - 'A' + 10;
        }
    }

    static char CifraInCaracter(int cifra)
    {
        if (cifra < 10)
        {
            return cifra.ToString()[0];
        }
        else
        {
            return (char)('A' + cifra - 10);
        }
    }
}
