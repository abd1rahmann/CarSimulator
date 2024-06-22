using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.Service.DriverServices;

namespace Bilsimulator.Tests.Tests
{
    [TestClass]
    public class DriverTests
    {
        private IDriverService driverService;
        private Driver driver;

        [TestInitialize]
        public void Setup()
        {
            driverService = new DriverService();
            driver = new Driver();
        }

        [TestMethod]
        public void Rest_ShouldReduceTiredness()
        {
            driver.Tiredness = 5;
            driverService.Rest(driver);
            Assert.AreEqual(3, driver.Tiredness);
        }

        [TestMethod]
        public void CheckFatigue_ShouldWarnWhenTired()
        {
            driver.Tiredness = Driver.WarningTiredness;
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                driverService.CheckFatigue(driver);
                var result = sw.ToString().Trim();
                Assert.AreEqual("Föraren är väldigt trött. Det är dags för en rast!", result);
            }
        }

        [TestMethod]
        public void CheckFatigue_ShouldAlertWhenExtremelyTired()
        {
            driver.Tiredness = Driver.MaxTiredness;
            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                driverService.CheckFatigue(driver);
                var result = sw.ToString().Trim();
                Assert.AreEqual("Föraren är extremt trött. Det är farligt att köra. Ta en lång rast!", result);
            }
        }
    }
}
