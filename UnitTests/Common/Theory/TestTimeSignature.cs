#region License

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

#endregion

using System;
using FXGuild.Stretto.Common.Theory;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FXGuild.Stretto.Common.UnitTests
{
    [TestClass]
    public sealed class TestTimeSignature
    {
        #region Methods

        [TestMethod]
        public void GetNumTimeunitsInABar_ValidInput_ValidResult()
        {
            Assert.AreEqual(12U, new TimeSignature(3, 4)
                .GetNumTimeunitsInABar(DurationValue.SIXTEENTH));
            Assert.AreEqual(28U, new TimeSignature(7, 8)
                .GetNumTimeunitsInABar(DurationValue.THIRTYSECOND));
        }
        
        #endregion
    }
}