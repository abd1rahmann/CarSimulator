using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Service.CarServices;

namespace Services.Service.DriverServices
{
    public interface IDriverService
    {
        void Rest(Driver driver);
        void CheckFatigue(Driver driver);
    }
}
