using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace esWordle.View.Controls
{
    public partial class WordInput : UserControl
    {
        public static readonly DependencyProperty InputTryProperty = DependencyProperty.Register(
            nameof(InputTry), typeof(InputTry),
            typeof(WordInput)
            );

        public InputTry InputTry
        {
            get => (InputTry)GetValue(InputTryProperty);
            set => SetValue(InputTryProperty, value);
        }

        private WordInputViewModel viewModel;

        public WordInput()
        {
            InitializeComponent();
            viewModel = App.ServiceProvider.GetRequiredService<WordInputViewModel>();
            DataContext = viewModel;
        }

        public void ClearLetters()
        {
            viewModel.FirstLetter = "";
            viewModel.SecondLetter = "";
            viewModel.ThirdLetter = "";
            viewModel.FourthLetter = "";
            viewModel.FifthLetter = "";

            viewModel.FirstLetterColor = default;
            viewModel.SecondLetterColor = default;
            viewModel.ThirdLetterColor = default;
            viewModel.FourthLetterColor = default;
            viewModel.FifthLetterColor = default;
        }
    }
}
