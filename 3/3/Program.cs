using System;
using System.Linq.Expressions;

class QuadraticEquationSolver
{
    static void Main()
    {
        while (true)
            try
            {
                Console.WriteLine("a * x^2 + b * x + c = 0");
                Console.WriteLine("Введите значение a:");
                int a = ParseInput();

                Console.WriteLine("Введите значение b:");
                int b = ParseInput();

                Console.WriteLine("Введите значение c:");
                int c = ParseInput();

                double[] solutions = QuadraticEquation(a, b, c);


                if (solutions.Length == 2)
                {
                    Console.WriteLine($"x1 = {solutions[0]}, x2 = {solutions[1]}");
                }
                else if (solutions.Length == 1)
                {
                    Console.WriteLine($"x = {solutions[0]}");
                }

                else
                {
                    throw new NoException();
                }
                Console.WriteLine("Введите 'да' чтобы запустить заново:");
                Console.ResetColor();

                string input = Console.ReadLine();

                if (input.ToLower() == "да")
                {
                    Console.WriteLine("Вы ввели 'да'. \n");
                    break;
                }
                else if (input.ToLower() == "нет")
                {
                    Console.WriteLine("Вы ввели 'нет'.\n");
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Вы ввели неверное значение.");
                    Environment.Exit(0);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Неверный формат данных");
                Main();
            }
            catch (NoException ex)
            {
                FormatData(ex, Severity.Warning);
                Main();
            }


    }


    static int ParseInput()
    {
        int value;

        if (!int.TryParse(Console.ReadLine(), out value))
        {
            throw new FormatException();
        }

        return value;
    }

    static double[] QuadraticEquation(int a, int b, int c)
    {
        double discriminant = b * b - 4 * a * c;

        if (discriminant < 0)
        {
            throw new NoException();
        }
        else if (discriminant == 0)
        {
            return new double[] { -b / (2.0 * a) };
        }
        else
        {
            double sqrtDiscriminant = Math.Sqrt(discriminant);
            return new double[] { (-b + sqrtDiscriminant) / (2.0 * a), (-b - sqrtDiscriminant) / (2.0 * a) };
        }
    }

    static void FormatData(Exception ex, Severity severity = Severity.Error)
    {
        Console.ForegroundColor = ConsoleColor.Black;
        switch (severity)
        {
            case Severity.Warning:
                Console.BackgroundColor = ConsoleColor.Yellow;
                break;
            case Severity.Error:
                Console.BackgroundColor = ConsoleColor.Red;
                break;
        }

        Console.WriteLine(ex.Message);
        Console.ResetColor();
    }

}


class NoException : Exception
{
    public NoException() : base("Вещественных значений не найдено") { }
}

enum Severity
{

    Warning,
    Error
}
