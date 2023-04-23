using Livet;
using Livet.Commands;

namespace LivetSample
{
    public class MainWindowViewModel : ViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        private string _Message;
        public string Message
        {
            get => _Message;
            set => RaisePropertyChangedIfSet(ref _Message, value);
        }
        /// <summary>
        /// 
        /// </summary>
        private int _Value1;
        public int Value1
        {
            get => _Value1;
            set => RaisePropertyChangedIfSet(ref _Value1, value, nameof(Value3));
        }
        /// <summary>
        /// 
        /// </summary>
        private int _Value2;
        public int Value2
        {
            get => _Value2;
            set => RaisePropertyChangedIfSet(ref _Value2, value, nameof(Value3));
        }
        /// <summary>
        /// 
        /// </summary>
        public int Value3
        {
            get => Value1 + Value2;
        }
        /// <summary>
        /// 
        /// </summary>
        public void InvokeClick(string param)
        {
            Message = "From LivetCallMethodAction : " + param;
        }
        /// <summary>
        /// 
        /// </summary>
        private ListenerCommand<string> _ButtonCommand;
        public ListenerCommand<string> ButtonCommand
        {
            get
            {
                if (_ButtonCommand == null)
                {
                    _ButtonCommand = new ListenerCommand<string>((param) => {
                        Message = "From InvokeCommandAction : " + param;
                    });
                }
                return _ButtonCommand;
            }
        }
    }
}
