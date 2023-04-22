using Livet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivetSample.Actions
{
    public abstract class IActionCommand
    {
        /// <summary></summary>
        private ViewModel _vm;
        /// <summary></summary>
        protected Task<bool> OK => Task.Run(() => true);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="vm"></param>
        public virtual void Initialize(ViewModel vm)
        {
            _vm = vm;
        }
        /// <summary></summary>
        protected ViewModel ViewModel
        {
            get { return _vm; }
        }
        /// <summary>
        /// 
        /// </summary>
        public abstract Task<bool> Execute(object sender, EventArgs evnt, object parameter);
    }
}
