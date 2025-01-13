using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.WriteLine("Polinom işlemleri (Çıkmak için 'exit' yazın)");

        while (true)
        {
            // Kullanıcıdan polinomları al
            Console.Write("\nBirinci polinomu girin: ");
            string poly1 = Console.ReadLine();
            if (poly1.ToLower() == "exit") break;

            Console.Write("İkinci polinomu girin: ");
            string poly2 = Console.ReadLine();
            if (poly2.ToLower() == "exit") break;

            // Polinomları ayrıştır
            var poly1Terms = ParsePolynomial(poly1);
            var poly2Terms = ParsePolynomial(poly2);

            // Polinomları topla ve çıkar
            var sum = AddPolynomials(poly1Terms, poly2Terms);
            var difference = SubtractPolynomials(poly1Terms, poly2Terms);

            // Sonuçları göster
            Console.WriteLine("\nToplama sonucu: " + FormatPolynomial(sum));
            Console.WriteLine("Çıkarma sonucu: " + FormatPolynomial(difference));
        }
    }

    // Polinomu terimlere ayırma fonksiyonu
    static Dictionary<int, int> ParsePolynomial(string polynomial)
    {
        Dictionary<int, int> terms = new Dictionary<int, int>();
        string pattern = @"([+-]?\d*)x\^?(\d*)|([+-]?\d+)";
        var matches = Regex.Matches(polynomial.Replace(" ", ""), pattern);

        foreach (Match match in matches)
        {
            int coefficient = 0;
            int exponent = 0;

            if (match.Groups[3].Success) // Sabit terim (örneğin: -5)
            {
                coefficient = int.Parse(match.Groups[3].Value);
                exponent = 0;
            }
            else // Katsayı ve üs (örneğin: 2x^2)
            {
                coefficient = match.Groups[1].Value == "" || match.Groups[1].Value == "+" ? 1 :
                              match.Groups[1].Value == "-" ? -1 : int.Parse(match.Groups[1].Value);
                exponent = match.Groups[2].Value == "" ? 1 : int.Parse(match.Groups[2].Value);
            }

            if (terms.ContainsKey(exponent))
                terms[exponent] += coefficient;
            else
                terms[exponent] = coefficient;
        }

        return terms;
    }

    // Polinom toplama fonksiyonu
    static Dictionary<int, int> AddPolynomials(Dictionary<int, int> poly1, Dictionary<int, int> poly2)
    {
        var result = new Dictionary<int, int>(poly1);

        foreach (var term in poly2)
        {
            if (result.ContainsKey(term.Key))
                result[term.Key] += term.Value;
            else
                result[term.Key] = term.Value;
        }

        return result;
    }

    // Polinom çıkarma fonksiyonu
    static Dictionary<int, int> SubtractPolynomials(Dictionary<int, int> poly1, Dictionary<int, int> poly2)
    {
        var result = new Dictionary<int, int>(poly1);

        foreach (var term in poly2)
        {
            if (result.ContainsKey(term.Key))
                result[term.Key] -= term.Value;
            else
                result[term.Key] = -term.Value;
        }

        return result;
    }

    // Polinomu düzgün bir biçimde yazdırma fonksiyonu
    static string FormatPolynomial(Dictionary<int, int> polynomial)
    {
        var terms = new List<string>();

        foreach (var term in polynomial)
        {
            int coefficient = term.Value;
            int exponent = term.Key;

            if (coefficient == 0) continue;

            string formattedTerm = coefficient.ToString();

            if (exponent > 0)
                formattedTerm += "x";

            if (exponent > 1)
                formattedTerm += "^" + exponent;

            terms.Add(formattedTerm);
        }

        return string.Join(" + ", terms).Replace("+ -", "- ");
    }
}
