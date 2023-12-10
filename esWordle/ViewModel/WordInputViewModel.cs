using CommunityToolkit.Mvvm.Input;
using DataAccess.Model;
using System.Printing;
using System.Text.RegularExpressions;

namespace esWordle.ViewModel
{
    public partial class WordInputViewModel : ViewModelBase
    {
        [ObservableProperty]
        private HighlightColor firstLetterColor;
        [ObservableProperty]
        private HighlightColor secondLetterColor;
        [ObservableProperty]
        private HighlightColor thirdLetterColor;
        [ObservableProperty]
        private HighlightColor fourthLetterColor;
        [ObservableProperty]
        private HighlightColor fifthLetterColor;

        [ObservableProperty]
        private string firstLetter;
        [ObservableProperty]
        private string secondLetter;
        [ObservableProperty]
        private string thirdLetter;
        [ObservableProperty]
        private string fourthLetter;
        [ObservableProperty]
        private string fifthLetter;

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
            FirstLetterColor = ruleEnforcer.GetLetterHighlightColor(input.Word.Letters.ElementAt(0).Character, 0, gameSessionViewModel.Solution);
            SecondLetterColor = ruleEnforcer.GetLetterHighlightColor(input.Word.Letters.ElementAt(1).Character, 1, gameSessionViewModel.Solution);
            ThirdLetterColor = ruleEnforcer.GetLetterHighlightColor(input.Word.Letters.ElementAt(2).Character, 2, gameSessionViewModel.Solution);
            FourthLetterColor = ruleEnforcer.GetLetterHighlightColor(input.Word.Letters.ElementAt(3).Character, 3, gameSessionViewModel.Solution);
            FifthLetterColor = ruleEnforcer.GetLetterHighlightColor(input.Word.Letters.ElementAt(4).Character, 4, gameSessionViewModel.Solution);
            
            gameSessionViewModel.ConfirmInput(input);
        }

        private bool CanExecuteConfirmInput(Input input)
        {
            if (input == null)
            {
                return false;
            }

            if (input.Word.Letters.Count() != Word.WordLength ||
                input.Word.Letters.Where(l => string.IsNullOrWhiteSpace(l.Character)).Count() != 0)
            {
                return false;
            }

            // checking for word to exist as a word in general goes here

            return true;
        }

        [RelayCommand]
        private void DenyNonLetters(TextCompositionEventArgs args)
        {
            if (!Regex.IsMatch(args.Text, RuleEnforcer.OnlyLettersRegex))
            {
                args.Handled = true;
            }
        }

        [RelayCommand]
        private void DenySpace(KeyEventArgs args)
        {
            if (args.Key == Key.Space)
            {
                args.Handled = true;
            }
        }
    }
}