namespace Homework8_Interfaces_
{
    internal class Program
    {
        public static void TestCar(Car car)
        {
            car.GetCarProp();
        }
        static void Main(string[] args)
        {
            TestCar(new Audi());
            TestCar(new BMW());
            Console.WriteLine("======================");
            var audi = new Audi();
            audi.SpeedUp();
            audi.SpeedUp();
            audi.SpeedUp();
            audi.SpeedUp();
            audi.SpeedUp();
            audi.SlowDown();
            audi.GetSpeed();
            Console.WriteLine("=====================");
            audi.HeaterOn();
            audi.HeaterOn();
            audi.HeaterOn();
            audi.HeaterOn();
            Console.WriteLine("=====================");
            audi.HeaterOff();
            audi.HeaterOff(); 
            audi.HeaterOff();
        }
    }
}