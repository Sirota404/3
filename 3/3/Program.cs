using System;

class Program
{
static void Main()
{
StartInput();
}

private static void DisplaySolutions(int a, int b, int c, int x1, int x2, int D)
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
Console.WriteLine("Вещественных значений не найдено");
}

Console.ReadLine();
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
var aInt = processing.a;
var bInt = processing.b;
var cInt = processing.c;

try
{
var solution = Solution(aInt, bInt, cInt);
DisplaySolutions(aInt, bInt, cInt, solution.x1, solution.x2, solution.D);
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
//return StartInput();
}
}

private static (int x1, int x2, int D) Solution(int a, int b, int c)
{
int discriminant;
int x1;
int x2;

discriminant = (int)(Math.Pow(b, 2) - 4 * a * c);

try
{
if (discriminant > 0 || discriminant == 0)
{
x1 = (int)((-b + Math.Sqrt(discriminant)) / (2 * a));
x2 = (int)((-b - Math.Sqrt(discriminant)) / (2 * a));
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
}
