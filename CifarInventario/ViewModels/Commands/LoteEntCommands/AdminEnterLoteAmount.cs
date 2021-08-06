using System;
using System.Collections.Generic;
using System.Linq;
using CifarInventario.ViewModels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CifarInventario.ViewModels.Commands.LoteEntCommands
{
    public class AdminEnterLoteAmount : ICommand
    {
        public LoteEntAdminVM VM { get; set; }


        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public AdminEnterLoteAmount(LoteEntAdminVM vm)
        {
            VM = vm;
        }


        public bool CanExecute(object parameter)
        {
            return true;

        }

        public void Execute(object parameter)
        {
            VM.ReEnterLote();
        }
    }
}