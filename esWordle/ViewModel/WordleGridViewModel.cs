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
        private GameSessionViewModel gameSessionViewModel;

        public WordleGridViewModel(GameSessionViewModel gameSessionViewModel)
        {
            this.gameSessionViewModel = gameSessionViewModel;
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
    }
}
