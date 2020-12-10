using System.IO;
using System.Collections.Generic;
using System.Text;

namespace PP.TextEnumerator.Lib
{
    /// <summary>
    /// A TextEnumerator can read text data and make an enumeration of some parts of it.
    /// </summary>
    public interface ITextEnumerator
    {
        IEnumerable<string> Enumerate(string text);

        /// <summary>
        /// Implementations should consider that stream may be long enough
        /// to cause stack overflow if all the data would be cached.
        /// </summary>
        /// <returns></returns>
        IAsyncEnumerable<string> EnumerateAsync(Stream textStream, Encoding encoding);
    }
}