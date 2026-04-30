using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM2Sharp.Blocks
{
    /// <summary>
    /// A Text block.
    /// </summary>
    public class TextBlock : Block
    {

        /// <summary>
        /// Character the block shows.
        /// </summary>
        public char Character { get; set; }

        public TextBlock(char ch = 'A')
        {
            Character = ch;
        }

        public override int ID() => 13;

        public override List<string> Properties() => new List<string>()
        {
            ((int)Character).ToString()
        };

        public override List<string> Defaults() => new List<string>()
        {
            "65" // A
        };
    }
}
