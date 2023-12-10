using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace esWordle.ViewModel
{
    public partial class OptionsViewModel : ViewModelBase
    {
        [ObservableProperty]
        private Uri uri;

        public OptionsViewModel()
        {
            Uri = new Uri("https://www.google.com/");
        }
    }
}
