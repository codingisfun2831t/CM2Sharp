using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM2Sharp.Blocks
{
    /// <summary>
    /// A T-Flip-flop block.
    /// </summary>
    public class FlipFlopBlock : Block
    {
        public FlipFlopBlock(bool on)
        {
            this.On = on;
        }

        public override int ID() => 5;

        // we NEED the "0+0" to exist (CM2 doesnt accept it otherwise),
        // so make sure the defaults are different
        public override List<string> Properties() => new List<string>()
        {
            "0", "0"
        };

        public override List<string> Defaults() => new List<string>()
        {
            "1", "1"
        };
    }
}
