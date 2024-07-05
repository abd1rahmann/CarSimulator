using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Service.ConsoleService
{
    public class ConsoleWrapper : IConsole
    {
        public void Clear()
        {
            Console.Clear();
        }
    }
}
