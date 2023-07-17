using Homework8_Interfaces_.Interfaces;

namespace Homework8_Interfaces_.Services;

public class Seats : ISeats
{
    public void HeatOn(bool status)
    {
        Console.WriteLine(status ? "Heater is already ON" : "Seat Heater is now ON!!!");
        Console.ReadLine();
    }
    public void HeatOff(bool status)
    {
        Console.WriteLine(!status ? "Heater is already OFF" : "Seat Heater is now OFF!!!");
        Console.ReadLine();
    }
    public void AdjustPosition(int positionDegree)
    {
        Console.WriteLine($"Seat position was changed to {positionDegree} degrees");
    }
}