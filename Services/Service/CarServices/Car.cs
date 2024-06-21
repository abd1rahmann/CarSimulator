using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Service.CarServices;

public class Car
{   
    public int Fuel { get; set; } = MaxFuel;
    public const int MaxFuel = 20;
    public Direction Direction { get; set; } = Direction.North;
}

public enum Direction
{
    North,
    South,
    West,
    East
}
