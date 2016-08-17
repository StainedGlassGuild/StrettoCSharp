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
using System.Collections.Generic;

namespace FXGuild.Stretto.Common.Theory
{
    /// <summary>
    /// Set of constants (C, D, E, F, G, A and B) representing the unaltered musical notes of the
    /// diatonic scale.
    /// </summary>
    public sealed class NoteLetter
    {
        #region Runtime constants

        public static readonly NoteLetter C = new NoteLetter('C', 0);
        public static readonly NoteLetter D = new NoteLetter('D', 2);
        public static readonly NoteLetter E = new NoteLetter('E', 4);
        public static readonly NoteLetter F = new NoteLetter('F', 5);
        public static readonly NoteLetter G = new NoteLetter('G', 7);
        public static readonly NoteLetter A = new NoteLetter('A', 9);
        public static readonly NoteLetter B = new NoteLetter('B', 11);

        private static readonly List<NoteLetter> INSTANCES;
        private static readonly Dictionary<char, NoteLetter> LETTER_TO_INSTANCE;

        #endregion

        #region Properties

        public char Letter { get; }

        /// <summary>
        /// Distance in semitones above C of the current note letter without any pitch modifier.
        /// Ex.: F is 5 semitones above C.
        /// </summary>
        public uint BasicSemitoneValue { get; }

        #endregion

        #region Constructors

        static NoteLetter()
        {
            INSTANCES = new List<NoteLetter>(); //TODO diatonic tone in octave
            LETTER_TO_INSTANCE = new Dictionary<char, NoteLetter>(); //TODO diatonic tone in octave
        }

        private NoteLetter(char a_Letter, uint a_BasicSemitoneValue)
        {
            Letter = a_Letter;
            BasicSemitoneValue = a_BasicSemitoneValue;

            INSTANCES.Add(this);
            LETTER_TO_INSTANCE[a_Letter] = this;
        }

        #endregion

        #region Static methods

        public static NoteLetter FromLetter(char a_Letter)
        {
            return LETTER_TO_INSTANCE[a_Letter];
        }

        public static NoteLetter FromDiatonicToneDistanceToC(int a_DiatonicToneDist)
        {
            // TODO needs DiatonicTones
            throw new NotImplementedException();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Tells if this note letter can be assigned with any pitch modifier to a semitone distance
        /// to C. Ex.: D can be assigned to 3, because D# is 3 semitones above C. On the other hand,
        /// A cannot be assigned to 6, because only 8 (Ab), 9 (A) and 10 (A#) are assignable.
        /// </summary>
        /// <param name="a_SemitoneDistanceToC">Semitone distance to C</param>
        /// <returns>If this note letter can be assigned with any pitch modifier to</returns>
        public bool CanBeAssignedFrom(int a_SemitoneDistanceToC)
        {
            // TODO needs Semitones
            throw new NotImplementedException();
        }

        public NoteLetter GetNext()
        {
            // TODO needs DiatonicTones
            throw new NotImplementedException();
        }

        public NoteLetter GetPrevious()
        {
            // TODO needs DiatonicTones
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return Letter.ToString();
        }

        #endregion
    }
}