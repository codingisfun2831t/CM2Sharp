
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM2Sharp.Blocks
{
    /// <summary>
    /// A LED Mixer block.
    /// </summary>
    public class LEDMixerBlock : Block
    {

        /// <summary>
        /// Additive.
        /// 
        /// I don't know what this even does but here it is
        /// </summary>
        public float Additive { get; set; }

        public LEDMixerBlock(float add = 'A')
        {
            Additive = add;
        }

        public override int ID() => 12;

        public override List<string> Properties() => new List<string>()
        {
            Additive.ToString()
        };

        public override List<string> Defaults() => new List<string>()
        {
            "0"
        };
    }
}
