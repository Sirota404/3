using System;

class Program
{
    static void Main(string[] args)
    {
        StartInput();
    }

    private static void StartInput()
    {
        Console.WriteLine("a * x^2 + b * x + c = 0");
        Console.WriteLine("Введите значение a:");
        var a = Console.ReadLine();
        Console.WriteLine("Введите значение b:");
        var b = Console.ReadLine();
        Console.WriteLine("Введите значение c:");
        var c = Console.ReadLine();

        var processing = Processing(a, b, c);
        var aDouble = processing.a;
        var bDouble = processing.b;
        var cDouble = processing.c;

        try
        {
            var solution = Solution(aDouble, bDouble, cDouble);
            DisplaySolutions(aDouble, bDouble, cDouble, solution.x1, solution.x2, solution.D);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.ReadLine();
        }
    }

    private static (double a, double b, double c) Processing(string a, string b, string c)
    {
        var i = 0;
        string perem = "a";

        try
        {
            double aDouble;
            double bDouble;
            double cDouble;
            aDouble = Double.Parse(a.Trim('a'));
            i++;
            bDouble = Double.Parse(b.Trim('b'));
            i++;
            cDouble = Double.Parse(c.Trim('c'));
            return (aDouble, bDouble, cDouble);
        }
        catch (System.OverflowException)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine("Диапазон значений double = От -1,79769313486231570 до 1,79769313486231570");
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
            Console.WriteLine($" a = {a}\n b = {b}\n c = {c}");
            Console.ResetColor();
            Console.ReadLine();
            Console.Clear();
            return (0, 0, 0);
            //return StartInput();
        }
    }

    private static (double x1, double x2, double D) Solution(double a, double b, double c)
    {
        double discriminant;
        double x1;
        double x2;

        discriminant = Math.Pow(b, 2) - 4 * a * c;

        try
        {
            if (discriminant > 0 || discriminant == 0)
            {
                x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
                x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
                return (x1, x2, discriminant);
            }
            else
            {
                throw new NotImplementedException("Вещественных значений не найдено");
            }
        }
        catch
        {
            throw;
        }
    }

    private static void DisplaySolutions(double a, double b, double c, double x1, double x2, double D)
    {
        if (D == 0)
        {
            Console.WriteLine($"x = {x1}");
        }
        else
        {
            Console.WriteLine($"x1 = {x1}, x2 = {x2}");
        }

        Console.ReadLine();
    }
}
