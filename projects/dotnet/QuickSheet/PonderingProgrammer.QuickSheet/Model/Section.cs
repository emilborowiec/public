using System.Collections.Generic;

namespace PonderingProgrammer.QuickSheet.Model
{
    public class Section
    {
        public string Name { get; set; }
        public HashSet<Cheat> Cheats { get; set; }
    }
}