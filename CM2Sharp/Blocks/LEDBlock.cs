using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM2Sharp.Blocks
{
    /// <summary>
    /// A LED block.
    /// </summary>
    public class LEDBlock : Block
    {

        /// <summary>
        /// Red channel of the color.
        /// </summary>
        public byte Red { get; set; }

        /// <summary>
        /// Green channel of the color.
        /// </summary>
        public byte Green { get; set; }

        /// <summary>
        /// Blue channel of the color.
        /// </summary>
        public byte Blue { get; set; }

        /// <summary>
        /// Opacity of the LED when on.
        /// </summary>
        public int OpacityOn { get; set; }

        /// <summary>
        /// Opacity of the LED when off.
        /// </summary>
        public int OpacityOff { get; set; }

        /// <summary>
        /// If the LED is Analog.
        /// </summary>
        public bool Analog { get; set; }

        public LEDBlock(byte r = 175, byte g = 175, byte b = 175)
        {
            Red = r;
            Green = g;
            Blue = b;
            OpacityOn = 100;
            OpacityOff = 25;
            Analog = false;
        }

        public override int ID() => 6;

        public override List<string> Properties() => new List<string>()
        {
            Red.ToString(), Green.ToString(), Blue.ToString(),
            OpacityOn.ToString(), OpacityOff.ToString(),
            Analog ? "1" : "0"
        };

        public override List<string> Defaults() => new List<string>()
        {
            "175", "175", "175", "100", "25", "0"
        };
    }
}
