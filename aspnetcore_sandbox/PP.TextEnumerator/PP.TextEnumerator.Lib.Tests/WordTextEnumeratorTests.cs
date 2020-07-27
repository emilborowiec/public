using System.Text;
using System.IO;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace PP.TextEnumerator.Lib.Tests
{
    public class WordTextEnumeratorTests
    {
        private readonly ITestOutputHelper output;

        public WordTextEnumeratorTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Theory]
        [InlineData("Hello", "Hello")]
        [InlineData("Hello, World!", "Hello", "World")]
        [InlineData("not two$words", "not")]
        [InlineData("compound-word", "compound", "word")]
        [InlineData("not_blank_space", "not", "blank", "space")]
        [InlineData("two - words", "two", "words")]
        [InlineData("number is n0t a word", "number","is", "a", "word")]
        [InlineData("it's a word", "it","s", "a", "word")]
        [InlineData("not cle@n", "not")]
        [InlineData("we are##surrounded##", "we")]
        [InlineData("(some) [other] {punctuations} 'are' \"here\"", "some","other","punctuations","are","here")]
        public void TestEnumerateFromString(string text, params string[] expectedWords)
        {
            // arrange
            var enumerator = new WordEnumerator();
            // act
            var words = enumerator.Enumerate(text);
            // assert
            var i = 0;
            foreach (string word in words) {
                Assert.Equal(word, expectedWords[i]);
                i++;
            }
        }

        [Fact]
        public async void TestEnumerateFromStream() 
        {
            // arrange
            var expectedWords = new string[2] {"Hello","World"};
            var enumerator = new WordEnumerator();
            byte[] byteArray = Encoding.UTF8.GetBytes("Hello, World!");
            var stream = new MemoryStream(byteArray);
            // act
            var words = enumerator.EnumerateAsync(stream, Encoding.UTF8);
            // assert
            var i = 0;
            await foreach (string word in words)
            {
                Assert.Equal(word, expectedWords[i]);
                i++;
            }
        }

        [Fact]
        public async void TestEnumerateFromStream_LongData()
        {
            // arrange
            var enumerator = new WordEnumerator();
            StringBuilder sb = new StringBuilder();
            for (var i = 0; i < 1000; i++) 
            {
                sb.Append("word ");
            }
            var str = sb.ToString();
            byte[] byteArray = Encoding.UTF8.GetBytes(str);
            var stream = new MemoryStream(byteArray);
            // act
            var words = enumerator.EnumerateAsync(stream, Encoding.UTF8);
            // assert
            var count = 0;
            await foreach (var word in words) 
            {
                Assert.Equal("word", word);
                count++;
            }
            Assert.Equal(1000, count);
        }
    }
}
