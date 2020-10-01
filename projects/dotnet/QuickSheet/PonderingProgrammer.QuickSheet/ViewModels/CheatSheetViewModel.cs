using System.Collections.Generic;
using System.Linq;
using PonderingProgrammer.QuickSheet.Model;

namespace PonderingProgrammer.QuickSheet.ViewModels
{
    public class CheatSheetViewModel
    {
        private static List<SectionViewModel> CreateViewSections(CheatSheet cheatSheet)
        {
            var viewSections = new List<SectionViewModel>();
            if (cheatSheet.Cheats.Count > 0)
            {
                viewSections.Add(new SectionViewModel(cheatSheet.Cheats));
            }

            viewSections.AddRange(cheatSheet.Sections.Select(section => new SectionViewModel(section.Name, section.Cheats)));
            
            return viewSections;
        }
        
        public CheatSheetViewModel(CheatSheet cheatSheet)
        {
            Title = cheatSheet.Title;
            Sections = CreateViewSections(cheatSheet);
        }

        public string Title { get; }
        public List<SectionViewModel> Sections { get; }
    }
}