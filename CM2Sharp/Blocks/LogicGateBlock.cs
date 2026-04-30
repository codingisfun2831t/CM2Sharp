using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM2Sharp.Blocks
{
    /// <summary>
    /// Logic gate block
    /// </summary>
    public class LogicGateBlock : Block
    {
        /// <summary>
        /// Type of a LogicGateBlock.
        /// </summary>
        public enum Type
        {
            NOR = 0,
            AND,
            OR,
            XOR,

            NAND = 10,
            XNOR
        }

        /// <summary>
        /// Type of this block.
        /// </summary>
        public Type BlockType { get; set; }

        public LogicGateBlock(Type type)
        {
            BlockType = type;
        }

        public override int ID() => (int)BlockType;

        public static LogicGateBlock NOR => new(Type.NOR);
        public static LogicGateBlock AND => new(Type.AND);
        public static LogicGateBlock OR => new(Type.OR);
        public static LogicGateBlock XOR => new(Type.XOR);
        public static LogicGateBlock NAND => new(Type.NAND);
        public static LogicGateBlock XNOR => new(Type.XNOR);
    }
}
