using System;

class Program
{
    enum Severity { Warning, Error };
    static void Main()
    {
        StartInput();
    }

    private static void DisplaySolutions(int a, int b, int c, double x1, double x2, int D)
    {
        Console.WriteLine("a * x^2 + b * x + c = 0");
        Console.WriteLine($"a = {a}");
        Console.WriteLine($"b = {b}");
        Console.WriteLine($"c = {c}");

        if (D >= 0)
        {
            Console.WriteLine("Решения:");
            Console.WriteLine($"x1 = {x1}");
            Console.WriteLine($"x2 = {x2}");
        }
        else
        {
            FormatData("Вещественных значений не найдено", Severity.Warning);
        }

        Console.ReadLine();
    }

    private static void StartInput()
    {
        Console.WriteLine("a * x^2 + b * x + c = 0");
        Console.WriteLine("Введите значение a:");
        string inputA = Console.ReadLine();
        Console.WriteLine("Введите значение b:");
        string inputB = Console.ReadLine();
        Console.WriteLine("Введите значение c:");
        string inputC = Console.ReadLine();

        try
        {
            var processingResult = Processing(inputA, inputB, inputC);
            int a = processingResult.a;
            int b = processingResult.b;
            int c = processingResult.c;

            var solutionResult = Solution(a, b, c);
            DisplaySolutions(a, b, c, solutionResult.x1, solutionResult.x2, solutionResult.D);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.ReadLine();
        }
    }
    private static (int a, int b, int c) Processing(string a, string b, string c)
    {
        var i = 0;
        string perem = "a";

        try
        {
            int aInt;
            int bInt;
            int cInt;
            aInt = Int32.Parse(a.Trim('a'));
            i++;
            bInt = Int32.Parse(b.Trim('b'));
            i++;
            cInt = Int32.Parse(c.Trim('c'));
            return (aInt, bInt, cInt);
        }
        catch (System.OverflowException)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("Диапазон значений int = От -2 147 483 648 до 2 147 483 647");
            Console.ResetColor();
            Console.ReadLine();
            Console.Clear();
            return (0, 0, 0);
        }
        catch
        {
            if (i == 0) { perem = "a"; } else if (i == 1) { perem = "b"; } else if (i == 2) { perem = "c"; }

            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine($"Неверный формат параметра {perem}");
            Console.WriteLine($" a = {a} \n b = {b} \n c = {c}");
            Console.ResetColor();
            Console.ReadLine();
            Console.Clear();
            return (0, 0, 0);
        }
    }

    private static (double x1, double x2, int D) Solution(int a, int b, int c)
    {
        int discriminant = b * b - 4 * a * c;

        double x1 = 0;
        double x2 = 0;

        if (discriminant == 0)
        {
            x1 = -b / (2 * a);
        }
        else
        {
            x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
            x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
        }

        return (x1, x2, discriminant);
    }

    private static void FormatData(string message, Severity severity)
    {
        Console.BackgroundColor = ConsoleColor.Yellow;
        Console.ForegroundColor = ConsoleColor.Black; 
        Console.WriteLine(message);
        Console.ResetColor(); 
    }
}
