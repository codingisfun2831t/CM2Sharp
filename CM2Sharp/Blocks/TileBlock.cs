using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM2Sharp.Blocks
{
    /// <summary>
    /// A Tile block.
    /// </summary>
    public class TileBlock : Block
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
        /// Material of the tile.
        /// 
        /// TODO: Create enum with the material numbers CM2 uses,
        /// if we ever get that information. For now, find the correct
        /// material you want.
        /// </summary>
        public byte Material { get; set; }

        public TileBlock(byte r = 75, byte g = 75, byte b = 75)
        {
            Red = r;
            Green = g;
            Blue = b;
            Material = 1;
        }

        public override int ID() => 14;

        public override List<string> Properties() => new List<string>()
        {
            Red.ToString(), Green.ToString(), Blue.ToString(), Material.ToString()
        };

        public override List<string> Defaults() => new List<string>()
        {
            "75", "75", "75", "1"
        };
    }
}
