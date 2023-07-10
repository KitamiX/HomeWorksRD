using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework8_Interfaces_
{
    public interface ISeats 
    {
        void AdjustPosition(int positionDegree);
        void HeatOn(bool status);
        void HeatOff(bool status);
    }
    public interface IRadio 
    {
        void TurnOn(bool status);
        void TurnOff(bool status);
        void ChangeStation(int stationFreq);
    }
}
