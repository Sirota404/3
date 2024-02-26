using System;

class Program
{
    static void Main(string[] args) { StartInput(); }


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
        catch (NotRealRootsException ex)
        {
            FormatData(ex.Message, Severity.Warning);
        }
        catch (FormatException ex)
        {
            FormatData(ex.Message, Severity.Error);
        }
        catch (OverflowException ex)
        {
            FormatData(ex.Message, Severity.Error);
        }
    }

    private static (double a, double b, double c) Processing(string a, string b, string c)
    {
        try
        {
            double aDouble = Double.Parse(a.Trim('a'));
            double bDouble = Double.Parse(b.Trim('b'));
            double cDouble = Double.Parse(c.Trim('c'));
            return (aDouble, bDouble, cDouble);
        }
        catch (FormatException ex)
        {
            throw ex;
        }
        catch (OverflowException ex)
        {
            throw ex;
        }
    }

    private static (double x1, double x2, double D) Solution(double a, double b, double c)
    {
        double discriminant = Math.Pow(b, 2) - 4 * a * c;

        if (discriminant >= 0)
        {
            double x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
            double x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
            return (x1, x2, discriminant);
        }
        else
        {
            throw new NotRealRootsException("Вещественных значений не найдено");
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

    private static void FormatData(string message, Severity severity)
    {
        if (severity == Severity.Warning)
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ResetColor();
            Console.ReadLine();
        }
        else
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
            Console.ReadLine();
        }
    }
}

public class NotRealRootsException : Exception { public NotRealRootsException(string message) : base(message) { } }

public enum Severity { Error, Warning }
