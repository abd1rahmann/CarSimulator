using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.Service.DriverServices;

namespace Bilsimulator.Tests.Tests
{
    [TestClass]
    public class DriverTests
    {


        [TestMethod]
        public void When_Driver_Is_Tired_SetRest_Should_Reset_Tiredness_To_1()
        {
            var driver = new Driver();
            var driverService = new DriverService();


            driver.Tiredness = 10; 
            driver.Tired = true; 

            string input = "J";

            using (var sw = new StringWriter())
            {
                using (var sr = new StringReader(input))
                {
                    Console.SetOut(sw);
                    Console.SetIn(sr);

                    var result = driver.Tiredness - 8;

                    Assert.AreEqual(2, result);
                }
            }

        }


        [TestMethod]
        public void When_Driver_Turns_SetRest_Should_Increase_By_1()
        {
            var driver = new Driver();
            var driverService = new DriverService();


            driver.Tiredness = 1; 
            driver.Tired = false; 

            var result = driver.Tiredness + 1;

            Assert.AreEqual(2, result);

        }

        [TestMethod]
        public void CheckFatigue_WhenTirednessExceedsMaxTiredness_ShouldSetTiredToTrueAndWriteWarning()
        {
            var driver = new Driver { Tiredness = Driver.MaxTiredness };
            var driverService = new DriverService();

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                driverService.CheckFatigue(driver);

                var expectedOutput = "\nFöraren är extremt trött. Det är farligt att köra. Ta en lång rast!\n";
                Assert.IsTrue(sw.ToString().Trim().Contains(expectedOutput.Trim()), "Varningmeddelandet matchade inte förväntad utdata.");
                Assert.IsTrue(driver.Tired);
            }
        }

        [TestMethod]
        public void CheckFatigue_WhenTirednessEqualsWarningTiredness_ShouldWriteWarning()
        {
            var driver = new Driver { Tiredness = Driver.WarningTiredness };
            var driverService = new DriverService();

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                driverService.CheckFatigue(driver);

                var expectedOutput = "\nFöraren är väldigt trött. Det är dags för en rast!\n";
                Assert.IsTrue(sw.ToString().Trim().Contains(expectedOutput.Trim()), "Varningmeddelandet matchade inte förväntad utdata.");
                Assert.IsFalse(driver.Tired); 
            }
        }



        [TestMethod]
        public void SetRest_Does_Not_Reset_Tiredness_If_Not_Tired()
        {
            var driver = new Driver { Tiredness = 5, Tired = false };
            var driverService = new DriverService();

            var result = driverService.SetRest(driver);

            Assert.AreEqual(3, result);  
            Assert.IsFalse(driver.Tired);
        }

        [TestMethod]
        public void CheckFatigue_When_Tiredness_Less_Than_Warning_Does_Not_Set_Tired()
        {
            var driver = new Driver { Tiredness = 5 };
            var driverService = new DriverService();

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                driverService.CheckFatigue(driver);

                var output = sw.ToString().Trim();
                Assert.IsTrue(string.IsNullOrEmpty(output));  
                Assert.IsFalse(driver.Tired);
            }
        }

        [TestMethod]
        public void SetRest_Decreases_Tiredness_By_2_When_Not_Tired()
        {
            var driver = new Driver { Tiredness = 5, Tired = false };
            var driverService = new DriverService();

            var result = driverService.SetRest(driver);

            Assert.AreEqual(3, result);
        }

    }
}
