using System;
using System.Collections.Generic;

namespace CSharpLanguageFeatures
{
    public class Class1
    {
        public static void InitializingCollections()
        {
            var a = new int[] {1, 2, 3};
            var l = new List<string>() {"one", "two", "three"};
            var d = new Dictionary<int, string>()
            {
                {1, "one"},
                {2, "two"},
                {3, "three"}
            };
        }
    }
}