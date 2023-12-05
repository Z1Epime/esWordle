using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace esWordle.View
{
    public class CompositeCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly IList<ICommand> _Commands;
        public CompositeCommand(IList<ICommand> commands)
        {
            if (commands == null) throw new ArgumentNullException(nameof(commands));
            _Commands = new List<ICommand>(commands);

            foreach (ICommand command in _Commands)
            {
                command.CanExecuteChanged += CommandsOnCanExecuteChanged;
            }
        }

        private void CommandsOnCanExecuteChanged(object sender, EventArgs eventArgs)
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public bool CanExecute(object parameter)
        {
            return _Commands.Aggregate(true, (current, command) => current & command.CanExecute(parameter));
        }

        public void Execute(object parameter)
        {
            foreach (ICommand command in _Commands)
            {
                command.Execute(parameter);
            }
        }
    }
}
