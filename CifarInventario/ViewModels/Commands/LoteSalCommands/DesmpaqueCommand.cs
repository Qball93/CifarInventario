using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CifarInventario.ViewModels.Commands.LoteSalCommands
{
    public class DesmpaqueCommand : ICommand
    {
        public LotesSalidaVM VM { get; set; }


        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public DesmpaqueCommand(LotesSalidaVM vm)
        {
            VM = vm;
        }


        public bool CanExecute(object parameter)
        {
            //return true;
            return !VM.PlaceHolder.HasErrors && VM.PlaceHolder.CantidadCheck && VM.PlaceHolder.AmountCheck;
        }

        public void Execute(object parameter)
        {
            VM.RegresarCantidades();
        }
    }
}