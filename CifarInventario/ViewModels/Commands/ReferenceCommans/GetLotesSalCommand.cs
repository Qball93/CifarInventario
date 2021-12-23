using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CifarInventario.ViewModels.Commands.ReferenceCommans
{
    public class GetLotesSalCommand : ICommand
    {
        public ReferenciasVM VM { get; set; }


        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public GetLotesSalCommand(ReferenciasVM vm)
        {
            VM = vm;
        }


        public bool CanExecute(object parameter)
        {

            //return !VM.EmptyAmount.HasErrors && !VM.NewLotePackage.HasErrors && VM.NewLotePackage.existenciaCheck;

            return VM.Lotes.Count > 0;
        }

        public void Execute(object parameter)
        {


            VM.buscarLoteSalPorMp();


        }
    }
}
