using CommunityToolkit.Mvvm.Input;
using DataAccess.Model;
using esWordle.ViewModel;

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

        public WordInputViewModel(RuleEnforcer ruleEnforcer)
        {
            this.ruleEnforcer = ruleEnforcer;
        }

        [RelayCommand(CanExecute = nameof(CanExecuteConfirmInput))]
        private void ConfirmInput(Input input)
        {
            FirstLetterColor = ruleEnforcer.GetLetterHighlightColor(input.Word.Letters[0].ToString(), 0, WordleGridViewModel.Solution);
            SecondLetterColor = ruleEnforcer.GetLetterHighlightColor(input.Word.Letters[1].ToString(), 1, WordleGridViewModel.Solution);
            ThirdLetterColor = ruleEnforcer.GetLetterHighlightColor(input.Word.Letters[2].ToString(), 2, WordleGridViewModel.Solution);
            FourthLetterColor = ruleEnforcer.GetLetterHighlightColor(input.Word.Letters[3].ToString(), 3, WordleGridViewModel.Solution);
            FifthLetterColor = ruleEnforcer.GetLetterHighlightColor(input.Word.Letters[4].ToString(), 4, WordleGridViewModel.Solution);
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