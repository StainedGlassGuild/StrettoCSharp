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
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace FXGuild.Stretto.Common.Theory
{
    /// <summary>
    /// Set of constants (ex.: EIGHTH, QUARTER, HALF...) representing note durations. American names
    /// are used. The shortest duration is the HUNDRED_TWENTY_EIGHTH, although in practice a longer
    /// value could be used as the shortest duration value in the application to reduce musical
    /// structures size and computation time.
    /// </summary>
    public sealed class DurationValue
    {
        #region Runtime constants

        public static readonly DurationValue WHOLE;
        public static readonly DurationValue HALF;
        public static readonly DurationValue QUARTER;
        public static readonly DurationValue EIGHTH;
        public static readonly DurationValue SIXTEENTH;
        public static readonly DurationValue THIRTYSECOND;
        public static readonly DurationValue SIXTYFOURTH;
        public static readonly DurationValue HUNDRED_TWENTY_EIGHTH;

        private static readonly List<DurationValue> INSTANCES;

        #endregion

        #region Private fields

        private readonly char m_StaccatoSymbol;

        #endregion

        #region Properties

        /// <summary>
        /// Ex.: Inverted exponent of an EIGHTH is 3, because it lasts 1/(2^3) of a WHOLE
        /// </summary>
        public uint InvertedRank { get; }

        public string FullName { get; }

        #endregion

        #region Constructors

        static DurationValue()
        {
            INSTANCES = new List<DurationValue>();

            WHOLE = new DurationValue("whole", 'w', 0);
            HALF = new DurationValue("half", 'h', 1);
            QUARTER = new DurationValue("quarter", 'q', 2);
            EIGHTH = new DurationValue("eighth", 'i', 3);
            SIXTEENTH = new DurationValue("sixteenth", 's', 4);
            THIRTYSECOND = new DurationValue("thirty-second", 't', 5);
            SIXTYFOURTH = new DurationValue("sixty-fourth", 'x', 6);
            HUNDRED_TWENTY_EIGHTH = new DurationValue("hundred twenty-eighth", 'o', 7);
        }

        private DurationValue(string a_FullName, char a_StaccatoSymbol, uint a_InvertedRank)
        {
            m_StaccatoSymbol = a_StaccatoSymbol;

            InvertedRank = a_InvertedRank;
            FullName = a_FullName;

            INSTANCES.Add(this);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Converts a time unit duration into a duration value. a_TimeUnitDuration must be a power
        /// of 2.
        /// </summary>
        /// <param name="a_TimeUnitDuration">Power of 2</param>
        /// <param name="a_ShortestDuration">Any value</param>
        /// <returns></returns>
        public static DurationValue FromTimeunit(uint a_TimeUnitDuration,
                                                 DurationValue a_ShortestDuration)
        {
            Contract.Requires(MathUtils.IsPowerOfTwo(a_TimeUnitDuration),
                "Time unit duration must be a power of 2");
            Contract.Requires(a_ShortestDuration.InvertedRank >=
                              (int) Math.Round(Math.Log(a_TimeUnitDuration, 2)),
                "Time unit duration must not be longer than a WHOLE");

            int invertedExponent = (int) a_ShortestDuration.InvertedRank -
                                   (int) Math.Round(Math.Log(a_TimeUnitDuration, 2));

            Contract.Assume(invertedExponent < INSTANCES.Count);

            return INSTANCES[invertedExponent];
        }

        public static List<DurationValue> SplitIntoDurationValues(uint a_TimeUnitDuration,
                                                                  DurationValue a_ShortestDuration)
        {
            var values = new List<DurationValue>();

            // Add whole notes
            Contract.Assume(WHOLE.InvertedRank <= a_ShortestDuration.InvertedRank);
            uint wholeNoteLen = WHOLE.ToTimeUnit(a_ShortestDuration);
            for (uint i = 0; i < a_TimeUnitDuration / wholeNoteLen; ++i)
            {
                values.Add(WHOLE);
            }
            a_TimeUnitDuration %= wholeNoteLen;

            // Add other durations
            do
            {
                uint power = (uint) PreviousOrCurrentPowerOfTwo(a_TimeUnitDuration);
                values.Add(FromTimeunit(power, a_ShortestDuration));
                a_TimeUnitDuration -= power;
            } while (a_TimeUnitDuration > 0);

            return values;
        }

        [Pure]
        public static ulong PreviousOrCurrentPowerOfTwo(long a_Val)
        {
            Contract.Requires(a_Val > 0);
            Contract.Ensures(MathUtils.IsPowerOfTwo(Contract.Result<ulong>()));

            return (ulong) PreviousOrCurrentPowerOfTwo((double) a_Val);
        }

        [Pure]
        public static double PreviousOrCurrentPowerOfTwo(double a_Val)
        {
            Contract.Ensures(IsPowerOfTwo(Contract.Result<double>()));


            return a_Val <= 0 ? 0 : Math.Pow(2, Math.Floor(Math.Log(a_Val, 2)));
        }

        [Pure]
        public static bool IsPowerOfTwo(double d)
        {
            return MathUtils.IsPowerOfTwo((long) d);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Converts a duration value into a time unit value, which is how many times the
        /// a_ShortestDuration value fits into current duration value.
        /// <para></para>
        /// Ex.: QUARTER.ToTimeUnit(THIRTYSECOND) returns 8 because a quarter lasts as long as eight
        /// thirty-seconds.
        /// </summary>
        /// <param name="a_ShortestDuration"></param>
        /// <exception cref="ArgumentException">
        /// Shortest duration is longer than the current value
        /// </exception>
        /// <returns>Time unit value of current duration value</returns>
        [Pure]
        public uint ToTimeUnit(DurationValue a_ShortestDuration)
        {
            Contract.Requires(InvertedRank <= a_ShortestDuration.InvertedRank,
                "Duration value to convert to time units is shorter than reference duration");

            return (uint) Math.Pow(2, (int) a_ShortestDuration.InvertedRank - (int) InvertedRank);
        }

        public override string ToString()
        {
            return "1/" + (uint) Math.Pow(2, InvertedRank);
        }

        public string ToStaccato()
        {
            return m_StaccatoSymbol.ToString();
        }

        #endregion
    }
}