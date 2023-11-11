using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esWordle.View
{
    public partial class MainNavigationService : ObservableObject
    {
        [ObservableProperty]
        private ViewModelBase currentView;

        public void NavigateTo<TViewModel>() where TViewModel : ViewModelBase
        {
            var viewModel = App.ServiceProvider.GetService<TViewModel>();

            if (CurrentView ?.GetType() != viewModel.GetType())
                CurrentView = viewModel;
        }
    }
}
