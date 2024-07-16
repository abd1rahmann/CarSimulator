using Services.Service.CarServices;
using Services.Service.DriverServices;
using System.Net.Http;
using System.Text.Json;
using Services.Service.ConsoleService;

namespace Bilsimulator
{
    public class Menu
    {
        private readonly IDriverService driverService;
        private readonly ICarService carService;
        private readonly Driver driver;
        private readonly Car car;
        private readonly IConsole console;


        public Menu(IDriverService driverService, ICarService carService)
        {
            this.driverService = driverService;
            this.carService = carService;
            car = new Car();
            driver = new Driver();
            console = new ConsoleWrapper();
            
        }

        public async Task Start()
        {

            var apiUrl = "https://randomuser.me/api/";

            try
            {
                var userResponse = await GetUser(apiUrl);
                if (userResponse != null && userResponse.Results.Length > 0)
                {
                    var user = userResponse.Results[0];
                    var name = $"{user.Name.First} {user.Name.Last}";
                    driver.Name = name;
                }
                else
                {
                    Console.WriteLine("Could not fetch data from Api. User data is null.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            while (true)
            {
                Console.WriteLine("╔════════════════════════════════════════════╗");
                Console.WriteLine("║             Tillgängliga kommandon         ║");
                Console.WriteLine("╠════════════════════════════════════════════╣");
                Console.WriteLine("║ 1.  Sväng vänster                          ║");
                Console.WriteLine("║ 2.  Sväng höger                            ║");
                Console.WriteLine("║ 3.  Köra framåt                            ║");
                Console.WriteLine("║ 4.  Backa                                  ║");
                Console.WriteLine("║ 5.  Rasta                                  ║");
                Console.WriteLine("║ 6.  Tanka bilen                            ║");
                Console.WriteLine("║ 7.  Avsluta                                ║");
                Console.WriteLine("╚════════════════════════════════════════════╝");
                Console.Write($"\nHej, {driver.Name}! Vad vill du göra härnäst? (ange siffra): ");

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
                        driverService.SetRest(driver);
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

                Console.WriteLine("============================================");
                Console.WriteLine($" Förare: {driver.Name}");
                Console.WriteLine("============================================");
                Console.WriteLine($" Bilens riktning:     {car.Direction}");
                Console.WriteLine($" Bensin:              {car.Fuel}/{Car.MaxFuel}");
                Console.WriteLine($" Förarens trötthet:   {driver.Tiredness}/{Driver.MaxTiredness}");
                Console.WriteLine("============================================");
                Console.WriteLine(" Tryck på valfri tangent för att fortsätta...");
                Console.WriteLine("============================================");

                Console.ReadKey();
                console.Clear();

            }
        }

        public static async Task<UserResponse> GetUser(string apiUrl)
        {
            using var client = new HttpClient();
            var response = await client.GetStringAsync(apiUrl);

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                PropertyNameCaseInsensitive = true
            };

            var userResponse = JsonSerializer.Deserialize<UserResponse>(response, options);

            return userResponse;
        }

    }
}
