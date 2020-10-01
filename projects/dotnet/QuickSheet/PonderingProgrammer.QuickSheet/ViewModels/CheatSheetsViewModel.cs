using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using PonderingProgrammer.QuickSheet.Annotations;
using PonderingProgrammer.QuickSheet.Model;
using PonderingProgrammer.QuickSheet.Services;

namespace PonderingProgrammer.QuickSheet.ViewModels
{
    public sealed class CheatSheetsViewModel : INotifyPropertyChanged
    {
        private int _currentIndex;

        public CheatSheetsViewModel()
        {
            CheatSheets.CollectionChanged += OnCheatSheetsChanged;
            foreach (var sheet in CheatSheetLoader.LoadCheatSheets())
            {
                CheatSheets.Add(sheet);
            }
        }

        private void OnCheatSheetsChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            CurrentIndex = CheatSheets.Count > 0 ? 0 : -1;
        }

        public ObservableCollection<CheatSheet> CheatSheets { get; } = new ObservableCollection<CheatSheet>();

        public int CurrentIndex
        {
            get => _currentIndex;
            set
            {
                if (value == _currentIndex) return;
                _currentIndex = value;
                OnPropertyChanged(nameof(CurrentIndex));
                OnPropertyChanged(nameof(CurrentCheatSheet));
                OnPropertyChanged(nameof(SheetTitle));
            }
        }

        public CheatSheet CurrentCheatSheet => CurrentIndex == -1 ? null : CheatSheets[CurrentIndex];
        public string SheetTitle => CurrentCheatSheet?.Title;
        
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}