using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using System.Text;
using System.Threading.Tasks;

namespace CifarInventario.ViewModels.Commands.FormulaCommands
{
    public class NewInstructionCommand: ICommand
    {
        public FormulasVM VM { get; set; }


        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public NewInstructionCommand(FormulasVM vm)
        {
            VM = vm;
        }


        public bool CanExecute(object parameter)
        {
            //return true;
            return !VM.NewFormulaNewInstruction.HasErrors && VM.NewFormulaNewInstruction.InstructionCheck;
        }

        public void Execute(object parameter)
        {
            VM.AgregarProcediminetoDetalle();
        }
    }
}
