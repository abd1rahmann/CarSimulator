using Services.Service.CarServices;
using Services.Service.DriverServices;

namespace Bilsimulator
{
    public class Menu
    {
        private readonly IDriverService driverService;
        private readonly ICarService carService;
        private readonly Driver driver;
        private readonly Car car;

        public Menu(IDriverService driverService, ICarService carService)
        {
            this.driverService = driverService;
            this.carService = carService;
            car = new Car();
            driver = new Driver();
        }

        public void Start()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Tillgängliga kommandon:");
                Console.WriteLine("1. Sväng vänster");
                Console.WriteLine("2. Sväng höger");
                Console.WriteLine("3. Köra framåt");
                Console.WriteLine("4. Backa");
                Console.WriteLine("5. Rasta");
                Console.WriteLine("6. Tanka bilen");
                Console.WriteLine("7. Avsluta");
                Console.Write("Vad vill du göra härnäst? (ange siffra): ");
                string command = Console.ReadLine();

                switch (command)
                {
                    case "1":
                        carService.TurnLeft(car, driver);
                        break;
                    case "2":
                        carService.TurnRight(car, driver);
                        break;
                    case "3":
                        carService.DriveForward(car, driver);
                        break;
                    case "4":
                        carService.DriveBackward(car, driver);
                        break;
                    case "5":
                        driverService.Rest(driver);
                        break;
                    case "6":
                        carService.Refuel(car, driver);
                        break;
                    case "7":
                        return;
                    default:
                        Console.WriteLine("Ogiltigt kommando. Försök igen.");
                        break;
                }

                driverService.CheckFatigue(driver);

                Console.WriteLine($"Bilens riktning: {car.Direction}");
                Console.WriteLine($"Bensin: {car.Fuel}/{Car.MaxFuel}");
                Console.WriteLine($"Förarens trötthet: {driver.Tiredness}/{Driver.MaxTiredness}");
                Console.WriteLine("Tryck på valfri tangent för att fortsätta...");
                Console.ReadKey();
            }
        }
    }
}
