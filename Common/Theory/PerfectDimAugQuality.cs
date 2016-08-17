﻿// MIT License
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
    /// Set of constants (PERFECT, DIMINISHED and AUGMENTED) representing interval qualities from
    /// the Perfect/Diminished/Augmented family.
    /// </summary>
    public sealed class PerfectDimAugQuality : Quality
    {
        #region Runtime constants

        public static readonly PerfectDimAugQuality PERFECT
            = new PerfectDimAugQuality("Perfect", "", 0);

        public static readonly PerfectDimAugQuality DIMINISHED
            = new PerfectDimAugQuality("Diminished", "dim", -1);

        public static readonly PerfectDimAugQuality AUGMENTED
            = new PerfectDimAugQuality("Augmented", "aug", 1);

        #endregion

        #region Constructors

        private PerfectDimAugQuality(string a_FullName, string a_Symbol, double a_SemitoneModifier)
            : base(a_FullName, a_Symbol, a_SemitoneModifier)
        {}

        #endregion
    }
}