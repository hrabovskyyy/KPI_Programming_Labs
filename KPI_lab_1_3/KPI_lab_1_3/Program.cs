//Дана строкова послідовність. Знайти суму довжин усіх рядків,
//що входять в дану послідовність.




using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<string> stringSequence = new List<string>
        {
            "Hello",
            "World",
            "LINQ",
            "is",
            "awesome",
            "C#",
            "Code",
            "Efficiency",
            "Optimization"
        };
        
        Console.WriteLine("🚀 Вітаємо у програмі підрахунку довжин рядків з використанням LINQ!");
        Console.WriteLine("🔍 Виконуємо обчислення...");
        
        int totalLength = stringSequence.Sum(s => s.Length);
        int minLength = stringSequence.Min(s => s.Length);
        int maxLength = stringSequence.Max(s => s.Length);
        double averageLength = stringSequence.Average(s => s.Length);
        
        Console.WriteLine($"✅ Загальна довжина всіх рядків: {totalLength}");
        Console.WriteLine($"📏 Мінімальна довжина рядка: {minLength}");
        Console.WriteLine($"📏 Максимальна довжина рядка: {maxLength}");
        Console.WriteLine($"📊 Середня довжина рядка: {averageLength:F2}");
        
        Console.WriteLine("🎯 Завершено! Дякуємо, що скористалися LINQ! 🚀");
    }
}