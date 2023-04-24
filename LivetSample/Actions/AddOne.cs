using System;
using System.Threading.Tasks;

namespace LivetSample.Actions
{
    public class AddOne : ActionBase
    {
        public override Task<bool> Execute(object sender, EventArgs evnt, object parameter)
        {
            ViewModel.Value1++;
            return OK;
        }
    }
}
