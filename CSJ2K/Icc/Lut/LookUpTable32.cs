// Copyright (c) 2007-2017 CSJ2K contributors.
// Licensed under the BSD 3-Clause License.

using System.Text;
using ICCCurveType = CSJ2K.Icc.Tags.ICCCurveType;

namespace CSJ2K.Icc.Lut
{

    /// <summary> Toplevel class for a int [] lut.
    /// 
    /// </summary>
    /// <version> 	1.0
    /// </version>
    /// <author> 	Bruce A. Kern
    /// </author>
    public abstract class LookUpTable32 : LookUpTable
    {

        /// <summary>Maximum output value of the LUT </summary>
        protected internal int dwMaxOutput;

        /// <summary>the lut values.                 </summary>
        public int[] lut;

        /// <summary> Create an abbreviated string representation of a 16 bit lut.</summary>
        /// <returns> the lut as a String
        /// </returns>
        public override string ToString()
        {
            var rep = new StringBuilder("[LookUpTable32 ");
            //int row, col;
            rep.Append("max= " + dwMaxOutput);
            rep.Append(", nentries= " + dwNumInput);
            return rep.Append("]").ToString();
        }

        /// <summary> Create the string representation of a 32 bit lut.</summary>
        /// <returns> the lut as a String
        /// </returns>
        public virtual string toStringWholeLut()
        {
            var rep = new StringBuilder("[LookUpTable32" + eol);
            int row, col;
            rep.Append("max output = " + dwMaxOutput + eol);
            for (row = 0; row < dwNumInput / 10; ++row)
            {
                rep.Append("lut[" + 10 * row + "] : ");
                for (col = 0; col < 10; ++col)
                {
                    rep.Append(lut[10 * row + col] + " ");
                }
                rep.Append(eol);
            }
            // Partial row.
            rep.Append("lut[" + 10 * row + "] : ");
            for (col = 0; col < dwNumInput % 10; ++col)
                rep.Append(lut[10 * row + col] + " ");
            rep.Append(eol + eol);
            return rep.ToString();
        }

        /// <summary> Factory method for getting a 32 bit lut from a given curve.</summary>
        /// <param name="curve"> the data
        /// </param>
        /// <param name="dwNumInput">the size of the lut 
        /// </param>
        /// <param name="dwMaxOutput">max output value of the lut
        /// </param>
        /// <returns> the lookup table
        /// </returns>
        public static LookUpTable32 createInstance(ICCCurveType curve, int dwNumInput, int dwMaxOutput)
        {
            if (curve.count == 1)
                return new LookUpTable32Gamma(curve, dwNumInput, dwMaxOutput);
            else
                return new LookUpTable32Interp(curve, dwNumInput, dwMaxOutput);
        }

        /// <summary> Construct an empty 32 bit</summary>
        /// <param name="dwNumInput">the size of the lut.
        /// </param>
        /// <param name="dwMaxOutput">max output value of the lut
        /// </param>
        protected internal LookUpTable32(int dwNumInput, int dwMaxOutput) : base(null, dwNumInput)
        {
            lut = new int[dwNumInput];
            this.dwMaxOutput = dwMaxOutput;
        }

        /// <summary> Construct a 16 bit lut from a given curve.</summary>
        /// <param name="curve">the data
        /// </param>
        /// <param name="dwNumInput">the size of the lut t lut.
        /// </param>
        /// <param name="dwMaxOutput">max output value of the lut
        /// </param>
        protected internal LookUpTable32(ICCCurveType curve, int dwNumInput, int dwMaxOutput) : base(curve, dwNumInput)
        {
            this.dwMaxOutput = dwMaxOutput;
            lut = new int[dwNumInput];
        }

        /// <summary> lut accessor</summary>
        /// <param name="index">of the element
        /// </param>
        /// <returns> the lut [index]
        /// </returns>
        public int elementAt(int index)
        {
            return lut[index];
        }
    }
}
