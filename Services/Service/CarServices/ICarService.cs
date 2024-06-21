using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Service.DriverServices;

namespace Services.Service.CarServices
{
    public interface ICarService
    {
        void TurnLeft(Car car, Driver driver);
        void TurnRight(Car car, Driver driver);
        void DriveForward(Car car, Driver driver);
        void DriveBackward(Car car, Driver driver);
        void Refuel(Car car, Driver driver);
    }

}
