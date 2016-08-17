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

using System;

namespace FXGuild.Stretto.Common.Theory
{
    /// <summary>
    /// Utilities for manipulating semitones.
    /// </summary>
    public static class Semitones
    {
        #region Compile-time constants

        public const uint NUM_IN_OCTAVE = 12;

        #endregion

        #region Static methods

        /// <summary>
        /// Brings back an arbitrary semitone interval in the 0-11 range, thus removing octaves and
        /// forcing a positive interval.
        /// </summary>
        /// <param name="a_SemitoneDistanceToC">Any possible semitone distance to C</param>
        /// <returns>Value between 0 and 11</returns>
        public static uint NormalizedDistance(int a_SemitoneDistanceToC)
        {
            return (uint) (a_SemitoneDistanceToC >= 0
                ? a_SemitoneDistanceToC % NUM_IN_OCTAVE
                : NUM_IN_OCTAVE - -(a_SemitoneDistanceToC + NUM_IN_OCTAVE) % NUM_IN_OCTAVE);
        }

        public static int Between()
        {
            // TODO needs Tone and Pitch
            throw new NotImplementedException();
        }

        #endregion
    }
}