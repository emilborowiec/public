using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace PP.TextEnumerator.Lib
{
    /// <summary>
    /// Enumerates words from text.
    /// To ignore messy text input it demands that words be adjacent to white spaces, punctuation marks or control characters.
    /// </summary>
    public class WordEnumerator : ITextEnumerator
    {
        private const string WORDS_EXPRESSION = @"[a-zA-Z]+"; 
        private const int BUFFER_SIZE = 1024;

        public IEnumerable<string> Enumerate(string text)
        {
            Regex regex = new Regex(WORDS_EXPRESSION);
            var matches = regex.Matches(text);
            foreach (Match match in matches)
            {
                char? before = (match.Index > 0) ? text[match.Index-1] : (char?)null;
                char? after = (match.Index + match.Value.Length < text.Length) ? text[match.Index + match.Value.Length] : (char?) null;
                if (IsWord(before, match.Value, after)) yield return match.Value;
            }
        }

        public async IAsyncEnumerable<string> EnumerateAsync(Stream stream, Encoding encoding)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                // some words may be cut by fixed buffer size reads
                // we detect those cases and glue them
                char lastChar = ' ';
                string lastWord = null;
                bool glueWords = false;
                while (!reader.EndOfStream)
                {
                    char[] buffer = new char[BUFFER_SIZE];
                    var readCount = await reader.ReadBlockAsync(buffer, 0, BUFFER_SIZE);
                    if (readCount == 0) continue;
                    char firstChar = buffer[0];
                    // if last word of previous stream was not yet returned, we can now check if it should be glued or can it be returned now
                    if (!char.IsLetter(firstChar) && lastWord != null) 
                    {
                        yield return lastWord;
                    }
                    glueWords = char.IsLetter(firstChar) && char.IsLetter(lastChar);
                    lastChar = buffer[readCount-1];
                    var wordsFromChunk = Enumerate(new string(buffer));
                    // cannot run foreach and yield return. This is because the last word might need to be glued with first characters from next block.
                    var wordsList = wordsFromChunk.ToList();
                    for (var i = 0; i < wordsList.Count; i++)
                    {
                        var word = wordsList[i];
                        string gluedWord = null;
                        if (i == 0 && glueWords)
                        {
                            gluedWord = lastWord + word;
                        }
                        lastWord = word;
                        if (i < wordsList.Count - 1 || reader.EndOfStream || !char.IsLetter(lastChar)) yield return gluedWord ?? word;
                    }
                }
            }
        }

        public bool IsWord(char? before, string input, char? after)
        {
            if (before != null && !IsWordSeparator(before.Value)) return false;
            if (after != null && !IsWordSeparator(after.Value)) return false;
            foreach (char c in input) {
                if (!char.IsLetter(c)) return false;
            }
            return true;
        }

        public bool IsWordSeparator(char c) 
        {
            return char.IsSeparator(c) || IsCommonPunctuation(c) || char.IsControl(c);
        }

        public bool IsCommonPunctuation(char c) 
        {
            var allowedPunctuations = ".!?,;:(){}[]-_'\"/";
            return allowedPunctuations.Contains(c);
        }
    }
}