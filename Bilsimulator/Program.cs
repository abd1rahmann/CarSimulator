using Services.Service.CarServices;
using Services.Service.DriverServices;



namespace Bilsimulator
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            IDriverService driverService = new DriverService();
            ICarService carService = new CarService(driverService);

            Menu menu = new Menu(driverService, carService);

            await menu.Start();
        }
    }
}
