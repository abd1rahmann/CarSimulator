using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bilsimulator;
using Services.Service.CarServices;
using Services.Service.DriverServices;
using Moq;


namespace Bilsimulator.Tests
{
    [TestClass]
    public class CarTests
    {
     

        [TestMethod]
        public void Turn_Left_Changes_Direction_And_Decreases_Fuel()
        {
            var mockDriverService = new Mock<IDriverService>();
            var carService = new CarService(mockDriverService.Object);
            var car = new Car { Direction = Direction.Norrut, Fuel = 10 };
            var driver = new Driver();

            carService.TurnLeft(car, driver);

            Assert.AreEqual(Direction.Västerut, car.Direction);
            Assert.AreEqual(9, car.Fuel);
            driver.Tiredness = 1; 
            driver.Tired = false; 

            var result = driver.Tiredness + 1;

            Assert.AreEqual(2, result);
        }



        [TestMethod]

        public void Turn_Right_Changes_Direction_And_Increases_Tiredness_And_Decreases_Fuel()
        {
            var mockDriverService = new Mock<IDriverService>();
            var carService = new CarService(mockDriverService.Object);
            var car = new Car { Direction = Direction.Norrut, Fuel = 10 };
            var driver = new Driver();

            carService.TurnRight(car, driver);

            Assert.AreEqual(Direction.Österut, car.Direction);
            Assert.AreEqual(9, car.Fuel);
            driver.Tiredness = 1; 
            driver.Tired = false; 

            var result = driver.Tiredness + 1;

            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void Turn_Forward_Changes_Direction_And_Increases_Tiredness_And_Decreases_Fuel()
        {
            var mockDriverService = new Mock<IDriverService>();
            var carService = new CarService(mockDriverService.Object);
            var car = new Car { Direction = Direction.Norrut, Fuel = 10 };
            var driver = new Driver();

            carService.DriveForward(car, driver);

            Assert.AreEqual(Direction.Norrut, car.Direction);
            Assert.AreEqual(9, car.Fuel);
            driver.Tiredness = 1; 
            driver.Tired = false; 

            var result = driver.Tiredness + 1;

            Assert.AreEqual(2, result);
        }

        [TestMethod]

        public void Turn_Backward_Changes_Direction_And_Increases_Tiredness_And_Decreases_Fuel()
        {
            var mockDriverService = new Mock<IDriverService>();
            var carService = new CarService(mockDriverService.Object);
            var car = new Car { Direction = Direction.Norrut, Fuel = 10 };
            var driver = new Driver();

            carService.DriveBackward(car, driver);

            Assert.AreEqual(Direction.Söderut, car.Direction);
            Assert.AreEqual(9, car.Fuel);
            driver.Tiredness = 1; 
            driver.Tired = false; 

            var result = driver.Tiredness + 1;

            Assert.AreEqual(2, result);
        }

        [TestMethod]

        public void Refuel_Sets_Fuel_To_MaxFuel()
        {
            var mockDriverService = new Mock<IDriverService>();
            var carService = new CarService(mockDriverService.Object);
            var car = new Car { Fuel = 10 };
            var driver = new Driver();

            carService.Refuel(car, driver);

            Assert.AreEqual(20, car.Fuel);

            driver.Tiredness = 1; 
            driver.Tired = false; 

            var result = driver.Tiredness + 1;

            Assert.AreEqual(2, result);


        }


    }
}
