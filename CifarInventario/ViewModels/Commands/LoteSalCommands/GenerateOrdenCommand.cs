using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CifarInventario.ViewModels.Commands.LoteSalCommands
{
    public class GenerateOrdenCommand: ICommand
    {
        public LoteSalidaCreateVM VM { get; set; }


        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public GenerateOrdenCommand(LoteSalidaCreateVM vm)
        {
            VM = vm;
        }


        public bool CanExecute(object parameter)
        {
            //return true;
            return (VM.NuevoLote.CantidadCheck && !VM.NuevoLote.HasErrors);
        }

        public void Execute(object parameter)
        {
            VM.CreateOrden();
        }
    }
}
