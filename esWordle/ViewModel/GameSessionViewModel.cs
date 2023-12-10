using CommunityToolkit.Mvvm.Input;
using DataAccess.JSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esWordle.ViewModel
{
    public partial class GameSessionViewModel : ViewModelBase
    {
        private readonly WordAccessor wordAccessor;

        [ObservableProperty]
        private Word solution;

        [ObservableProperty]
        private bool gameEnded;

        [ObservableProperty]
        private bool solutionFound;

        [ObservableProperty]
        private InputTry currentTry;

        public GameSessionViewModel(WordAccessor wordAccessor)
        {
            this.wordAccessor = wordAccessor;
        }

        /// <summary>
        /// Picks a pseudo random word from the default words and sets it as the <see cref="Solution"/>.
        /// </summary>
        public async Task SetSolution()
        {
            var words = await wordAccessor.Words.Value;

            Random random = new Random();
            var number = random.Next(words.Count);

            Solution = words.ElementAt(number);
        }

        [RelayCommand]
        public async Task ResetGame()
        {
            await SetSolution();

            GameEnded = false;
            SolutionFound = false;
            CurrentTry = InputTry.First;
        }

        public void ConfirmInput(Input inputInfo)
        {
            if (inputInfo == null)
                return;

            if (inputInfo.Word.GetLettersAsString().Length != Word.WordLength)
                return;

            // word found
            if (inputInfo.Word.GetLettersAsString().Equals(Solution.GetLettersAsString(), StringComparison.OrdinalIgnoreCase))
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
    }
}
