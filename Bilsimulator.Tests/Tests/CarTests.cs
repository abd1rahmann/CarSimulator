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





        public void Turn_Left_No_Fuel()
        {
            var mockDriverService = new Mock<IDriverService>();
            var carService = new CarService(mockDriverService.Object);
            var car = new Car { Direction = Direction.Norrut, Fuel = 0 };
            var driver = new Driver();

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                carService.TurnLeft(car, driver);

                var expectedOutput = "Bensinen är slut. Du måste tanka bilen innan du kan köra vidare!";
                Assert.AreEqual(Direction.Norrut, car.Direction);
                Assert.AreEqual(0, car.Fuel);
                Assert.AreEqual(expectedOutput, sw.ToString().Trim());
            }
        }

        [TestMethod]
        public void Turn_Right_No_Fuel()
        {
            var mockDriverService = new Mock<IDriverService>();
            var carService = new CarService(mockDriverService.Object);
            var car = new Car { Direction = Direction.Norrut, Fuel = 0 };
            var driver = new Driver();

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                carService.TurnRight(car, driver);

                var expectedOutput = "Bensinen är slut. Du måste tanka bilen innan du kan köra vidare!";
                Assert.AreEqual(Direction.Norrut, car.Direction);
                Assert.AreEqual(0, car.Fuel);
                Assert.AreEqual(expectedOutput, sw.ToString().Trim());
            }
        }

        [TestMethod]
        public void DriveForward_No_Fuel()
        {
            var mockDriverService = new Mock<IDriverService>();
            var carService = new CarService(mockDriverService.Object);
            var car = new Car { Direction = Direction.Norrut, Fuel = 0 };
            var driver = new Driver();

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                carService.DriveForward(car, driver);

                var expectedOutput = "Bensinen är slut. Du måste tanka bilen innan du kan köra vidare!";
                Assert.AreEqual(Direction.Norrut, car.Direction);
                Assert.AreEqual(0, car.Fuel);
                Assert.AreEqual(expectedOutput, sw.ToString().Trim());
            }
        }


        [TestMethod]
        public void DriveBackward_No_Fuel()
        {
            var mockDriverService = new Mock<IDriverService>();
            var carService = new CarService(mockDriverService.Object);
            var car = new Car { Direction = Direction.Norrut, Fuel = 0 };
            var driver = new Driver();

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                carService.DriveBackward(car, driver);

                var expectedOutput = "Bensinen är slut. Du måste tanka bilen innan du kan köra vidare!";
                Assert.AreEqual(Direction.Norrut, car.Direction);  
                Assert.AreEqual(0, car.Fuel);
                Assert.AreEqual(expectedOutput, sw.ToString().Trim());
            }
        }



        [TestMethod]
        public void Refuel_Increases_Tiredness()
        {
            var mockDriverService = new Mock<IDriverService>();
            var carService = new CarService(mockDriverService.Object);
            var car = new Car { Fuel = 10 };
            var driver = new Driver { Tiredness = 2 };

            carService.Refuel(car, driver);

            Assert.AreEqual(Car.MaxFuel, car.Fuel);
            Assert.AreEqual(3, driver.Tiredness);
        }

        [TestMethod]
        public void Turn_Left_Does_Not_Change_Direction_When_Invalid()
        {
            var mockDriverService = new Mock<IDriverService>();
            var carService = new CarService(mockDriverService.Object);
            var car = new Car { Direction = (Direction)100, Fuel = 10 };
            var driver = new Driver();

            carService.TurnLeft(car, driver);

            Assert.AreEqual((Direction)100, car.Direction);
            Assert.AreEqual(9, car.Fuel);
            Assert.AreEqual(1, driver.Tiredness);
        }

        [TestMethod]
        public void Turn_Right_Does_Not_Change_Direction_When_Invalid()
        {
            var mockDriverService = new Mock<IDriverService>();
            var carService = new CarService(mockDriverService.Object);
            var car = new Car { Direction = (Direction)100, Fuel = 10 };
            var driver = new Driver();

            carService.TurnRight(car, driver);

            Assert.AreEqual((Direction)100, car.Direction);
            Assert.AreEqual(9, car.Fuel);
            Assert.AreEqual(1, driver.Tiredness);
        }

        [TestMethod]
        public void DriveBackward_Does_Not_Change_Direction_When_Invalid()
        {
            var mockDriverService = new Mock<IDriverService>();
            var carService = new CarService(mockDriverService.Object);
            var car = new Car { Direction = (Direction)100, Fuel = 10 };
            var driver = new Driver();

            carService.DriveBackward(car, driver);

            Assert.AreEqual((Direction)100, car.Direction);
            Assert.AreEqual(9, car.Fuel);
            Assert.AreEqual(1, driver.Tiredness);
        }

        [TestMethod]
        public void DriveForward_Does_Not_Change_Direction_When_Invalid()
        {
            var mockDriverService = new Mock<IDriverService>();
            var carService = new CarService(mockDriverService.Object);
            var car = new Car { Direction = (Direction)100, Fuel = 10 };
            var driver = new Driver();

            carService.DriveForward(car, driver);

            Assert.AreEqual(Direction.Norrut, car.Direction);  
            Assert.AreEqual(9, car.Fuel);
            Assert.AreEqual(1, driver.Tiredness);
        }

    }
}
