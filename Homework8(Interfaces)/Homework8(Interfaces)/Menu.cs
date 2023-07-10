using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework8_Interfaces_
{
    public static class Menu
    {
        public static void Start()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("---###MENU###---");
                Console.WriteLine("---###CHOOSE_CAR###---");
                Console.WriteLine("1. Audi");
                Console.WriteLine("2. BMW");
                Console.WriteLine("3. Exit");
                Console.Write("\nWrite choosen menu option: ");
                int menu_key = Int32.Parse(Console.ReadLine());
                switch (menu_key)
                {
                    case 1:
                        CarMenu(new Audi());
                        break;
                    case 2:
                        CarMenu(new BMW());
                        break;
                    case 3:
                        return;
                    default:
                        Console.WriteLine("Choosen munu option must be in range 1 to 3");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadLine();
                        break;
                }

            }
        }

        public static void CarMenu(Car car)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("---###Car_MENU###---");
                Console.WriteLine("1. Show Car properties");
                Console.WriteLine("2. Speed Control");
                Console.WriteLine("3. Radio Control");
                Console.WriteLine("4. Seat Control");
                Console.WriteLine("5. Back to Main Menu");
                Console.Write("\nWrite choosen menu option: ");
                int menu_key = Int32.Parse(Console.ReadLine());
                switch (menu_key)
                {
                    case 1:
                        Console.Clear();
                        car.GetCarProp();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadLine();
                        break;
                    case 2:
                        SpeedControl(car);
                        break;
                    case 3:
                        RadioControl(car);
                        break;
                    case 4:
                        SeatControl(car);
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Choosen munu option must be in range 1 to 5");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadLine();
                        break;
                }
            }
        }
        public static void RadioControl(Car car)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("---###Radio_Control###---");
                Console.WriteLine("Radio Status: " + car.RadioStatus());
                if (car.RadioStatus() == "ON")
                    Console.WriteLine("Current Station : " + car.GetStationFreq());
                Console.WriteLine();
                Console.WriteLine("1. Turn ON Radio");
                Console.WriteLine("2. Turn OFF Radio");
                Console.WriteLine("3. Set Radio Frequency");
                Console.WriteLine("4. Back to Car Menu");
                Console.Write("\nWrite choosen menu option: ");
                int menu_key = Int32.Parse(Console.ReadLine());
                switch (menu_key)
                {
                    case 1:
                        car.RadioOn();
                        break;
                    case 2:
                        car.RadioOff();
                        break;
                    case 3:
                        car.ChangeStation();
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Choosen munu option must be in range 1 to 4");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadLine();
                        break;
                }
            }
        }
        public static void SpeedControl(Car car)
        {

            while (true)
            {
                Console.Clear();
                Console.WriteLine("---###Speed_Control###---");
                car.GetSpeed();
                Console.WriteLine("1. Speed Up");
                Console.WriteLine("2. Slow Down");
                Console.WriteLine("3. Back to Car Menu");
                Console.Write("\nWrite choosen menu option: ");
                int menu_key = Int32.Parse(Console.ReadLine());
                switch (menu_key)
                {
                    case 1:
                        car.SpeedUp();
                        break;
                    case 2:
                        car.SlowDown();
                        break;
                    case 3:
                        return;
                    default:
                        Console.WriteLine("Choosen munu option must be in range 1 to 3");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadLine();
                        break;
                }
            }
        }
        public static void SeatControl(Car car)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("---###Seat_Control###---");
                Console.WriteLine("Heater Status: " + car.SeatHeaterStatus());
                Console.WriteLine();
                Console.WriteLine("1. Turn ON Heater");
                Console.WriteLine("2. Turn OFF Heater");
                Console.WriteLine("3. Adjust Seat Position");
                Console.WriteLine("4. Back to Car Menu");
                Console.Write("\nWrite choosen menu option: ");
                int menu_key = Int32.Parse(Console.ReadLine());
                switch (menu_key)
                {
                    case 1:
                        car.HeaterOn();
                        break;
                    case 2:
                        car.HeaterOff();
                        break;
                    case 3:
                        car.AdjustPosition();
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Choosen munu option must be in range 1 to 4");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadLine();
                        break;
                }
            }
        }

    }
}
