using Livet;
using System;
using System.Threading.Tasks;

namespace LivetSample.Actions
{
    public class HelloAction : IActionCommand
    {
        public override Task<bool> Execute(object sender, EventArgs evnt, object parameter)
        {
            ((MainWindowViewModel)ViewModel).Message = "From HelloAction"; 

            return OK;
        }
    }
}
