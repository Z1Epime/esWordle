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

        [RelayCommand(CanExecute = nameof(CanExecuteConfirmInput))]
        private void ConfirmInput(Input inputInfo)
        {
            if (inputInfo.Try == InputTry.Sixth)
            {
                // stuff to end game goes here ?

                return;
            }

            // showing letter hints goes here ?

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

            // checking for word to exist in game data goes here

            return true;
        }
    }
}
