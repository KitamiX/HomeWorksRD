using Homework8_Interfaces_.Interfaces;

namespace Homework8_Interfaces_.Services
{
    public class Radio : IRadio
    {
        public void TurnOn(bool status)
        {
            Console.WriteLine(status ? "Radio is already ON" : "Radio is now ON!!!");
            Console.ReadLine();
        }
        public void TurnOff(bool status)
        {
            Console.WriteLine(!status ? "Radio is already OFF" : "Radio is now OFF!!!");
            Console.ReadLine();
        }
        public void ChangeStation (double stationFreq) 
        {
            Console.WriteLine($"Now playing {stationFreq} Mhz Radio Station");
        }
    }
}
