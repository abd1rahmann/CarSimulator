using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Service.DriverServices;

public class Driver
{
    public int Tiredness { get; set; } = 0;
    public const int MaxTiredness = 10;
    public const int WarningTiredness = 8;
}
