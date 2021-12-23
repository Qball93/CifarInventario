using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CifarInventario.ViewModels.Commands.ReferenceCommans
{
    public class GetFacturasCommand : ICommand
    {
        public ReferenciasVM VM { get; set; }


        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public GetFacturasCommand(ReferenciasVM vm)
        {
            VM = vm;
        }


        public bool CanExecute(object parameter)
        {

            //return !VM.EmptyAmount.HasErrors && !VM.NewLotePackage.HasErrors && VM.NewLotePackage.existenciaCheck;

            return !VM.PlaceHolder.HasErrors && VM.PlaceHolder.WordCheck;
        }

        public void Execute(object parameter)
        {

            

            if(VM.SelectedTipo == "Lote Salida")
            {
                VM.buscarPorLoteSal();
            }
            else
            {
                VM.buscarPorLotePT();
            }

            
        }
    }
}
