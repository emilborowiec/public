using System.Windows.Controls;
using PonderingProgrammer.QuickSheet.ViewModels;

namespace PonderingProgrammer.QuickSheet.Views
{
    public partial class CheatSheetsView : UserControl
    {
        public CheatSheetsView()
        {
            DataContext = new CheatSheetsViewModel();
            InitializeComponent();
        }

    }
}