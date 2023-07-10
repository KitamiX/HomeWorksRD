using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework8_Interfaces_
{
    public class Seats : ISeats
    {
        public void HeatOn(bool status)
        {
            if (status)
                Console.WriteLine("Heater is already ON");
            else
                Console.WriteLine("Seat Heater is now ON!!!");
            Console.ReadLine();
        }
        public void HeatOff(bool status)
        {
            if (!status)
                Console.WriteLine("Heater is already OFF");
            else
                Console.WriteLine("Seat Heater is now OFF!!!");
            Console.ReadLine();
        }
        public void AdjustPosition(int positionDegree) 
        {
            Console.WriteLine($"Seat position was changed to {positionDegree} degrees");
        }
    }

    public class Radio : IRadio
    {
        public void TurnOn(bool status)
        {
            if (status)
                Console.WriteLine("Radio is already ON");
            else
                Console.WriteLine("Radio is now ON!!!");
            Console.ReadLine();
        }
        public void TurnOff(bool status)
        {
            if (!status)
                Console.WriteLine("Radio is already OFF");
            else
                Console.WriteLine("Radio is now OFF!!!");
            Console.ReadLine();
        }
        public void ChangeStation (double stationFreq) 
        {
            Console.WriteLine($"Now playing {stationFreq} Mhz Radio Station");
        }
    }
}
