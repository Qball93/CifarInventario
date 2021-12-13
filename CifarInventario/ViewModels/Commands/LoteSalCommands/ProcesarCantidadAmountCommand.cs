using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Input;

namespace CifarInventario.ViewModels.Commands.LoteSalCommands
{
    public class ProcesarCantidadAmountCommand : ICommand
    {
        public LotesSalidaVM VM { get; set; }


        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public ProcesarCantidadAmountCommand(LotesSalidaVM vm)
        {
            VM = vm;
        }


        public bool CanExecute(object parameter)
        {
            //return true;
            return !VM.NewLotePT.HasErrors && VM.NewLotePT.CantidadCheck  && !VM.PlaceHolder.HasErrors && VM.PlaceHolder.AmountCheck;
        }

        public void Execute(object parameter)
        {
            VM.ProcesarCantidades();
        }
    }
}
