﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sticky.Util
{
    using System;
    using System.Windows.Input;


    /// <summary>
    /// Command用クラス
    /// </summary>
    public sealed class RelayCommand : ICommand
    {

        #region 内部変数

        /// <summary>実行用メソッド</summary>
        private Action<object> execute_ = null;

        /// <summary>実行可否判定用メソッド</summary>
        private Predicate<object> canExecute_ = null;

        #endregion

        #region コンストラクタ

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="execute">実行用メソッド</param>
        /// <param name="canExecute">実行可否判定用メソッド</param>
        public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
        {
            execute_ = execute;
            canExecute_ = canExecute;
        }

        #endregion

        #region ICommand メンバー

        /// <summary>
        /// 実行可能かどうかを取得します。
        /// </summary>
        /// <param name="parameter">コマンドパラメータ</param>
        /// <returns>true:実行可能</returns>
        public bool CanExecute(object parameter)
        {
            return canExecute_ == null ? true : canExecute_(parameter);
        }

        /// <summary>変更可否判定値変更イベント</summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// 実行します。
        /// </summary>
        /// <param name="parameter">コマンドパラメータ</param>
        public void Execute(object parameter)
        {
            execute_(parameter);
            return;
        }

        #endregion

    }
}
