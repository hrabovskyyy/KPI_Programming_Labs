//Зберігає створений об’єкт класу з Завдання 1 у JSON файл 
//Відкриває JSON файл з даними та створює об’єкт класу з цими даними для виконання Завдання 1.



using System;
using System.IO;
using System.Text.Json;

class MyClass
{
    private int number;
    private string text;

    public MyClass()
    {
        number = 0;
        text = "Default";
        Console.WriteLine("✅ Об'єкт створено за замовчуванням");
    }

    public MyClass(int num, string txt)
    {
        number = num;
        text = txt;
        Console.WriteLine($"✅ Об'єкт створено: number = {number}, text = \"{text}\"");
    }

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

    public void Display()
    {
        Console.WriteLine($"📌 Об'єкт: number = {number}, text = \"{text}\"");
    }

    public void SaveToJson(string filename)
    {
        string json = JsonSerializer.Serialize(this);
        File.WriteAllText(filename, json);
        Console.WriteLine("💾 Об'єкт збережено у JSON-файл: " + filename);
    }

    public static MyClass LoadFromJson(string filename)
    {
        if (File.Exists(filename))
        {
            string json = File.ReadAllText(filename);
            MyClass obj = JsonSerializer.Deserialize<MyClass>(json);
            Console.WriteLine("📂 Об'єкт відновлено з JSON-файлу: " + filename);
            return obj;
        }
        else
        {
            Console.WriteLine("❌ Файл не знайдено: " + filename);
            return null;
        }
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("🚀 Створюємо об'єкт класу MyClass...");
        MyClass obj = new MyClass(42, "Hello, JSON!");
        obj.Display();

        string filename = "myclass.json";
        obj.SaveToJson(filename);

        Console.WriteLine("🔄 Завантаження об'єкта з JSON...");
        MyClass loadedObj = MyClass.LoadFromJson(filename);
        loadedObj?.Display();
    }
}
