using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CifarInventario.ViewModels.Commands.FacturaCommands
{
    public class CreateFacturaAddDetalle : ICommand
    {
        public FacturasVM VM { get; set; }


        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public CreateFacturaAddDetalle(FacturasVM vm)
        {
            VM = vm;
        }


        public bool CanExecute(object parameter)
        {
            //return true;
            return !VM.NewFacturaNewDetalle.HasErrors && VM.NewFacturaNewDetalle.cantidadCheck && VM.NewFacturaNewDetalle.loteCheck && !VM.IsProductEnabled && VM.IsLoteEnabled;  
        }

        public void Execute(object parameter)
        {
            VM.addProductToDetalles();
        }
    }
}
