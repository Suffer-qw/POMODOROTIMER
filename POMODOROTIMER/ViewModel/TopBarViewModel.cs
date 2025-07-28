using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using POMODOROTIMER.MvvM;

namespace POMODOROTIMER.ViewModel
{
    internal class TopBarViewModel
    {
        public RelayCommand CloseCommand { get; }
        public RelayCommand MaximizeCommand { get; }
        public RelayCommand MinimizeCommand { get; }
        public TopBarViewModel()
        {
            CloseCommand = new RelayCommand(
                execute: (parameter) => CloseCom(parameter), // Передаём параметр
                canExecute: (parameter) => true // Всегда доступна
            );
            MaximizeCommand = new RelayCommand(
                execute: (parameter) => MaximizeCom(parameter), // Передаём параметр
                canExecute: (parameter) => true // Всегда доступна
            );
            MinimizeCommand = new RelayCommand(
                execute: (parameter) => MinimizeCom(parameter), // Передаём параметр
                canExecute: (parameter) => true // Всегда доступна
            );
        }

        private void CloseCom(object parameter)
        {
            if (parameter is Window window)
            {
                window.Close();
            }
        }

        private void MaximizeCom(object parameter)
        {
            if (parameter is Window window)
            {
                if (window.WindowState != WindowState.Maximized)
                    window.WindowState = WindowState.Maximized;
                else window.WindowState = WindowState.Normal;
            }
        }

        private void MinimizeCom(object parameter)
        {
            if (parameter is Window window)
            {
                window.WindowState = WindowState.Minimized;
            }
        }



    }
}
