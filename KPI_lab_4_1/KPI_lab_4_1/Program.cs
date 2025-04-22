//Створити об'єкт класу Простий дріб, використовуючи клас Число, Знак. 
//Методи: висновок на екран, додавання, віднімання, множення, ділення.

using System;

public class Number
{
    public int Value { get; }

    public Number(int value)
    {
        Value = value;
    }

    public override string ToString() => Value.ToString();

    public override bool Equals(object obj)
    {
        Console.WriteLine("Метод Number.Equals викликано");
        return obj is Number other && Value == other.Value;
    }

    public override int GetHashCode() => Value.GetHashCode();
}

public class Sign
{
    public bool IsNegative { get; }

    public Sign(bool isNegative)
    {
        IsNegative = isNegative;
    }

    public int AsMultiplier() => IsNegative ? -1 : 1;

    public override string ToString() => IsNegative ? "-" : "+";

    public override bool Equals(object obj)
    {
        Console.WriteLine("Метод Sign.Equals викликано");
        return obj is Sign other && IsNegative == other.IsNegative;
    }

    public override int GetHashCode() => IsNegative.GetHashCode();
}

public class Fraction
{
    public Number Numerator { get; }
    public Number Denominator { get; }
    public Sign Sign { get; }

    public Fraction(Number numerator, Number denominator, Sign sign)
    {
        if (denominator.Value == 0)
            throw new ArgumentException("Знаменник не може бути нулем.");
        Numerator = numerator;
        Denominator = denominator;
        Sign = sign;
    }

    public void Print()
    {
        Console.WriteLine("Метод Print викликано:");
        Console.WriteLine(ToString());
    }

    public override string ToString()
    {
        string sign = Sign.IsNegative ? "-" : "";
        return $"{sign}{Numerator}/{Denominator}";
    }

    public override bool Equals(object obj)
    {
        Console.WriteLine("Метод Fraction.Equals викликано");
        return obj is Fraction other &&
               Numerator.Equals(other.Numerator) &&
               Denominator.Equals(other.Denominator) &&
               Sign.Equals(other.Sign);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Numerator, Denominator, Sign);
    }

    public Fraction Add(Fraction other)
    {
        Console.WriteLine("Метод Add викликано");
        int lcm = LCM(Denominator.Value, other.Denominator.Value);
        int mult1 = lcm / Denominator.Value;
        int mult2 = lcm / other.Denominator.Value;

        int val1 = Sign.AsMultiplier() * Numerator.Value * mult1;
        int val2 = other.Sign.AsMultiplier() * other.Numerator.Value * mult2;

        int resultNumerator = val1 + val2;
        bool isNegative = resultNumerator < 0;

        return new Fraction(
            new Number(Math.Abs(resultNumerator)),
            new Number(lcm),
            new Sign(isNegative)
        );
    }

    public Fraction Subtract(Fraction other)
    {
        Console.WriteLine("Метод Subtract викликано");
        var opposite = new Fraction(
            other.Numerator,
            other.Denominator,
            new Sign(!other.Sign.IsNegative)
        );
        return Add(opposite);
    }

    public Fraction Multiply(Fraction other)
    {
        Console.WriteLine("Метод Multiply викликано");

        int num = Numerator.Value * other.Numerator.Value;
        int den = Denominator.Value * other.Denominator.Value;
        bool isNegative = Sign.IsNegative ^ other.Sign.IsNegative;

        return new Fraction(
            new Number(num),
            new Number(den),
            new Sign(isNegative)
        );
    }

    public Fraction Divide(Fraction other)
    {
        Console.WriteLine("Метод Divide викликано");
        if (other.Numerator.Value == 0)
            throw new DivideByZeroException("Ділення на нуль!");

        return Multiply(new Fraction(
            other.Denominator,
            other.Numerator,
            other.Sign
        ));
    }

    private static int GCD(int a, int b)
    {
        while (b != 0)
        {
            int t = b;
            b = a % b;
            a = t;
        }
        return a;
    }

    private static int LCM(int a, int b) => a * b / GCD(a, b);
}

class Program
{
    static void Main()
    {
        var frac1 = new Fraction(new Number(1), new Number(2), new Sign(false));
        var frac2 = new Fraction(new Number(1), new Number(3), new Sign(true));

        frac1.Print();
        frac2.Print();

        var sum = frac1.Add(frac2);
        Console.Write("Сума: "); sum.Print();

        var diff = frac1.Subtract(frac2);
        Console.Write("Різниця: "); diff.Print();

        var product = frac1.Multiply(frac2);
        Console.Write("Добуток: "); product.Print();

        var quotient = frac1.Divide(frac2);
        Console.Write("Частка: "); quotient.Print();
    }
}
