// MIT License
//
// Copyright (c) 2016 FXGuild
//
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and
// associated documentation files (the "Software"), to deal in the Software without restriction,
// including without limitation the rights to use, copy, modify, merge, publish, distribute,
// sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all copies or
// substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT
// NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
// DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using FXGuild.Common.Misc;
using System.Diagnostics.Contracts;

namespace FXGuild.Stretto.Common.Theory
{
    /// <summary>
    /// Represents a time signature (ex.: 4/4, 6/8...). Provides the STANDARD_4_4 constant.
    /// </summary>
    public sealed class TimeSignature
    {
        #region Runtime constants

        public static readonly TimeSignature STANDARD_4_4 = new TimeSignature(4, 4);

        #endregion

        #region Properties

        public uint Numerator { get; }

        public uint Denominator { get; }

        #endregion

        #region Constructors

        public TimeSignature(uint a_Numerator, uint a_Denominator)
        {
            Contract.Requires(a_Numerator != 0);
            Contract.Requires(a_Denominator != 0);

            Numerator = a_Numerator;
            Denominator = a_Denominator;
        }

        #endregion

        #region Methods

        public uint GetNumTimeunitsInABar(DurationValue a_ShortestDuration)
        {
            Contract.Requires(MathUtils.IsInteger(Numerator / (double) Denominator *
                                                  DurationValue.WHOLE.ToTimeUnit(
                                                      a_ShortestDuration)),
                "Shortest duration is or cannot be small enough to fit into time signature");

            Contract.Assume(DurationValue.WHOLE.InvertedRank <= a_ShortestDuration.InvertedRank);

            return (uint) (Numerator / (double) Denominator
                           * DurationValue.WHOLE.ToTimeUnit(a_ShortestDuration));
        }

        public override string ToString()
        {
            return "[" + Numerator + "|" + Denominator + "]";
        }

        #endregion
    }
}