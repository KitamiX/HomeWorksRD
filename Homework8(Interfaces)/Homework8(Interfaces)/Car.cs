using Homework8_Interfaces_.Interfaces;
using Homework8_Interfaces_.Services;

namespace Homework8_Interfaces_;

public abstract class Car
{
    protected int SpeedUpSpeed { get; }
    protected int SlowDownSpeed { get; }
    protected int MaxSpeed { get; } 
    protected bool SeatHeaterStatus;
    protected bool RadioStatus;
    protected double StationFreq {  get; set; }
    protected ISeats Seats = new Seats();
    protected IRadio Radio = new Radio();

    protected Car(int speedUp, int slowDownSpeed, int maxSpeed)
    {
        SpeedUpSpeed = speedUp;
        SlowDownSpeed = slowDownSpeed;
        MaxSpeed = maxSpeed;
    }

    public abstract void GetSpeed();
    public abstract int SpeedUp();
    public abstract int SlowDown();
    public abstract void GetCarProp();
    public abstract double GetStationFreq();
    public abstract void ChangeStation();
    public abstract void AdjustPosition();
    public bool HeaterOn()
    {
        Seats.HeatOn(SeatHeaterStatus);
        return SeatHeaterStatus = true;
    }
    public bool HeaterOff()
    {
        Seats.HeatOff(SeatHeaterStatus);
        return SeatHeaterStatus = false;
    }
    public bool RadioOn()
    {
        Radio.TurnOn(RadioStatus);
        return RadioStatus = true;
    }
    public bool RadioOff()
    {
        Radio.TurnOff(RadioStatus);
        return RadioStatus = false;
    }
    public string RadioStatusMessage() => RadioStatus ? "ON" : "OFF";
    public string SeatHeaterStatusMessage() => SeatHeaterStatus ? "ON" : "OFF";

}

public class Audi : Car
{
    private static string Model => "Audi";
    private int Acceleration { get; }
    private int Deceleration { get; }
    private int MaxCarSpeed { get; }
    private int CurrentSpeed { get; set; }

    public Audi() : base(15, 8, 100)
    {
        MaxCarSpeed = MaxSpeed;
        Acceleration = SpeedUpSpeed;
        Deceleration = SlowDownSpeed;
    }

    public override int SpeedUp()
    {
        if (CurrentSpeed >= MaxCarSpeed)
        {
            Console.WriteLine("Car can't move faster!!!");
            Console.ReadLine();
        }
        else if (CurrentSpeed + Acceleration >= MaxCarSpeed)
            CurrentSpeed = MaxCarSpeed;
        else CurrentSpeed += Acceleration;
        return CurrentSpeed;
    }
    public override void GetSpeed()
    {
        Console.WriteLine($"CurrentSpeed of your car({Model}): {CurrentSpeed}");
    }
    public override int SlowDown()
    {
        if (CurrentSpeed <= 0)
        {
            Console.WriteLine("Car doesn't' move!!!");
            Console.ReadLine();
        }
        else if (CurrentSpeed - Deceleration <= 0)
            CurrentSpeed = 0;
        else CurrentSpeed -= Deceleration;
        return CurrentSpeed;
    }
    public override void GetCarProp()
    {
        Console.WriteLine($"Model: {Model}");
        Console.WriteLine($"MaxSpeed: {MaxCarSpeed}");
        Console.WriteLine($"SpeedUP/SlowDown Speed: {Acceleration}/{Deceleration}");
    }
    public override double GetStationFreq()
    {
        return StationFreq;
    }
    public override void ChangeStation()
    {
        Console.WriteLine(Model + " frequency diapason: 101,1 - 150,8");
        Console.Write("Enter new station frequency: ");
        StationFreq = double.Parse(Console.ReadLine()!);
        if (StationFreq is >= 101.1 and <= 150.8)
            Radio.ChangeStation(StationFreq);
        else
            Console.WriteLine($"{Model} doesn't support this station frequency: {StationFreq}");
        Console.ReadLine();
    }
    public override void AdjustPosition()
    {
        Console.WriteLine(Model + " Supports seat adjustment from 15 to 75 degrees");
        Console.Write("Enter new seat position ");
        var seatPos = int.Parse(Console.ReadLine()!);
        if(seatPos is >= 15 and <= 75)
            Seats.AdjustPosition(seatPos);
        else
            Console.WriteLine(Model + " doesn't support this seat position: " + seatPos + " degrees");
        Console.ReadLine();
    }
}
public class Bmw : Car
{
    private static string Model => "BMW";
    private int Acceleration { get; }
    private int Deceleration { get; }
    private int MaxCarSpeed { get; }
    private int CurrentSpeed { get; set; }

    public Bmw() : base(5, 2, 30)
    {
        MaxCarSpeed = MaxSpeed;
        Acceleration = SpeedUpSpeed;
        Deceleration = SlowDownSpeed;
    }

    public override int SpeedUp()
    {
        if (CurrentSpeed >= MaxCarSpeed)
        {
            Console.WriteLine("Car can't move faster!!!");
            Console.ReadLine();
        }
        else if (CurrentSpeed + Acceleration >= MaxCarSpeed)
            CurrentSpeed = MaxCarSpeed;
        else CurrentSpeed += Acceleration;
        return CurrentSpeed;
    }
    public override void GetSpeed()
    {
        Console.WriteLine($"CurrentSpeed of your car({Model}): {CurrentSpeed}");
    }

    public override int SlowDown()
    {
        if (CurrentSpeed <= 0)
        {
            Console.WriteLine("Car doesn't' move!!!");
            Console.ReadLine();
        }
        else if (CurrentSpeed - Deceleration <= 0)
            CurrentSpeed = 0;
        else CurrentSpeed -= Deceleration;
        return CurrentSpeed;
    }

    public override void GetCarProp()
    {
        Console.WriteLine($"Model: {Model}");
        Console.WriteLine($"MaxSpeed: {MaxCarSpeed}");
        Console.WriteLine($"SpeedUP/SlowDown Speed: {Acceleration}/{Deceleration}");
    }
    public override double GetStationFreq()
    {
        return StationFreq;
    }
    public override void ChangeStation()
    {
        Console.WriteLine(Model + " frequency diapason: 101,1 - 150,8");
        Console.Write("Enter new station frequency: ");
        StationFreq = double.Parse(Console.ReadLine()!);
        if (StationFreq is >= 80.0 and <= 120.5)
            Radio.ChangeStation(StationFreq);
        else
            Console.WriteLine($"{Model} doesn't support this station frequency: {StationFreq}");
        Console.ReadLine();
    }
    public override void AdjustPosition()
    {
        Console.WriteLine(Model + " Supports seat adjustment from 30 to 45 degrees");
        Console.Write("Enter new seat position ");
        var seatPos = int.Parse(Console.ReadLine()!);
        if (seatPos is >= 30 and <= 45)
            Seats.AdjustPosition(seatPos);
        else
            Console.WriteLine(Model + " doesn't support this seat position: " + seatPos + " degrees");
        Console.ReadLine();
    }
}