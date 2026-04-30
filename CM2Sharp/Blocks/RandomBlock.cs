using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM2Sharp.Blocks
{
    /// <summary>
    /// A Random block.
    /// </summary>
    public class RandomBlock : Block
    {

        /// <summary>
        /// Probabilty (0-1) that the block is on at any tick.
        /// </summary>
        public float Probabilty { get; set; }

        public RandomBlock(float prob = 'A')
        {
            Probabilty = prob;
        }

        public override int ID() => 12;

        public override List<string> Properties() => new List<string>()
        {
            Probabilty.ToString()
        };

        public override List<string> Defaults() => new List<string>()
        {
            "0.5"
        };
    }
}
