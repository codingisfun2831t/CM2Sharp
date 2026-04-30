using CM2Sharp.Blocks;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM2Sharp
{
    /// <summary>
    /// A CM2 save.
    /// </summary>
    public class Circuit
    {
        /// <summary>
        /// Blocks contained in the Save.
        /// </summary>
        public List<Block> Blocks { get; init; }

        /// <summary>
        /// Connections contained in the save.
        /// </summary>
        public List<(Block Source, Block Target)> Connections { get; init; }

        public Circuit()
        {
            Blocks = new();
            Connections = new();
        }

        /// <summary>
        /// Add a block to the save.
        /// </summary>
        public Block AddBlock(Block blk)
        {
            Blocks.Add(blk);
            return blk;
        }

        /// <summary>
        /// Add a block to the save, with overriding the location.
        /// </summary>
        public Block AddBlock(Block blk, Point location)
        {
            blk.Location = location;
            Blocks.Add(blk);
            return blk;
        }

        /// <summary>
        /// Add a block to the save, with overriding the location.
        /// </summary>
        public Block AddBlock(Block blk, float x, float y, float z)
        {
            blk.Location = (x, y, z);
            Blocks.Add(blk);
            return blk;
        }

        /// <summary>
        /// Add a connection to the save.
        /// </summary>
        public void AddConnection(Block source, Block target)
        {
            Connections.Add((source, target));
        }

        /// <summary>
        /// Add a connection via indexes.
        /// </summary>
        public void AddConnection(int source, int target)
        {
            Block sourceBlk = Blocks[source];
            Block targetBlk = Blocks[target];

            AddConnection(sourceBlk, targetBlk);
        }

        /// <summary>
        /// Convert this save to a save string.
        /// </summary>
        public string Generate()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < Blocks.Count; i++)
            {
                sb.Append(Blocks[i].Generate());

                if (i < Blocks.Count - 1)
                {
                    sb.Append(';');
                }
            }

            sb.Append('?');

            Dictionary<Block, int> blockIndex = new Dictionary<Block, int>();
            for (int i = 0; i < Blocks.Count; i++)
            {
                blockIndex[Blocks[i]] = i;
            }

            for (int i = 0; i < Connections.Count; i++)
            {
                var (src, trg) = Connections[i];

                if (!blockIndex.TryGetValue(src, out int a) ||
                    !blockIndex.TryGetValue(trg, out int b))
                {
                    throw new Exception($"Connection {i} references blocks that dont exist in the current save");
                }

                sb.Append(a + 1);
                sb.Append(',');
                sb.Append(b + 1);

                if (i < Connections.Count - 1)
                {
                    sb.Append(';');
                }
            }

            sb.Append("??");
            return sb.ToString();
        }

        /// <summary>
        /// Load a circuit from a save string.
        /// </summary>
        public static Circuit Load(string save)
        {
            string[] sections = save.Split('?');

            Circuit circuit = new();

            string[] blocks = sections[0].Split(';');
            foreach (string str in blocks)
            {
                circuit.AddBlock(Block.LoadFromBlockString(str));
            }

            string[] connections = sections[1].Split(';');
            foreach (string connection in connections)
            {
                string[] split = connection.Split(',');
                int from = int.Parse(split[0]) - 1, to = int.Parse(split[1]) - 1;
                circuit.AddConnection(from, to);
            }

            return circuit;
        }

        /// <summary>
        /// Deep-copy this circuit.
        /// </summary>
        /// <returns></returns>
        public Circuit Copy()
        {
            Circuit copy = new();

            Dictionary<Block, Block> copies = new();
            foreach (Block block in Blocks)
            {
                Block bCopy = block.Copy();
                copies[block] = bCopy;
                copy.AddBlock(bCopy);
            }

            foreach ((Block source, Block target) connection in Connections)
            {
                Block newSource = copies[connection.source];
                Block newTarget = copies[connection.target];

                copy.AddConnection(newSource, newTarget);
            }

            return copy;
        }

        /// <summary>
        /// Copy another save into this one.
        /// </summary>
        /// <remarks>Links/Modifies back to the original circuit's blocks! If you want it
        /// to be copied before, using Copy on the other circuit before passing it here.</remarks>
        public void AddSubCircuit(Circuit other, float x, float y, float z)
        {
            foreach (Block block in other.Blocks)
            {
                float newX = block.Location.X + x;
                float newY = block.Location.Y + y;
                float newZ = block.Location.Z + z;
                block.Location = new Point(newX, newY, newZ);
                Blocks.Add(block);
            }

            foreach (var connection in other.Connections)
            {
                Connections.Add(connection);
            }
        }
    }
}
