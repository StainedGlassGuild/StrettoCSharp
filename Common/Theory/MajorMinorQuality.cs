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
    /// Set of constants (MAJOR, and MINOR) representing interval qualities from the Major/Minor
    /// family.
    /// </summary>
    public sealed class MajorMinorQuality : Quality
    {
        #region Runtime constants

        public static readonly MajorMinorQuality MAJOR = new MajorMinorQuality("Major", "", 0.5);
        public static readonly MajorMinorQuality MINOR = new MajorMinorQuality("Minor", "m", -0.5);

        #endregion

        #region Constructors

        private MajorMinorQuality(string a_FullName, string a_Symbol, double a_SemitoneModifier)
            : base(a_FullName, a_Symbol, a_SemitoneModifier)
        {}

        #endregion
    }
}