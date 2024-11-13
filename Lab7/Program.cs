using System;

public class Calculator
{
    private double _result;

    // Приватний метод для встановлення результату
    private void SetResult(double value)
    {
        _result = value;
    }

    // Публічний метод для отримання результату
    public double GetResult()
    {
        return _result;
    }

    // Арифметичні операції
    public void Add(double a, double b)
    {
        SetResult(a + b);
    }

    public void Subtract(double a, double b)
    {
        SetResult(a - b);
    }

    public void Multiply(double a, double b)
    {
        SetResult(a * b);
    }

    public void Divide(double a, double b)
    {
        if (b == 0)
        {
            Console.WriteLine("Помилка: Ділення на нуль неможливе.");
            SetResult(0);
        }
        else
        {
            SetResult(a / b);
        }
    }

    public void Modulus(double a, double b)
    {
        if (b == 0)
        {
            Console.WriteLine("Помилка: Ділення на нуль неможливе.");
            SetResult(0);
        }
        else
        {
            SetResult(a % b);
        }
    }

    public void Power(double a, double b)
    {
        SetResult(Math.Pow(a, b));
    }

    // Нові операції
    public void SquareRoot(double a)
    {
        if (a < 0)
        {
            Console.WriteLine("Помилка: Корінь з від'ємного числа неможливий.");
            SetResult(0);
        }
        else
        {
            SetResult(Math.Sqrt(a));
        }
    }

    public void Logarithm(double a)
    {
        if (a <= 0)
        {
            Console.WriteLine("Помилка: Логарифм не визначений для нуля або від'ємних чисел.");
            SetResult(0);
        }
        else
        {
            SetResult(Math.Log(a));
        }
    }
}

public class UserInterface
{
    // Приватні методи для отримання вибору та операндів
    private static int GetChoice()
    {
        Console.WriteLine("Виберіть операцію:");
        Console.WriteLine("1. Додавання");
        Console.WriteLine("2. Віднімання");
        Console.WriteLine("3. Множення");
        Console.WriteLine("4. Ділення");
        Console.WriteLine("5. Залишок від ділення");
        Console.WriteLine("6. Піднесення до степеня");
        Console.WriteLine("7. Квадратний корінь");
        Console.WriteLine("8. Логарифм");
        Console.Write("Ваш вибір: ");
        int choice = Convert.ToInt32(Console.ReadLine());
        if (choice < 1 || choice > 8)
        {
            Console.WriteLine("Неправильний вибір операції.");
            Environment.Exit(0);
        }
        return choice;
    }

    private static double GetOperand(string operandName)
    {
        Console.Write($"Введіть {operandName} операнд: ");
        return Convert.ToDouble(Console.ReadLine());
    }

    // Метод для відображення результату
    public static void ShowResult(double result)
    {
        Console.WriteLine("Результат: " + result);
    }

    // Метод для виконання операцій
    public static void PerformOperation(Calculator calculator)
    {
        int choice = GetChoice();
        double operand1, operand2;
        
        // Отримуємо операнди в залежності від вибраної операції
        if (choice != 7 && choice != 8)  // Якщо не вибрана операція для одного операнда
        {
            operand1 = GetOperand("перший");
            operand2 = GetOperand("другий");
        }
        else  // Якщо вибрана операція для одного операнда (корінь або логарифм)
        {
            operand1 = GetOperand("операнд");
            operand2 = 0; // Для кореня та логарифму другий операнд не потрібен
        }

        // Виконуємо вибрану операцію
        switch (choice)
        {
            case 1:
                calculator.Add(operand1, operand2);
                break;
            case 2:
                calculator.Subtract(operand1, operand2);
                break;
            case 3:
                calculator.Multiply(operand1, operand2);
                break;
            case 4:
                calculator.Divide(operand1, operand2);
                break;
            case 5:
                calculator.Modulus(operand1, operand2);
                break;
            case 6:
                calculator.Power(operand1, operand2);
                break;
            case 7:
                calculator.SquareRoot(operand1);
                break;
            case 8:
                calculator.Logarithm(operand1);
                break;
        }

        ShowResult(calculator.GetResult());
    }
}

class Program
{
    static void Main(string[] args)
    {
        Calculator myCalculator = new Calculator();
        UserInterface.PerformOperation(myCalculator);
    }
}
