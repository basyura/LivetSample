using Livet;
using System.Reflection;
using LivetSample.Actions;
using System.Reflection.Emit;
using Microsoft.Xaml.Behaviors;
using System.Threading.Tasks;
using System;
using System.Windows;

namespace LivetSample.Behaviors
{
    public class Execute : TriggerAction<DependencyObject>
    {
        protected override void Invoke(object parameter)
        {
            var vm = GetViewModel();
            if (vm == null)
            {
                MessageBox.Show("No ViewModel");
                return;
            }

            var clsName = BuildClassName(vm);
            var cmd = NewCommand(vm, clsName);

            InvokeAsync(cmd, parameter).ContinueWith((v) =>
            {
            });

        }

        private async Task<bool> InvokeAsync(IActionCommand cmd, object parameter)
        {
            object sender = AssociatedObject;
            return await cmd.Execute(AssociatedObject, parameter as EventArgs, ActionParameter);
        }

        public string Action { get; set; }

        public string ActionParameter { get; set; }
        /*
        public object ActionParameter
        {
            get { return GetValue(ActionParameterProperty); }
            set { SetValue(ActionParameterProperty, value); }
        }
        // Using a DependencyProperty as the backing store for MethodParameter.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ActionParameterProperty =
            DependencyProperty.Register("ActionParameter", typeof(object), typeof(Execute), new PropertyMetadata(null, OnActionParameterChanged));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void OnActionParameterChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var thisReference = (Execute)sender;
            thisReference.ActionParameter = e.NewValue;
        }
        */
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private ViewModel GetViewModel()
        {
            DependencyObject dep = AssociatedObject as DependencyObject;
            FrameworkElement ele = dep as FrameworkElement;
            if (ele != null && ele.DataContext is ViewModel)
            {
                return ele.DataContext as ViewModel;
            }

            while(dep != null)
            {
                dep = LogicalTreeHelper.GetParent(dep);
                ele = dep as FrameworkElement;
                if (ele != null && ele.DataContext is ViewModel)
                {
                    return ele.DataContext as ViewModel;
                }
            }

            Window window = Window.GetWindow(AssociatedObject);
            if (window != null)
            {
                return window.DataContext as ViewModel;
            }

            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string BuildClassName(ViewModel vm)
        {
            // 呼び出し対象のクラス名を生成
            //var vmType = vm.GetType();
            //var dir    = vmType.Name.Replace("ViewModel", "");
            //var name   = vmType.FullName;
            var clazz = "LivetSample.Actions." + Action;

            return clazz;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private IActionCommand NewCommand(ViewModel vm, string clazz)
        {
            // アセンブリを取得
            Assembly asm = Assembly.GetAssembly(vm.GetType());
            // アクションクラスを取得
            Type type = asm.GetType(clazz);
            if (type == null)
            {
                return null;
            }
            // インスタンス生成
            IActionCommand action = Activator.CreateInstance(type) as IActionCommand;
            // 初期化
            action.Initialize(vm);

            return action;
        }
    }
}
