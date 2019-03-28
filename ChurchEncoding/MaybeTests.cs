using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ploeh.Samples.ChurchEncoding
{
    public class MaybeTests
    {
        [Fact]
        public void MatchEmpty()
        {
            IMaybe<Guid> sut = new Nothing<Guid>();
            var actual = sut.Match("empty", _ => "not empty");
            Assert.Equal("empty", actual);
        }

        [Fact]
        public void MatchFilled()
        {
            IMaybe<int> sut = new Just<int>(42);
            var actual = sut.Match("empty", i => i.ToString());
            Assert.Equal("42", actual);
        }

        [Fact]
        public void SimpleQueryExpressionWorks()
        {
            IMaybe<int> sut = new Just<int>(42);
            IMaybe<string> actual = from i in sut
                                    select i.ToString();
            Assert.Equal("42", actual.Match("nothing", x => x));
        }

        [Fact]
        public void Flatten()
        {
            IMaybe<IMaybe<int>> sut = new Just<IMaybe<int>>(new Nothing<int>());
            Assert.IsType<Nothing<int>>(sut.Flatten());

            sut = new Just<IMaybe<int>>(new Just<int>(42));
            Assert.IsType<Just<int>>(sut.Flatten());

            sut = new Nothing<IMaybe<int>>();
            Assert.IsType<Nothing<int>>(sut.Flatten());
        }

        [Fact]
        public void SelectManyTest()
        {

            IMaybe<int> sut = new Just<int>(42);
            var actual = sut.SelectMany
                (i => (i % 2 == 0) ? (IMaybe<int>) new Just<int>(i + 10) : new Nothing<int>()).Match(0, i=>i);
            Assert.Equal( 52, actual);

        }
    }
}
