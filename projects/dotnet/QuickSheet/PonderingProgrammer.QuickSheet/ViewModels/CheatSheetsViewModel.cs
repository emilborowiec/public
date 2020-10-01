using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using PonderingProgrammer.QuickSheet.Annotations;
using PonderingProgrammer.QuickSheet.Services;

namespace PonderingProgrammer.QuickSheet.ViewModels
{
    public sealed class CheatSheetsViewModel : INotifyPropertyChanged
    {
        private List<CheatSheetViewModel> _cheatSheets;
        private int _currentIndex;

        public event PropertyChangedEventHandler PropertyChanged;

        
        public CheatSheetsViewModel()
        {
            ReloadCheatSheets();
        }
        
        public int CurrentIndex
        {
            get => _currentIndex;
            set
            {
                if (value == _currentIndex) return;
                _currentIndex = value;
                OnPropertyChanged(nameof(CurrentIndex));
                OnPropertyChanged(nameof(CurrentCheatSheet));
            }
        }
        
        public CheatSheetViewModel CurrentCheatSheet => CurrentIndex == -1 ? null : _cheatSheets[CurrentIndex];

        private void ReloadCheatSheets()
        {
            _cheatSheets = new List<CheatSheetViewModel>();
            foreach (var sheet in CheatSheetLoader.LoadCheatSheets())
            {
                _cheatSheets.Add(new CheatSheetViewModel(sheet));
            }

            CurrentIndex = _cheatSheets.Count > 0 ? 0 : -1;
        }

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}