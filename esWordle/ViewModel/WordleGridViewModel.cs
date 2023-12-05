using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esWordle.ViewModel
{
    public partial class WordleGridViewModel : ViewModelBase
    {
        [ObservableProperty]
        private InputTry currentTry;

        [ObservableProperty]
        private bool gameEnded;

        [ObservableProperty]
        private bool solutionFound;

        [ObservableProperty]
        private GameSessionViewModel gameSessionViewModel;

        public WordleGridViewModel(GameSessionViewModel gameSessionViewModel)
        {
            this.gameSessionViewModel = gameSessionViewModel;
        }

        [RelayCommand(CanExecute = nameof(CanExecuteConfirmInput))]
        private void ConfirmInput(Input inputInfo)
        {
            // word found
            if (inputInfo.Word.Letters.Equals(GameSessionViewModel.Solution.Letters, StringComparison.OrdinalIgnoreCase))
            {
                SolutionFound = true;
                GameEnded = true;
                return;
            }

            // used last try
            if (inputInfo.Try == InputTry.Sixth)
            {
                GameEnded = true;
                return;
            }

            CurrentTry = inputInfo.Try.Next();
        }

        [RelayCommand]
        private async Task InitWordle()
        {
            // Every time the user navigates to the GameView, the WordleGrid view fires "Loaded" and this gets called.
            // This check will prevent the solution word to get picked every time anew
            if (GameSessionViewModel.Solution == null)
            {
                await GameSessionViewModel.SetSolution();
            }
        }

        private bool CanExecuteConfirmInput(Input inputInfo)
        {
            if (inputInfo == null)
            {
                return false;
            }

            if (inputInfo.Word.Letters.Length != Word.WordLength)
            {
                return false;
            }
            return true;
        }
    }
}
