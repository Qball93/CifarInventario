using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CifarInventario.ViewModels.Commands.FormulaCommands
{
    public class NewFormulaCommand: ICommand
    {
        public FormulasVM VM { get; set; }


        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public NewFormulaCommand(FormulasVM vm)
        {
            VM = vm;
        }


        public bool CanExecute(object parameter)
        {
            //return true;
            return !VM.NewFormula.HasErrors && VM.NewFormula.CodCheck && VM.NewFormula.NombreCheck;
        }

        public void Execute(object parameter)
        {
            VM.createFormula();
        }
    }
}
