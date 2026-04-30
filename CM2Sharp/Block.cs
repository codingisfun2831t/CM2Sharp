using CM2Sharp.Blocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM2Sharp
{
    /// <summary>
    /// Abstract base class for a block
    /// </summary>
    public abstract class Block
    {
        /// <summary>
        /// Location of the block in space.
        /// </summary>
        public Point Location { get; set; }

        /// <summary>
        /// If the block is currently on.
        /// </summary>
        public bool On { get; set; }

        /// <summary>
        /// Function that returns the ID for this block.
        /// </summary>
        /// <note>
        /// Needed instead of a static to support subclassing,
        /// but useful for the LogicGateBlock
        /// </note>
        public abstract int ID();

        public Block()
        {
            Location = Point.Zero;
        }

        /// <summary>
        /// Function that returns a List of extra properties.
        /// </summary>
        public virtual List<string> Properties() => new List<string>();

        /// <summary>
        /// Read a List<string> list of props and set the current block to
        /// those properties.
        /// </summary>
        /// <param name="props"></param>
        public virtual void ReadFromProps(List<string> props) { }

        /// <summary>
        /// Function that returns a List the same length as the result
        /// of Properties that contain the default values of the ones
        /// in Propreties, used for shorter save strings.
        /// </summary>
        public virtual List<string> Defaults() => new List<string>();

        /// <summary>
        /// Generate the save string for this block.
        /// </summary>
        /// <returns></returns>
        public string Generate()
        {
            List<string> properties = Properties();
            List<string> defaults = Defaults();
            int lastNonDefault = -1;

            for (int i = 0; i < properties.Count; i++)
            {
                if (!Equals(properties[i], defaults[i]))
                    lastNonDefault = i;
            }

            List<string> extra;

            if (lastNonDefault == -1)
                extra = new List<string>();
            else
                extra = properties.GetRange(0, lastNonDefault + 1);

            return $"{ID()},{(On ? "1" : "0")},{Location},{string.Join('+', extra)}";
        }

        /// <summary>
        /// Duplicate this block.
        /// </summary>
        /// <returns></returns>
        public Block Copy()
        {
            Block copy = (Block) Activator.CreateInstance(GetType());

            copy.ReadFromProps(Properties());

            return copy;
        }

        /// <summary>
        /// Load a Block from a string.
        /// </summary>
        public static Block LoadFromBlockString(string str)
        {
            string[] parts = str.Split(',');
            Block block = parts[0] switch
            {
                "0" => LogicGateBlock.NOR,
                "1" => LogicGateBlock.AND,
                "2" => LogicGateBlock.OR,
                "3" => LogicGateBlock.XOR,
                "4" => new ButtonBlock(),
                "5" => new FlipFlopBlock(false),
                "6" => new LEDBlock(),
                "7" => new SoundBlock(),
                "8" => new ConductorBlock(),
                "10" => LogicGateBlock.NAND,
                "11" => LogicGateBlock.XNOR,
                "12" => new RandomBlock(),
                "13" => new TimerBlock(),
                "14" => new TileBlock(),
                "15" => new NodeBlock(),
                "16" => new TextBlock(),
                "17" => new AntennaBlock(),
                "18" => new ConductorV2Block(),
                "19" => new LEDMixerBlock(),
                _ => throw new InvalidOperationException($"ID {parts[0]} isn't valid.")
            };

            block.On = parts[1] == "1";
            block.Location = new Point(float.Parse(parts[2]), float.Parse(parts[3]), float.Parse(parts[3]));
            block.ReadFromProps(parts[4].Split('+').ToList());

            return block;
        }
    }
}
