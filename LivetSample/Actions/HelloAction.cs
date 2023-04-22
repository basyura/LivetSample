using System;
using System.Threading.Tasks;

namespace LivetSample.Actions
{
    public class HelloAction : IActionCommand<MainWindowViewModel>
    {
        public override Task<bool> Execute(object sender, EventArgs evnt, object parameter)
        {
            ViewModel.Message = "From HelloAction"; 

            return OK;
        }
    }
}
