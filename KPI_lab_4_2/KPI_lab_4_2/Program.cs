//Продаж смартфонів. Визначити ієрархію телефонів.
//Відсортувати телефони по моделі, виробнику, розміру дисплея.
//Знайти телефон, який відповідає вказаним параметрам.
//Підрахувати загальну кількість девайсів на складі.
//Реалізувати пошук телефону по діапазону цін.


using System;
using System.Collections.Generic;
using System.Linq;

public class Device
{
    public string Model { get; set; }
    public string Manufacturer { get; set; }
    public double Price { get; set; }
    public double DisplaySize { get; set; }
    public int Quantity { get; set; }

    public Device(string model, string manufacturer, double price, double displaySize, int quantity)
    {
        Model = model;
        Manufacturer = manufacturer;
        Price = price;
        DisplaySize = displaySize;
        Quantity = quantity;
    }

    public override string ToString()
    {
        return $"{Manufacturer} {Model} | Дисплей: {DisplaySize}\" | Ціна: {Price} грн | Кількість: {Quantity}";
    }
}

public class Smartphone : Device
{
    public string OS { get; set; }
    public int RAM { get; set; }
    public bool Supports5G { get; set; }

    public Smartphone(string model, string manufacturer, double price, double displaySize, int quantity, string os, int ram, bool supports5G)
        : base(model, manufacturer, price, displaySize, quantity)
    {
        OS = os;
        RAM = ram;
        Supports5G = supports5G;
    }

    public override string ToString()
    {
        return base.ToString() + $" | ОС: {OS} | RAM: {RAM} ГБ | 5G: {(Supports5G ? "Так" : "Ні")}";
    }
}

public class InventoryService
{
    public List<Smartphone> Smartphones { get; set; } = new();

    public void AddSmartphone(Smartphone phone) => Smartphones.Add(phone);

    public void SortByModel() => Smartphones = Smartphones.OrderBy(p => p.Model).ToList();
    public void SortByManufacturer() => Smartphones = Smartphones.OrderBy(p => p.Manufacturer).ToList();
    public void SortByDisplaySize() => Smartphones = Smartphones.OrderBy(p => p.DisplaySize).ToList();

    public List<Smartphone> Search(string model, string manufacturer) =>
        Smartphones.Where(p => p.Model == model && p.Manufacturer == manufacturer).ToList();

    public List<Smartphone> SearchByPriceRange(double min, double max) =>
        Smartphones.Where(p => p.Price >= min && p.Price <= max).ToList();

    public int GetTotalQuantity() => Smartphones.Sum(p => p.Quantity);
}

class Program2
{
    static void Main()
    {
        var service = new InventoryService();
        service.AddSmartphone(new Smartphone("Galaxy S23", "Samsung", 30000, 6.1, 10, "Android", 8, true));
        service.AddSmartphone(new Smartphone("iPhone 14", "Apple", 40000, 6.1, 5, "iOS", 6, true));
        service.AddSmartphone(new Smartphone("Redmi Note 12", "Xiaomi", 12000, 6.5, 20, "Android", 4, true));

        Console.WriteLine("Всі смартфони:");
        service.Smartphones.ForEach(Console.WriteLine);

        Console.WriteLine("\nСортування за виробником:");
        service.SortByManufacturer();
        service.Smartphones.ForEach(Console.WriteLine);

        Console.WriteLine("\nПошук у діапазоні цін 10000 - 35000 грн:");
        var found = service.SearchByPriceRange(10000, 35000);
        found.ForEach(Console.WriteLine);

        Console.WriteLine($"\nЗагальна кількість на складі: {service.GetTotalQuantity()}");
    }
}
