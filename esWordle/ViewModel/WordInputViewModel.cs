using CommunityToolkit.Mvvm.Input;
using DataAccess.Model;

namespace esWordle.ViewModel
{
    public partial class WordInputViewModel : ViewModelBase
    {
        [ObservableProperty]
        private LetterHighlightColor firstLetterColor;
        [ObservableProperty]
        private LetterHighlightColor secondLetterColor;
        [ObservableProperty]
        private LetterHighlightColor thirdLetterColor;
        [ObservableProperty]
        private LetterHighlightColor fourthLetterColor;
        [ObservableProperty]
        private LetterHighlightColor fifthLetterColor;

        private readonly RuleEnforcer ruleEnforcer;
        private readonly GameSessionViewModel gameSessionViewModel;

        public WordInputViewModel(RuleEnforcer ruleEnforcer, GameSessionViewModel gameSessionViewModel)
        {
            this.ruleEnforcer = ruleEnforcer;
            this.gameSessionViewModel = gameSessionViewModel;
        }

        [RelayCommand(CanExecute = nameof(CanExecuteConfirmInput))]
        private void ConfirmInput(Input input)
        {
            FirstLetterColor = ruleEnforcer.GetLetterHighlightColor(input.Word.Letters[0].ToString(), 0, gameSessionViewModel.Solution);
            SecondLetterColor = ruleEnforcer.GetLetterHighlightColor(input.Word.Letters[1].ToString(), 1, gameSessionViewModel.Solution);
            ThirdLetterColor = ruleEnforcer.GetLetterHighlightColor(input.Word.Letters[2].ToString(), 2, gameSessionViewModel.Solution);
            FourthLetterColor = ruleEnforcer.GetLetterHighlightColor(input.Word.Letters[3].ToString(), 3, gameSessionViewModel.Solution);
            FifthLetterColor = ruleEnforcer.GetLetterHighlightColor(input.Word.Letters[4].ToString(), 4, gameSessionViewModel.Solution);
        }

        private bool CanExecuteConfirmInput(Input input)
        {
            if (input == null)
            {
                return false;
            }

            if (input.Word.Letters.Count() != Word.WordLength)
            {
                return false;
            }

            // checking for word to exist as a word in general goes here

            return true;
        }
    }
}