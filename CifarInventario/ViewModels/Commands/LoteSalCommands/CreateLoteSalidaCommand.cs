using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CifarInventario.ViewModels.Commands.LoteSalCommands
{
    public class CreateLoteSalidaCommand : ICommand
    {
        public LoteSalidaCreateVM VM { get; set; }


        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public CreateLoteSalidaCommand(LoteSalidaCreateVM vm)
        {
            VM = vm;
        }


        public bool CanExecute(object parameter)
        {
            //return true;
            return !VM.NuevoLote.HasErrors && VM.NuevoLote.CodCheck;
        }

        public void Execute(object parameter)
        {
            VM.CreateLoteSalida();
        }
    }
}
