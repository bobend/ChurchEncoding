using System;
using Xunit;

namespace Ploeh.Samples.ChurchEncoding.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var foo = "foo".ToMaybe();
            Assert.IsType<Just<string>>(foo);
            Assert.Equal("foo", foo.Match("", x => x));

            var nothing = ((string) null).ToMaybe();
            Assert.IsType<Nothing<string>>(nothing);
            Assert.Empty(nothing.Match("", x => x));
        }
    }
}
