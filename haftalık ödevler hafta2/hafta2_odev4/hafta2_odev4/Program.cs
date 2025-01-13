using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.Write("Matematiksel ifadeyi girin: ");
        string expression = Console.ReadLine();

        // İfade ayrıştır ve postfix notasyonuna dönüştür
        List<string> postfix = ConvertToPostfix(expression);

        // Adım adım çözümle ve sonucu hesapla
        Console.WriteLine("\nÇözüm Süreci:");
        double result = EvaluatePostfix(postfix);
        Console.WriteLine($"\nSonuç: {result}");
    }

    // Shunting Yard algoritması ile infix ifadeyi postfix ifadeye çevirme
    static List<string> ConvertToPostfix(string expression)
    {
        Stack<string> operators = new Stack<string>();
        List<string> postfix = new List<string>();
        string[] tokens = Regex.Split(expression, @"([+\-*/^()])").Where(t => t.Trim() != "").ToArray();

        foreach (string token in tokens)
        {
            if (double.TryParse(token, out _))
            {
                postfix.Add(token); // Sayı ise direkt postfix'e ekle
            }
            else if (token == "(")
            {
                operators.Push(token);
            }
            else if (token == ")")
            {
                while (operators.Peek() != "(")
                {
                    postfix.Add(operators.Pop());
                }
                operators.Pop(); // "(" parantezini çıkart
            }
            else
            {
                while (operators.Count > 0 && OperatorPrecedence(token) <= OperatorPrecedence(operators.Peek()))
                {
                    postfix.Add(operators.Pop());
                }
                operators.Push(token);
            }
        }

        // Kalan operatörleri postfix'e ekle
        while (operators.Count > 0)
        {
            postfix.Add(operators.Pop());
        }

        return postfix;
    }

    // Operatör önceliğini belirleme fonksiyonu
    static int OperatorPrecedence(string op)
    {
        return op switch
        {
            "+" or "-" => 1,
            "*" or "/" => 2,
            "^" => 3,
            _ => 0
        };
    }

    // Postfix ifadeyi hesaplama ve adım adım çözüm gösterme fonksiyonu
    static double EvaluatePostfix(List<string> postfix)
    {
        Stack<double> values = new Stack<double>();

        foreach (string token in postfix)
        {
            if (double.TryParse(token, out double num))
            {
                values.Push(num);
            }
            else
            {
                double right = values.Pop();
                double left = values.Pop();
                double result = token switch
                {
                    "+" => left + right,
                    "-" => left - right,
                    "*" => left * right,
                    "/" => left / right,
                    "^" => Math.Pow(left, right),
                    _ => 0
                };
                Console.WriteLine($"{left} {token} {right} = {result}");
                values.Push(result);
            }
        }

        return values.Pop();
    }
}
