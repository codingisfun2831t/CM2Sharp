using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM2Sharp.Blocks
{
    /// <summary>
    /// A Timer block.
    /// </summary>
    public class TimerBlock : Block
    {
        /// <summary>
        /// Delay before the input goes to output.
        /// </summary>
        public int Delay { get; set; }

        public TimerBlock(int delay = 20)
        {
            Delay = delay;
        }

        public override int ID() => 16;

        public override List<string> Properties() => new List<string>()
        {
            Delay.ToString()
        };

        public override List<string> Defaults() => new List<string>()
        {
            "20" // 20
        };
    }
}
