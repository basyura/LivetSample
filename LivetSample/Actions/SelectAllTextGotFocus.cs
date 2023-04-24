using System;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace LivetSample.Actions
{
    public class SelectAllTextGotFocus : ActionBase
    {
        public override Task<bool> Execute(object sender, EventArgs evnt, object parameter)
        {
            var text = sender as TextBox;
            text.SelectAll();
            return OK;
        }
    }
}
