using System;

class Calculator
{
    static double memory = 0;
    static double currentValue = 0;

    static void Main()
    {
        Console.WriteLine("Классический калькулятор на C#.");
        Console.WriteLine("Операции: +, -, *, /, %, 1/x, x^2, sqrt, M+, M-, MR, exit");

        while (true)
        {
            Console.Write("Введите первое" +
                " число: ");
            if (!double.TryParse(Console.ReadLine(), out currentValue))
            {
                Console.WriteLine("Ошибка: введено некорректное число.");
                continue;
            }

            Console.Write("Введите операцию: ");
            string op = Console.ReadLine();

            try
            {
                switch (op)
                {
                    case "+":
                    case "-":
                    case "*":
                    case "/":
                    case "%":
                        Console.Write("Введите второе число: ");
                        if (!double.TryParse(Console.ReadLine(), out double num2))
                        {
                            Console.WriteLine("Ошибка: введено некорректное число.");
                            continue;
                        }
                        currentValue = Calculate(currentValue, num2, op);
                        Console.WriteLine("Результат: " + currentValue);
                        break;
                    case "1/x":
                        if (currentValue == 0) throw new DivideByZeroException();
                        currentValue = 1 / currentValue;
                        Console.WriteLine("Результат: " + currentValue);
                        break;
                    case "x^2":
                        currentValue = currentValue * currentValue;
                        Console.WriteLine("Результат: " + currentValue);
                        break;
                    case "sqrt":
                        if (currentValue < 0) throw new ArgumentException("Корень из отрицательного числа.");
                        currentValue = Math.Sqrt(currentValue);
                        Console.WriteLine("Результат: " + currentValue);
                        break;
                    case "M+":
                        memory += currentValue;
                        Console.WriteLine("Память: " + memory);
                        break;
                    case "M-":
                        memory -= currentValue;
                        Console.WriteLine("Память: " + memory);
                        break;
                    case "MR":
                        Console.WriteLine("Память: " + memory);
                        break;
                    case "exit":
                        return;
                    default:
                        Console.WriteLine("Неизвестная операция");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }
    }

    static double Calculate(double a, double b, string op)
    {
        return op switch
        {
            "+" => a + b,
            "-" => a - b,
            "*" => a * b,
            "/" => b == 0 ? throw new DivideByZeroException() : a / b,
            "%" => b == 0 ? throw new DivideByZeroException() : a % b,
            _ => throw new ArgumentException("Неизвестная операция"),
        };
    }
}

