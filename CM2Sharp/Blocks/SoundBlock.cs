using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM2Sharp.Blocks
{
    /// <summary>
    /// Sound block
    /// </summary>
    public class SoundBlock : Block
    {
        public enum NoteType
        {
            Sine = 0,
            Square,
            Triangle,
            Sawtooth,
            Meow,
            Snare
        }

        /// <summary>
        /// Type of note to be played.
        /// </summary>
        public NoteType Note { get; set; }

        /// <summary>
        /// Frequency of note to be played.
        /// </summary>
        public int Frequency { get; set; }

        public SoundBlock(NoteType note = NoteType.Sine, int freq = 196)
        {
            Note = note;
            Frequency = freq;
        }

        public override List<string> Properties() => new List<string>()
        {
            ((int)Note).ToString(), Frequency.ToString()
        };

        public override List<string> Defaults() => new List<string>()
        {
            "0", "196"
        };

        public override int ID() => 7;
    }
}
