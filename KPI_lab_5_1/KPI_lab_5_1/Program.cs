// Interface for transport vehicles with doors
public interface IНаявністьДверей
{
    bool ЧиВідчиненіДвері();
}

// Abstract base class
public abstract class Transport
{
    public int Speed { get; protected set; }
    public int Wheels { get; protected set; }

    public Transport(int speed)
    {
        Speed = speed;
    }

    public abstract string GetTransportType();
}

// Intermediate class for two-wheeled transport
public abstract class TwoWheeledTransport : Transport
{
    public TwoWheeledTransport(int speed) : base(speed)
    {
        Wheels = 2;
    }
}

// Bicycle class
public class Bicycle : TwoWheeledTransport
{
    public Bicycle(int speed) : base(speed) { }

    public override string GetTransportType() => "Bicycle";
}

// Moped class
public class Moped : TwoWheeledTransport
{
    public Moped(int speed) : base(speed) { }

    public override string GetTransportType() => "Moped";
}

// Motorcycle class
public class Motorcycle : TwoWheeledTransport
{
    public Motorcycle(int speed) : base(speed) { }

    public override string GetTransportType() => "Motorcycle";
}

// Car class implementing door support
public class Car : Transport, IНаявністьДверей
{
    private bool doorsOpen;

    public Car(int speed, bool doorsOpen) : base(speed)
    {
        Wheels = 4;
        this.doorsOpen = doorsOpen;
    }

    public bool ЧиВідчиненіДвері() => doorsOpen;

    public override string GetTransportType() => "Car";
}

// Train class implementing door support
public class Train : Transport, IНаявністьДверей
{
    private bool doorsOpen;

    public Train(int speed, bool doorsOpen) : base(speed)
    {
        Wheels = 16;
        this.doorsOpen = doorsOpen;
    }

    public bool ЧиВідчиненіДвері() => doorsOpen;

    public override string GetTransportType() => "Train";
}

// Demo program
public class Program
{
    public static void Main()
    {
        List<Transport> transports = new List<Transport>
        {
            new Bicycle(20),
            new Moped(30),
            new Motorcycle(90),
            new Car(120, true),
            new Train(200, false)
        };

        foreach (var transport in transports)
        {
            Console.WriteLine($"Тип: {transport.GetTransportType()}, Швидкість: {transport.Speed} км/год, Коліс: {transport.Wheels}");

            if (transport is IНаявністьДверей withDoors)
            {
                Console.WriteLine($" - Двері відчинені: {withDoors.ЧиВідчиненіДвері()}");
            }
        }
    }
}
