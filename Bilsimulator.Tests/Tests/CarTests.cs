using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bilsimulator;
using Services.Service.CarServices;
using Services.Service.DriverServices;

namespace Bilsimulator.Tests
{
    [TestClass]
    public class CarTests
    {
        private ICarService carService;
        private IDriverService driverService;
        private Car car;
        private Driver driver;

        [TestInitialize]
        public void Setup()
        {
            carService = new CarService(driverService);
            car = new Car();
            driver = new Driver();
        }

        [TestMethod]
        public void TurnLeft_ShouldChangeDirection()
        {
            car.Direction = Direction.North;
            carService.TurnLeft(car, driver);
            Assert.AreEqual(Direction.West, car.Direction);
        }

        [TestMethod]
        public void TurnRight_ShouldChangeDirection()
        {
            car.Direction = Direction.North;
            carService.TurnRight(car, driver);
            Assert.AreEqual(Direction.East, car.Direction);
        }

        [TestMethod]
        public void DriveForward_ShouldReduceFuel()
        {
            car.Fuel = 10;
            carService.DriveForward(car, driver);
            Assert.AreEqual(9, car.Fuel);
        }

        [TestMethod]
        public void DriveForward_ShouldNotDriveWhenNoFuel()
        {
            car.Fuel = 0;
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                carService.DriveForward(car, driver);
                var result = sw.ToString().Trim();
                Assert.AreEqual("Bensinen är slut. Du måste tanka bilen innan du kan köra vidare!", result);
            }
        }

        [TestMethod]
        public void Refuel_ShouldFillFuel()
        {
            car.Fuel = 0;
            carService.Refuel(car, driver);
            Assert.AreEqual(Car.MaxFuel, car.Fuel);
        }
    }
}
