using System.Collections.Generic;

namespace PonderingProgrammer.QuickSheet.Model
{
    public class Section
    {
        public Section(string name)
        {
            Name = name;
        }

        public string Name { get; }
        public HashSet<Cheat> Cheats { get; } = new HashSet<Cheat>();
    }
}