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

namespace FXGuild.Stretto.Common.Theory
{
    /// <summary>
    /// Set of constants (SHARP, FLAT and NONE) representing pitch modifiers.
    /// </summary>
    public sealed class PitchModifier
    {
        #region Runtime constants

        public static readonly PitchModifier NONE = new PitchModifier("", 0);
        public static readonly PitchModifier SHARP = new PitchModifier("#", 1);
        public static readonly PitchModifier FLAT = new PitchModifier("b", -1);

        #endregion

        #region Properties

        public string Symbol { get; }

        public int SemitoneModifier { get; }

        #endregion

        #region Constructors

        private PitchModifier(string a_Symbol, int a_SemitoneModifier)
        {
            Symbol = a_Symbol;
            SemitoneModifier = a_SemitoneModifier;
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            return Symbol;
        }

        #endregion
    }
}