using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using LivetSample.Behaviors;

namespace LivetSample.Actions
{
    public class SelectAllTextButtonDown : ActionCommand<MainWindowViewModel>
    {
        public override Task<bool> Execute(object sender, EventArgs evnt, object parameter)
        {
            var text = sender as TextBox;
            if (text.IsFocused)
            {
                return OK;
            }

            (evnt as MouseButtonEventArgs).Handled = true;
            text.Focus();

            return OK;
        }
    }
}
