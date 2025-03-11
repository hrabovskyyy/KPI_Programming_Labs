//Створити клас з двома змінними.
//Додати конструктор з вхідними параметрами.
//Додати конструктор, який ініціалізує члени класу за замовчуванням.
//Додати деструктор, що виводить на екран повідомлення про видалення об’єкту.




using System;

class MyClass
{
    private int number;
    private string text;

    // Конструктор за замовчуванням
    public MyClass()
    {
        number = 0;
        text = "Default";
        Console.WriteLine("✅ Об'єкт створено за замовчуванням");
    }

    // Конструктор з параметрами
    public MyClass(int num, string txt)
    {
        number = num;
        text = txt;
        Console.WriteLine($"✅ Об'єкт створено: number = {number}, text = \"{text}\"");
    }

    // Властивості для доступу до змінних
    public int Number
    {
        get => number;
        set
        {
            number = value;
            Console.WriteLine($"🔹 Number оновлено: {number}");
        }
    }

    public string Text
    {
        get => text;
        set
        {
            text = value;
            Console.WriteLine($"🔹 Text оновлено: \"{text}\"");
        }
    }

    // Метод для виводу інформації про об'єкт
    public void Display()
    {
        Console.WriteLine($"📌 Об'єкт: number = {number}, text = \"{text}\"");
    }

    // Деструктор
    ~MyClass()
    {
        Console.WriteLine($"❌ Об'єкт (number = {number}, text = \"{text}\") знищено");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("🚀 Створюємо об'єкти класу MyClass...");
        
        MyClass obj1 = new MyClass();
        obj1.Display();
        
        MyClass obj2 = new MyClass(42, "Hello, World!");
        obj2.Display();
        
        Console.WriteLine("🛠 Використання властивостей для оновлення об'єкта obj1...");
        obj1.Number = 99;
        obj1.Text = "Updated Text";
        obj1.Display();
        
        Console.WriteLine("🎯 Завершення програми. Об'єкти будуть видалені при завершенні.");
    }
}