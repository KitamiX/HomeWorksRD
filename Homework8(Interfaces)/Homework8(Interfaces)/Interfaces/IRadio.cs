namespace Homework8_Interfaces_.Interfaces;

public interface IRadio 
{
    void TurnOn(bool status);
    void TurnOff(bool status);
    void ChangeStation(double stationFreq);
}