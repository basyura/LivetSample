using System;
using System.Windows;
using System.Windows.Controls;
using System.Threading.Tasks;

namespace LivetSample.Actions
{
    public class Hello : ActionBase
    {
        public override Task<bool> Execute(object sender, EventArgs evnt, object parameter)
        {
            ViewModel.Message = "From HelloAction"; 

            var window = Window.GetWindow(sender as DependencyObject);
            var text =  window.FindName("Message2") as TextBlock;
            text.Text = " - Hi!";


            ExecuteCommand("AddOne");

            return OK;
        }
    }
}
