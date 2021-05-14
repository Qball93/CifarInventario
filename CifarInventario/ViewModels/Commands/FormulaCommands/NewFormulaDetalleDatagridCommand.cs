using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CifarInventario.ViewModels.Commands.FormulaCommands
{
    public class NewFormulaDetalleDatagridCommand:ICommand
    {
        public FormulasVM VM { get; set; }


        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public NewFormulaDetalleDatagridCommand(FormulasVM vm)
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
            VM.NewFormullaDataGridDetalle();
        }

    }
}
