using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using PonderingProgrammer.QuickSheet.Annotations;
using PonderingProgrammer.QuickSheet.Model;
using PonderingProgrammer.QuickSheet.Services;

namespace PonderingProgrammer.QuickSheet.CheatSheetViewer
{
    public sealed class CheatSheetsViewModel : INotifyPropertyChanged
    {
        private List<CheatSheetViewModel> _cheatSheets;
        private int _currentIndex;
        private DelegateCommand<string> _updateSizeCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        
        public CheatSheetsViewModel()
        {
            ReloadCheatSheets();
            _updateSizeCommand = new DelegateCommand<string>(
                s =>
                {
                    OnPropertyChanged(nameof(TitleFontSize));
                    OnPropertyChanged(nameof(SectionFontSize));
                    OnPropertyChanged(nameof(CaptionFontSize));
                    OnPropertyChanged(nameof(EntryFontSize));
                });
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

        public DelegateCommand<string> UpdateSizeCommand => _updateSizeCommand;

        private void ReloadCheatSheets()
        {
            _cheatSheets = new List<CheatSheetViewModel>();
            foreach (var sheet in CheatSheetLoader.LoadCheatSheets())
            {
                _cheatSheets.Add(new CheatSheetViewModel(sheet));
            }

            CurrentIndex = _cheatSheets.Count > 0 ? 0 : -1;
        }

        public int TitleFontSize => (int) (BaseFontSize * 1.5);
        public int SectionFontSize => (int) (BaseFontSize * 1.2);
        public int CaptionFontSize => (int) (BaseFontSize * 1.1);
        public int EntryFontSize => BaseFontSize;

        public int BaseFontSize
        {
            get
            {
                if (Application.Current.MainWindow != null)
                {
                    var h = (int) ((Panel) Application.Current.MainWindow.Content).ActualHeight;
                    var w = (int) ((Panel) Application.Current.MainWindow.Content).ActualWidth;
                    return 6 + (h / (GetRequiredLines() * 5));
                }
                else
                {
                    return 12;
                }
            }
        }

        private int GetRequiredLines()
        {
            return Math.Max(GetHighestSectionLineCount(), GetLineCount(CurrentCheatSheet) / GetMaxColumns());
        }

        private int GetMaxColumns()
        {
            return 10;
        }

        private int GetHighestSectionLineCount()
        {
            return CurrentCheatSheet.Sections.Max(GetLineCount);
        }

        private static int GetLineCount(CheatSheetViewModel cheatSheet)
        {
            return 1 + cheatSheet.Sections.Sum(GetLineCount);
        }

        private static int GetLineCount(SectionViewModel section)
        {
            return 1 + section.Cheats.Sum(GetLineCount);
        }

        private static int GetLineCount(Cheat cheat)
        {
            return 1 + cheat.Entries.Count;
        }

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}