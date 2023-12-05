using CommunityToolkit.Mvvm.Input;
using DataAccess.JSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esWordle.ViewModel
{
    public partial class GameSessionViewModel : ViewModelBase
    {
        private readonly WordAccessor wordAccessor;

        [ObservableProperty]
        private Word solution;

        public GameSessionViewModel(WordAccessor wordAccessor)
        {
            this.wordAccessor = wordAccessor;
        }

        /// <summary>
        /// Picks a pseudo random word from the default words and sets it as the <see cref="Solution"/>.
        /// </summary>
        public async Task SetSolution()
        {
            var words = await wordAccessor.Words.Value;

            Random random = new Random();
            var number = random.Next(words.Count);

            Solution = words.ElementAt(number);
        }
    }
}
