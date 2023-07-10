using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework8_Interfaces_
{
    public abstract class Car
    {
        protected int SpeedUpSpeed { get; set; }
        protected int SlowDownSpeed { get; set; }
        protected int MaxSpeed { get; set; }
        protected bool seatHeaterStatus = false;
        protected bool radioStatus = false;
        protected double stationFreq {  get; set; }
        protected ISeats _seats = new Seats();
        protected IRadio _radio = new Radio();

        public Car(int speedUp, int slowDownSpeed, int maxSpeed)
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
            _seats.HeatOn(seatHeaterStatus);
            return seatHeaterStatus = true;
        }
        public bool HeaterOff()
        {
            _seats.HeatOff(seatHeaterStatus);
            return seatHeaterStatus = false;
        }
        public bool RadioOn()
        {
            _radio.TurnOn(radioStatus);
            return radioStatus = true;
        }
        public bool RadioOff()
        {
            _radio.TurnOff(radioStatus);
            return radioStatus = false;
        }
        public string RadioStatus() => radioStatus ? "ON" : "OFF";
        public string SeatHeaterStatus() => seatHeaterStatus ? "ON" : "OFF";

    }

    public class Audi : Car
    {
        private string _Model { get; set; } = "Audi";
        private int _SpeedUp { get; set; }
        private int _SlowDown { get; set; }
        private int _MaxSpeed { get; set; }
        private int _CurrentSpeed { get; set; } = 0;

        public Audi() : base(15, 8, 100)
        {
            _MaxSpeed = MaxSpeed;
            _SpeedUp = SpeedUpSpeed;
            _SlowDown = SlowDownSpeed;
        }

        public override int SpeedUp()
        {
            if (_CurrentSpeed >= _MaxSpeed)
            {
                Console.WriteLine("Car can't move faster!!!");
                Console.ReadLine();
            }
            else if (_CurrentSpeed + _SpeedUp >= _MaxSpeed)
                _CurrentSpeed = _MaxSpeed;
            else _CurrentSpeed += _SpeedUp;
            return _CurrentSpeed;
        }
        public override void GetSpeed()
        {
            Console.WriteLine($"CurrentSpeed of your car({_Model}): {_CurrentSpeed}");
        }
        public override int SlowDown()
        {
            if (_CurrentSpeed <= 0)
            {
                Console.WriteLine("Car doesnt' move!!!");
            }
            else if (_CurrentSpeed + _SlowDown <= 0)
                _CurrentSpeed = 0;
            else _CurrentSpeed -= _SlowDown;
            return _CurrentSpeed;
        }
        public override void GetCarProp()
        {
            Console.WriteLine($"Model: {_Model}");
            Console.WriteLine($"MaxSpeed: {_MaxSpeed}");
            Console.WriteLine($"SpeedUP/SlowDown Speed: {_SpeedUp}/{_SlowDown}");
        }
        public override double GetStationFreq()
        {
            return stationFreq;
        }
        public override void ChangeStation()
        {
            Console.WriteLine(_Model + " frequency diapason: 101,1 - 150,8");
            Console.Write("Enter new station frequency: ");
            stationFreq = double.Parse(Console.ReadLine());
            if (stationFreq >= 101.1 && stationFreq <= 150.8)
                _radio.ChangeStation(stationFreq);
            else
                Console.WriteLine($"{_Model} doesnt support this station frequency: {stationFreq}");
                Console.ReadLine();
        }
        public override void AdjustPosition()
        {
            Console.WriteLine(_Model + " Supports seat adjustment from 15 to 75 degrees");
            Console.Write("Enter new seat position ");
            var seatPos = int.Parse(Console.ReadLine());
            if(seatPos >= 15 && seatPos <= 75)
                _seats.AdjustPosition(seatPos);
            else
                Console.WriteLine(_Model + " doesnt support this seat position: " + seatPos + "degrees");
            Console.ReadLine();
        }
    }
    public class BMW : Car
    {
        private string _Model { get; set; } = "BMW";
        private int _SpeedUp { get; set; }
        private int _SlowDown { get; set; }
        private int _MaxSpeed { get; set; }
        private int _CurrentSpeed { get; set; } = 0;

        public BMW() : base(5, 2, 30)
        {
            _MaxSpeed = MaxSpeed;
            _SpeedUp = SpeedUpSpeed;
            _SlowDown = SlowDownSpeed;
        }

        public override int SpeedUp()
        {
            if (_CurrentSpeed >= _MaxSpeed)
            {
                Console.WriteLine("Car can't move faster!!!");
                Console.ReadLine();
            }
            else if (_CurrentSpeed + _SpeedUp >= _MaxSpeed)
                _CurrentSpeed = _MaxSpeed;
            else _CurrentSpeed += _SpeedUp;
            return _CurrentSpeed;
        }
        public override void GetSpeed()
        {
            Console.WriteLine($"CurrentSpeed of your car({_Model}): {_CurrentSpeed}");
        }

        public override int SlowDown()
        {
            if (_CurrentSpeed <= 0)
            {
                Console.WriteLine("Car doesnt' move!!!");
            }
            else if (_CurrentSpeed + _SlowDown <= 0)
                _CurrentSpeed = 0;
            else _CurrentSpeed -= _SlowDown;
            return _CurrentSpeed;
        }

        public override void GetCarProp()
        {
            Console.WriteLine($"Model: {_Model}");
            Console.WriteLine($"MaxSpeed: {_MaxSpeed}");
            Console.WriteLine($"SpeedUP/SlowDown Speed: {_SpeedUp}/{_SlowDown}");
        }
        public override double GetStationFreq()
        {
            return stationFreq;
        }
        public override void ChangeStation()
        {
            Console.WriteLine(_Model + " frequency diapason: 101,1 - 150,8");
            Console.Write("Enter new station frequency: ");
            _radio.ChangeStation(double.Parse(Console.ReadLine()));
            if (stationFreq >= 80.0 && stationFreq <= 120.5)
                _radio.ChangeStation(stationFreq);
            else
                Console.WriteLine($"{_Model} doesnt support this station frequency: {stationFreq}");
                Console.ReadLine();
        }
        public override void AdjustPosition()
        {
            Console.WriteLine(_Model + " Supports seat adjustment from 30 to 45 degrees");
            Console.Write("Enter new seat position ");
            var seatPos = int.Parse(Console.ReadLine());
            if (seatPos >= 30 && seatPos <= 45)
                _seats.AdjustPosition(seatPos);
            else
                Console.WriteLine(_Model + " doesnt support this seat position: " + seatPos + "degrees");
            Console.ReadLine();
        }
    }
}
