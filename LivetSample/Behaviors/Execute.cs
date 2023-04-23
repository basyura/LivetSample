﻿using Livet;
using Microsoft.Xaml.Behaviors;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;

namespace LivetSample.Behaviors
{
    public class Execute : TriggerAction<DependencyObject>
    {
        /// <summary></summary>
        public string Action { get; set; }
        /// <summary></summary>
        public string ActionParameter { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
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
            if (cmd == null)
            {
                MessageBox.Show("Can not createInstance : " + clsName);
                return;
            }

            InvokeAsync(cmd, parameter).ContinueWith((v) =>
            {
            });

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        private async Task<bool> InvokeAsync(IActionCommand cmd, object parameter)
        {
            return await cmd.Execute(AssociatedObject, parameter as EventArgs, ActionParameter);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private ViewModel GetViewModel()
        {
            var dep = AssociatedObject;
            var ele = AssociatedObject as FrameworkElement;
            if (AssociatedObject is FrameworkElement && ele.DataContext is ViewModel)
            {
                return ele.DataContext as ViewModel;
            }

            while (dep != null)
            {
                dep = LogicalTreeHelper.GetParent(dep);
                ele = dep as FrameworkElement;
                if (ele != null && ele.DataContext is ViewModel)
                {
                    return ele.DataContext as ViewModel;
                }
            }

            var window = Window.GetWindow(AssociatedObject);
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
            var asm = Assembly.GetAssembly(vm.GetType());
            var type = asm.GetType(clazz);
            if (type == null)
            {
                return null;
            }
            var vmType = type.BaseType.GetGenericArguments().FirstOrDefault();
            if (vmType == null)
            {
                return null;
            }

            var cmd = Activator.CreateInstance(type) as IActionCommand;
            if (cmd == null)
            {
                return null;
            }

            cmd.Initialize(vm);

            return cmd;
        }
    }
}
