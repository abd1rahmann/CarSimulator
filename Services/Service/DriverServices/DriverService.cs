using Services.Service.CarServices;


namespace Services.Service.DriverServices
{
    public class DriverService : IDriverService
    {
        public void Rest(Driver driver)
        {
            driver.Tiredness = Math.Max(0, driver.Tiredness - 2);
        }

        public void CheckFatigue(Driver driver)
        {
            if (driver.Tiredness >= Driver.MaxTiredness)
            {
                Console.WriteLine("Föraren är extremt trött. Det är farligt att köra. Ta en lång rast!");
            }
            else if (driver.Tiredness >= Driver.WarningTiredness)
            {
                Console.WriteLine("Föraren är väldigt trött. Det är dags för en rast!");
            }
        }
    }
}
