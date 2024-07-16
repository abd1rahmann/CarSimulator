using Services.Service.CarServices;

namespace Services.Service.DriverServices
{
    public class DriverService : IDriverService
    {
        private const int MaxTiredness = 10;

        public int SetRest(Driver driver)
        {
            if (driver.Tired)
            {
                string redo = "";

                while (redo.ToLower() != "j")
                {
                    Console.WriteLine("\nFöraren måste vila. Tryck på (J) för att fortsätta köra");
                    redo = Console.ReadLine().ToLower();
                }

                driver.Tiredness = 0;
                driver.Tired = false;
            }
            else
            {
                driver.Tiredness -= 2;
                if (driver.Tiredness < 0)
                {
                    driver.Tiredness = 0;
                }
            }

            return driver.Tiredness;
        }

        public void CheckFatigue(Driver driver)
        {
            if (driver.Tiredness > MaxTiredness)
            {
                driver.Tiredness = MaxTiredness;
            }

            if (driver.Tiredness >= Driver.MaxTiredness)
            {
                Console.WriteLine("\nFöraren är extremt trött. Det är farligt att köra. Ta en lång rast!\n");
                driver.Tired = true;
            }
            else if (driver.Tiredness == Driver.WarningTiredness)
            {
                Console.WriteLine("\nFöraren är väldigt trött. Det är dags för en rast!\n");
            }
        }
    }
}
