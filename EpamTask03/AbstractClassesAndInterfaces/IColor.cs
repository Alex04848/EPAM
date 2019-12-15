using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTask03.AbstractClassesAndInterfaces;

namespace EpamTask03
{
    /// <summary>
    /// That is an interface for color 
    /// in paper shapes. The interface IColor contains
    /// only Color property. All paper shapes contain 
    /// a field for color and a boolean flag for checking 
    /// state of color(you can paint a shape only once).
    /// </summary>
    public interface IColor
    {
        ConsoleColor Color { get; set; }
    }
}
