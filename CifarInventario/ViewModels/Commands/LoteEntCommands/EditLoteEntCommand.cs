using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CifarInventario.ViewModels.Commands.LoteEntCommands
{
    public class EditLoteEntCommand : ICommand
    {
        public LoteEntVM VM { get; set; }


        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public EditLoteEntCommand(LoteEntVM vm)
        {
            VM = vm;
        }


        public bool CanExecute(object parameter)
        {
            //return true;
            return !VM.NewLote.HasErrors && VM.NewLote.FechaCheck && VM.NewLote.ProcedenciaCheck && VM.NewLote.FabricanteCheck;
        }

        public void Execute(object parameter)
        {
            VM.EditLote();
        }
    }

}

