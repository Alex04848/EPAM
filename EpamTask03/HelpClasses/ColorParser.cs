using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask03
{
    public static class ColorParser
    {
        public static ConsoleColor Parse(string color)
            => ((ConsoleColor)Enum.Parse(typeof(ConsoleColor),color));

    }
}
