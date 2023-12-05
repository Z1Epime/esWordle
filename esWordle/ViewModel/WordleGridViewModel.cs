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
        public static readonly Word Solution;

        [ObservableProperty]
        private InputTry currentTry;

        static WordleGridViewModel()
        {
            Solution = new Word("Roach"); // TODO: get random word and remove static hack here
        }

        [RelayCommand(CanExecute = nameof(CanExecuteConfirmInput))]
        private void ConfirmInput(Input inputInfo)
        {
            if (inputInfo.Word.Letters.Equals(Solution.Letters, StringComparison.OrdinalIgnoreCase) && // word found
                inputInfo.Try == InputTry.Sixth) // used last try
            {
                // stuff to end game goes here ?
            }

            CurrentTry = inputInfo.Try.Next();
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
