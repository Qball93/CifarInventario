using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CifarInventario.ViewModels.Commands.FacturaCommands
{
    public class UpdateFacturaBalanceCommand : ICommand
    {
        public FacturasVM VM { get; set; }


        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public UpdateFacturaBalanceCommand(FacturasVM vm)
        {
            VM = vm;
        }


        public bool CanExecute(object parameter)
        {
            //return true;
            return !VM.HasErrors;
        }

        public void Execute(object parameter)
        {
            VM.EditFactura();
        }
    }
}
