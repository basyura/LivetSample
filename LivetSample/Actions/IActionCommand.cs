﻿using Livet;
using System;
using System.Threading.Tasks;

namespace LivetSample.Actions
{

    public interface IActionCommand
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="vm"></param>
        void Initialize(ViewModel vm);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="evnt"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        Task<bool> Execute(object sender, EventArgs evnt, object parameter);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class IActionCommand<T> : IActionCommand where T : ViewModel
    {
        /// <summary></summary>
        protected Task<bool> OK => Task.Run(() => true);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="vm"></param>
        public virtual void Initialize(ViewModel vm)
        {
            ViewModel = vm as T;
        }
        /// <summary></summary>
        protected T ViewModel
        {
            get; set;
        }
        /// <summary>
        /// 
        /// </summary>
        public abstract Task<bool> Execute(object sender, EventArgs evnt, object parameter);
    }
}
