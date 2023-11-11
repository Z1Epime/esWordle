using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esWordle.ViewModel
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        [ObservableProperty]
        private MainNavigationService navigationService;

        public MainWindowViewModel(MainNavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        [RelayCommand]
        private void GoToGame()
        {
            NavigationService.NavigateTo<GameViewModel>();
        }

        [RelayCommand]
        private void GoToOptions()
        {
            NavigationService.NavigateTo<OptionsViewModel>();
        }

        [RelayCommand]
        private void Exit()
        {
            Application.Current.Shutdown();
        }
    }
}
