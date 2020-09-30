using System.Collections.Generic;

namespace PonderingProgrammer.QuickSheet.Model
{
    public class CheatSheet
    {
        public string Title { get; set; }
        public List<Section> Sections { get; set; }
        public List<Cheat> Cheats { get; set; }
    }
}