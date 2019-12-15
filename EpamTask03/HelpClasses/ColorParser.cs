using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask03
{
    /// <summary>
    /// The method is for parsing color from string
    /// </summary>
    public static class ColorParser
    {
        /// <summary>
        /// For parsing color I use a static method of Enum class
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static ConsoleColor Parse(string color)
            => ((ConsoleColor)Enum.Parse(typeof(ConsoleColor),color));

    }
}
