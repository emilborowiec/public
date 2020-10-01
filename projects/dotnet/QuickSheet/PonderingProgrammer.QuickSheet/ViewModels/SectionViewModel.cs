using System.Collections.Generic;
using System.Drawing;
using PonderingProgrammer.QuickSheet.Model;

namespace PonderingProgrammer.QuickSheet.ViewModels
{
    public class SectionViewModel
    {
        public SectionViewModel(List<Cheat> cheats)
        {
            Cheats = cheats;
            IsRootSection = true;
        }

        public SectionViewModel(string title, List<Cheat> cheats)
        {
            Title = title;
            Cheats = cheats;
        }

        public bool IsRootSection { get; }
        public bool IsNotRootSection => !IsRootSection;
        public Color BackgroundColor { get; set; }
        public string Title { get; }
        public List<Cheat> Cheats { get; }
    }
}