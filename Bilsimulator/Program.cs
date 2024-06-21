using Services.Service.CarServices;
using Services.Service.DriverServices;



namespace Bilsimulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IDriverService driverService = new DriverService();
            ICarService carService = new CarService();

            Menu menu = new Menu(driverService, carService);

            menu.Start();
        }
    }
}
