using System;
using System.Threading.Tasks;
using LivetSample.Behaviors;

namespace LivetSample.Actions
{
    public class HelloAction : ActionCommand<MainWindowViewModel>
    {
        public override Task<bool> Execute(object sender, EventArgs evnt, object parameter)
        {
            ViewModel.Message = "From HelloAction"; 

            return OK;
        }
    }
}
