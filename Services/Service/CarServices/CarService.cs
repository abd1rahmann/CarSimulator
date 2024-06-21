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
        public void TurnLeft(Car car, Driver driver)
        {
            car.Direction = car.Direction switch
            {
                Direction.North => Direction.West,
                Direction.West => Direction.South,
                Direction.South => Direction.East,
                Direction.East => Direction.North,
                _ => car.Direction
            };
            driver.Tiredness++;
        }

        public void TurnRight(Car car, Driver driver)
        {
            car.Direction = car.Direction switch
            {
                Direction.North => Direction.East,
                Direction.East => Direction.South,
                Direction.South => Direction.West,
                Direction.West => Direction.North,
                _ => car.Direction
            };
            driver.Tiredness++;
        }

        public void DriveForward(Car car, Driver driver)
        {
            if (car.Fuel > 0)
            {
                car.Fuel--;
                driver.Tiredness++;
            }
            else
            {
                Console.WriteLine("Bensinen är slut. Du måste tanka bilen innan du kan köra vidare!");
            }
        }

        public void DriveBackward(Car car, Driver driver)
        {
            if (car.Fuel > 0)
            {
                car.Fuel--;
                driver.Tiredness++;
            }
            else
            {
                Console.WriteLine("Bensinen är slut. Du måste tanka bilen innan du kan köra vidare!");
            }
        }

        public void Refuel(Car car, Driver driver)
        {
            car.Fuel = Car.MaxFuel;
            driver.Tiredness += 2;
        }
    }

}
