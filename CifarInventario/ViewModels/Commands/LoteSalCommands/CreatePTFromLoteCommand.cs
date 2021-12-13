using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CifarInventario.ViewModels.Commands.LoteSalCommands
{
    public class CreatePTFromLoteCommand : ICommand
    {
        public LotesSalidaVM VM { get; set; }


        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public CreatePTFromLoteCommand(LotesSalidaVM vm)
        {
            VM = vm;
        }


        public bool CanExecute(object parameter)
        {
            return !VM.NewLotePT.HasErrors && VM.NewLotePT.CodigoCheck && (VM.SelectedPT != null);
            //return !VM.EmptyAmount.HasErrors && !VM.NewLotePackage.HasErrors && VM.NewLotePackage.existenciaCheck;
        }

        public void Execute(object parameter)
        {
            VM.CreateProductoTerminado();
        }
    }
}
