using System;
using System.Threading.Tasks;
using LivetSample.Behaviors;

namespace LivetSample.Actions
{
    public class AddOne : ActionCommand<MainWindowViewModel>
    {
        public override Task<bool> Execute(object sender, EventArgs evnt, object parameter)
        {
            ViewModel.Value1++;
            return OK;
        }
    }
}
