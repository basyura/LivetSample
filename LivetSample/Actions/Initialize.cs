using System;
using System.Threading.Tasks;

namespace LivetSample.Actions
{
    public class Initialize : ActionBase
    {
        public override Task<bool> Execute(object sender, EventArgs evnt, object parameter)
        {
            ViewModel.Message = "Hello LivetSample.";
            return OK;
        }
    }
}
