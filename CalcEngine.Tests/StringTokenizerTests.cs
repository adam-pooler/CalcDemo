using System.Linq;
using System;
using Xunit;

namespace CalcEngine.Tests
{
    public class StringTokenizerTests
    {

        [Fact]
        public void StringTokenizer_Tokenize_With5Elements_AndSingleDelimiter_ReturnsArrayOfLength5()
        {
            var Tokenizeter = new StringTokenizer();
            string[] found = Tokenizeter.Tokenize("foo$bar$baz", new string[] { "$" }).ToArray();

            Assert.Equal(5, found.Length);
            Assert.Equal(3, found[0].Length);
            Assert.Equal("$", found[1]);
            Assert.Equal(3, found[2].Length);
            Assert.Equal("$", found[3]);
            Assert.Equal(3, found[4].Length);
        }

        [Fact]
        public void StringTokenizer_Tokenize_With4Elements_AndTrailingDelimiter_ReturnsArrayOfLength4()
        {
            var Tokenizeter = new StringTokenizer();
            string[] found = Tokenizeter.Tokenize("foo$bar$", new string[] { "$" }).ToArray();

            Assert.Equal(4, found.Length);
            Assert.Equal(3, found[0].Length);
            Assert.Equal(3, found[2].Length);
        }

        [Fact]
        public void StringTokenizer_Tokenize_With5Elements_AndMultiCharacterDelimiters_ReturnsArrayOfLength5()
        {
            var Tokenizeter = new StringTokenizer();
            string[] found = Tokenizeter.Tokenize("foo$$bar$$var", new string[] { "$$" }).ToArray();

            Assert.Equal(5, found.Length);
            Assert.Equal(3, found[0].Length);
            Assert.Equal("$$", found[1]);
            Assert.Equal(3, found[2].Length);
            Assert.Equal("$$", found[3]);
            Assert.Equal(3, found[4].Length);
        }

        [Fact]
        public void StringTokenizer_Tokenize_With4Elements_AndMultiCharacterDelimiters_AndTrailingDelimiter_ReturnsArrayOfLength4()
        {
            var Tokenizeter = new StringTokenizer();
            string[] found = Tokenizeter.Tokenize("foo$$bar$$", new string[] { "$$" }).ToArray();

            Assert.Equal(4, found.Length);
            Assert.Equal(3, found[0].Length);
            Assert.Equal("$$", found[1]);
            Assert.Equal(3, found[2].Length);
            Assert.Equal("$$", found[3]);
        }

        [Fact]
        public void StringTokenizer_Tokenize_With5Elements_AndTwoDelimiters_ReturnsArrayOfLength5()
        {
            var Tokenizeter = new StringTokenizer();
            string[] found = Tokenizeter.Tokenize("foo$bar#baz", new string[] { "$", "#" }).ToArray();

            Assert.Equal(5, found.Length);
            Assert.Equal(3, found[0].Length);
            Assert.Equal("$", found[1]);
            Assert.Equal(3, found[2].Length);
            Assert.Equal("#", found[3]);
            Assert.Equal(3, found[4].Length);
        }

        [Fact]
        public void StringTokenizer_Tokenize_With3Numbers_AndAdditionOperator_ReturnsArrayOfLength5()
        {
            var Tokenizeter = new StringTokenizer();
            string[] found = Tokenizeter.Tokenize("1+2+3", new string[] { "+" }).ToArray();

            Assert.Equal(5, found.Length);
            Assert.Equal("1", found[0]);
            Assert.Equal("+", found[1]);
            Assert.Equal("2", found[2]);
            Assert.Equal("+", found[3]);
            Assert.Equal("3", found[4]);
        }

        [Fact]
        public void StringTokenizer_Tokenize_With3Numbers_AndMultipleOperators_ReturnsArrayOfLength5()
        {
            var Tokenizeter = new StringTokenizer();
            string[] found = Tokenizeter.Tokenize("1+2-3", new string[] { "+", "-" }).ToArray();

            Assert.Equal(5, found.Length);
            Assert.Equal("1", found[0]);
            Assert.Equal("+", found[1]);
            Assert.Equal("2", found[2]);
            Assert.Equal("-", found[3]);
            Assert.Equal("3", found[4]);
        }

        [Fact]
        public void StringTokenizer_Tokenize_With3Numbers__AndNegativeNumber_AndMultipleOperators_ReturnsArrayOfLength6()
        {
            var Tokenizeter = new StringTokenizer();
            string[] found = Tokenizeter.Tokenize("1+2+-3", new string[] { "+", "-" }).ToArray();

            Assert.Equal(6, found.Length);
            Assert.Equal("1", found[0]);
            Assert.Equal("+", found[1]);
            Assert.Equal("2", found[2]);
            Assert.Equal("+", found[3]);
            Assert.Equal("-", found[4]);
            Assert.Equal("3", found[5]);
        }

        [Fact]
        public void StringTokenizer_Tokenize_WithNoDelimitersInInputString_ReturnsArrayOfLength1_AndOriginalString()
        {
            var Tokenizeter = new StringTokenizer();
            string[] found = Tokenizeter.Tokenize("foobar", new string[] { "$" }).ToArray();

            Assert.Equal(1, found.Length);
            Assert.Equal("foobar", found[0]);
        }

        [Fact]
        public void StringTokenizer_Tokenize_WithNullInput_ThrowsException()
        {
            var Tokenizeter = new StringTokenizer();

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Tokenizeter.Tokenize(null, new string[] { "a" });
            });
        }

        [Fact]
        public void StringTokenizer_Tokenize_WithNullDelimiters_ThrowsException()
        {
            var Tokenizeter = new StringTokenizer();

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Tokenizeter.Tokenize("blah", null);
            });
        }

        [Fact]
        public void StringTokenizer_Tokenize_WithNoDelimiters_ThrowsException()
        {
            var Tokenizeter = new StringTokenizer();

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Tokenizeter.Tokenize("blah", new string[] {});
            });
        }
    }
}
