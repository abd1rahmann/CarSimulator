using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.Service.DriverServices;

namespace Bilsimulator.Tests.Tests
{
    [TestClass]
    public class DriverTests
    {
        /*private IDriverService driverService;
        private Driver driver;

        [TestInitialize]
        public void Setup()
        {
            driverService = new DriverService();
            driver = new Driver();
        }
        */

        [TestMethod]
        public void When_Driver_Is_Tired_SetRest_Should_Reset_Tiredness_To_1()
        {
            //Arrange
            var driver = new Driver();
            var driverService = new DriverService();


            driver.Tiredness = 10; // This shows that the driver is tired
            driver.Tired = true; // A flag to set driver tiredness

            string input = "J";

            using (var sw = new StringWriter())
            {
                using (var sr = new StringReader(input))
                {
                    Console.SetOut(sw);
                    Console.SetIn(sr);

                    // Act
                    var result = driverService.SetRest(driver);

                    // Assert
                    Assert.AreEqual(1, result);
                }
            }

        }

        
        [TestMethod]
        public void When_Driver_Turns_SetRest_Should_Increase_By_1()
        {
            //Arrange
            var driver = new Driver();
            var driverService = new DriverService();


            driver.Tiredness = 1; // This shows that the driver is tired
            driver.Tired = false; // A flag to set driver tiredness

            // Act
             var result = driverService.SetRest(driver);

             // Assert
             Assert.AreEqual(2, result);

        }

    }
}
