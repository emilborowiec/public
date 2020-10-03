#region

using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using PonderingProgrammer.QuickSheet.Annotations;
using PonderingProgrammer.QuickSheet.CheatSheetPanel;
using PonderingProgrammer.QuickSheet.Model;
using PonderingProgrammer.QuickSheet.Services;

#endregion

namespace PonderingProgrammer.QuickSheet
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel()
        {
            _cheatSheetViewModel = new CheatSheetViewModel();
            SwitchSheetCommand = new DelegateCommand<string>(SwitchSheet);
            ReloadCheatSheets();
        }

        private List<CheatSheet> _cheatSheets;
        private int _currentIndex;
        private CheatSheetViewModel _cheatSheetViewModel;


        public DelegateCommand<string> SwitchSheetCommand { get; }

        public CheatSheet CurrentCheatSheet => CurrentIndex == -1 ? null : _cheatSheets[CurrentIndex];

        public int CurrentIndex
        {
            get => _currentIndex;
            set
            {
                if (value == _currentIndex) return;
                _currentIndex = value;
                _cheatSheetViewModel.CheatSheet = CurrentCheatSheet;
            }
        }

        public CheatSheetViewModel CheatSheetViewModel
        {
            get => _cheatSheetViewModel;
            set
            {
                _cheatSheetViewModel = value;
                OnPropertyChanged(nameof(CheatSheetViewModel));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;


        private void ReloadCheatSheets()
        {
            _cheatSheets = new List<CheatSheet>();
            foreach (var sheet in CheatSheetLoader.LoadCheatSheets())
            {
                _cheatSheets.Add(sheet);
            }

            CurrentIndex = _cheatSheets.Count > 0 ? 0 : -1;
            CheatSheetViewModel.CheatSheet = CurrentCheatSheet;
        }

        private void SwitchSheet(string directionString)
        {
            if (CurrentIndex == -1) return;
            if ("left".Equals(directionString))
            {
                if (CurrentIndex > 0)
                {
                    CurrentIndex -= 1;
                }
                else
                {
                    CurrentIndex = _cheatSheets.Count - 1;
                }
            }
            else
            {
                if (CurrentIndex < _cheatSheets.Count - 1)
                {
                    CurrentIndex += 1;
                }
                else
                {
                    CurrentIndex = 0;
                }
            }

            CheatSheetViewModel.CheatSheet = CurrentCheatSheet;
        }

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}