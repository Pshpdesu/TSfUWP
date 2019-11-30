using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CustomComponents.HamburgerMenu
{
    public class MenuItem
    {
        public string ItemText { get; set; }
        public IconElement Icon { get; set; }
        public Command onClick { get; set; }

    }
    public class Command : ICommand
    {

        private readonly Action<object> action;
        private readonly Func<object,bool> canExecute;

        public event EventHandler CanExecuteChanged;

        public Command(Action<object> action, Func<object,bool> executeCheck = null)
        {
            this.action = action;
            this.canExecute = executeCheck;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute.Equals(null) ? true : canExecute(parameter);
        }

        public async void Execute(object parameter)
        {
            await Task.Run(()=>action(parameter));
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
