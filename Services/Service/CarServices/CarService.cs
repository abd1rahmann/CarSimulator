using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Service.DriverServices;

namespace Services.Service.CarServices
{
    public class CarService : ICarService
    {
        private readonly IDriverService _driverService;

        public CarService(IDriverService driverService)
        {
            _driverService = driverService;
        }

        public void TurnLeft(Car car, Driver driver)
        {
            driver.Tiredness++;

            car.Direction = car.Direction switch
            {
                Direction.Norrut => Direction.Västerut,
                Direction.Västerut => Direction.Söderut,
                Direction.Söderut => Direction.Österut,
                Direction.Österut => Direction.Norrut,
                _ => car.Direction
            };
            if (car.Fuel > 0)
            {
                car.Fuel--;

            }
            else
            {
                Console.WriteLine("Bensinen är slut. Du måste tanka bilen innan du kan köra vidare!");
            }

        }

        public void TurnRight(Car car, Driver driver)
        {
            driver.Tiredness++;

            car.Direction = car.Direction switch
            {
                Direction.Norrut => Direction.Österut,
                Direction.Österut => Direction.Söderut,
                Direction.Söderut => Direction.Västerut,
                Direction.Västerut => Direction.Norrut,
                _ => car.Direction
            };
            if (car.Fuel > 0)
            {
                car.Fuel--;
            }
            else
            {
                Console.WriteLine("Bensinen är slut. Du måste tanka bilen innan du kan köra vidare!");
            }
        }

        public void DriveForward(Car car, Driver driver)
        {
            driver.Tiredness++;

            car.Direction = Direction.Norrut;
            

            if (car.Fuel > 0)
            {
                car.Fuel--;
            }
            else
            {
                Console.WriteLine("Bensinen är slut. Du måste tanka bilen innan du kan köra vidare!");
            }

        }

        public void DriveBackward(Car car, Driver driver)
        {
            driver.Tiredness++;

            car.Direction = car.Direction switch
            {
                Direction.Norrut => Direction.Söderut,
                Direction.Söderut => Direction.Norrut,
               
                _ => car.Direction
            };


            if (car.Fuel > 0)
            {
                car.Fuel--;

            }
            else
            {
                Console.WriteLine("Bensinen är slut. Du måste tanka bilen innan du kan köra vidare!");
            }

        }

        public void Refuel(Car car, Driver driver)
        {
            car.Fuel = Car.MaxFuel;
            driver.Tiredness++;
        }

      
    }

}
