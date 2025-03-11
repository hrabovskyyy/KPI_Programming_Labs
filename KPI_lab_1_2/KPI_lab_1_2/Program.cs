//Написати програму для пошуку однакових значень пари ключ-значення.
//Вхідний словник записати у JSON






using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

class DictionarySearch
{
    public static Dictionary<string, List<string>> FindDuplicateValues(Dictionary<string, string> inputDict)
    {
        return inputDict.GroupBy(pair => pair.Value)
                        .Where(group => group.Count() > 1)
                        .ToDictionary(group => group.Key, group => group.Select(pair => pair.Key).ToList());
    }

    public static void SaveToJson<T>(T dictionary, string filePath)
    {
        try
        {
            string json = JsonConvert.SerializeObject(dictionary, Formatting.Indented);
            File.WriteAllText(filePath, json);
            Console.WriteLine($"✅ Дані успішно збережено у файл: {filePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Помилка збереження JSON: {ex.Message}");
        }
    }

    public static Dictionary<string, string> LoadFromJson(string filePath)
    {
        try
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("⚠️ Файл не знайдено. Буде створено новий словник.");
                return new Dictionary<string, string>();
            }
            
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(json) ?? new Dictionary<string, string>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Помилка завантаження JSON: {ex.Message}");
            return new Dictionary<string, string>();
        }
    }

    static void Main()
    {
        Console.WriteLine("🚀 Вітаємо у програмі пошуку дублікатів значень у словнику!");
        
        string inputFilePath = "inputDictionary.json";
        Dictionary<string, string> inputDict = LoadFromJson(inputFilePath);
        
        if (inputDict.Count == 0)
        {
            inputDict = new Dictionary<string, string>
            {
                {"A", "🍏 Apple"},
                {"B", "🍌 Banana"},
                {"C", "🍒 Cherry"},
                {"D", "🍏 Apple"},
                {"E", "🍌 Banana"},
                {"F", "🍇 Grape"},
                {"G", "🍑 Peach"},
                {"H", "🍒 Cherry"}
            };
        }
        
        Console.WriteLine("🔍 Пошук однакових значень у словнику...");
        Dictionary<string, List<string>> duplicates = FindDuplicateValues(inputDict);
        
        if (duplicates.Count > 0)
        {
            Console.WriteLine("✅ Знайдені дублікати:");
            foreach (var pair in duplicates)
            {
                Console.WriteLine($"🔹 Значення \"{pair.Key}\" знайдено у ключах: {string.Join(", ", pair.Value)}");
            }
        }
        else
        {
            Console.WriteLine("❌ Дублікатів не знайдено.");
        }
        
        SaveToJson(inputDict, inputFilePath);
        SaveToJson(duplicates, "duplicates.json");
        
        Console.WriteLine("🎯 Завершено! Дані збережено у JSON-файли.");
    }
}
