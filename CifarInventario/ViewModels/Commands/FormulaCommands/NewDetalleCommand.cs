using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Threading.Tasks;

namespace CifarInventario.ViewModels.Commands.FormulaCommands
{
    public class NewDetalleCommand : ICommand
    {
        public FormulasVM VM { get; set; }


        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public NewDetalleCommand(FormulasVM vm)
        {
            VM = vm;
        }


        public bool CanExecute(object parameter)
        {
            //return true;
            return !VM.NewFormulaNewDetalle.HasErrors && VM.NewFormulaNewDetalle.QuantityCheck;
        }

        public void Execute(object parameter)
        {
            VM.AgregarDetalle();
        }
    }
}
