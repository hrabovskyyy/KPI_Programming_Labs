// Реалізувати клас, що моделює роботу N-містної автостоянки.
// Машина під'їжджає до певного місця і їде вгору, поки не зустрінеться вільне місце.
// Клас повинен підтримувати методи, які обслуговують приїзд і від'їзд машини.

using System;
using System.Collections.Generic;

public class ParkingLot
{
    private int size;
    private bool[] spaces;
    
    public ParkingLot(int size)
    {
        this.size = size;
        spaces = new bool[size];
    }
    
    public int ParkCar()
    {
        for (int i = 0; i < size; i++)
        {
            if (!spaces[i])
            {
                spaces[i] = true;
                Console.WriteLine($"✅ Автомобіль припарковано на місці {i + 1}");
                return i + 1;
            }
        }
        Console.WriteLine("❌ Парковка заповнена! Спробуйте пізніше.");
        return -1;
    }
    
    public bool LeaveParking(int spotNumber)
    {
        if (spotNumber < 1 || spotNumber > size || !spaces[spotNumber - 1])
        {
            Console.WriteLine("⚠️ Некоректний номер місця або місце вже вільне.");
            return false;
        }
        
        spaces[spotNumber - 1] = false;
        Console.WriteLine($"🅿️ Місце {spotNumber} звільнено. Тепер воно доступне для паркування.");
        return true;
    }
    
    public void DisplayParkingLot()
    {
        Console.WriteLine("🚗 Стан парковки:");
        for (int i = 0; i < size; i++)
        {
            Console.Write(spaces[i] ? "[🚘] " : "[🟩] ");
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("🔹 Вітаємо на автостоянці! 🔹");
        ParkingLot parking = new ParkingLot(5);
        
        parking.ParkCar();
        parking.ParkCar();
        parking.ParkCar();
        parking.DisplayParkingLot();
        
        parking.LeaveParking(2);
        parking.DisplayParkingLot();
        
        parking.ParkCar();
        parking.DisplayParkingLot();
    }
}
