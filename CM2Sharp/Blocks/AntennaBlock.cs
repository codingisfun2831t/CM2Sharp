using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM2Sharp.Blocks
{
    /// <summary>
    /// Antenna block
    /// </summary>
    public class AntennaBlock : Block
    {

        /// <summary>
        /// Channel for the antenna, that allows certains ones to communicate.
        /// </summary>
        public ushort Channel { get; set; }

        /// <summary>
        /// If the antenna is global.
        /// </summary>
        public bool Global { get; set; }

        public AntennaBlock(ushort channel = 0, bool global = false) {
            Channel = channel;
            Global = global;
        }

        public override List<string> Properties() => new List<string>()
        {
            Channel.ToString(), Global ? "1" : "0"
        };

        public override List<string> Defaults() => new List<string>()
        {
            "0", "0"
        };

        public override int ID() => 17;
    }
}
