using System;
using System.Collections.Generic;
using System.Linq;
using CifarInventario.ViewModels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CifarInventario.ViewModels.Commands.LoteSalCommands
{
    public class GenerateLotesFromMpCommand : ICommand
    {
        public LotesSalidaVM VM { get; set; }


        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public GenerateLotesFromMpCommand(LotesSalidaVM vm)
        {
            VM = vm;
        }


        public bool CanExecute(object parameter)
        {
            //return true;
            return !VM.NewLotePackageDetalle.HasErrors && VM.NewLotePackageDetalle.cantidadCheck;
        }

        public void Execute(object parameter)
        {
            VM.BuscarLotes();
        }
    }
}
