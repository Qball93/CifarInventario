using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CifarInventario.ViewModels.Commands.FacturaCommands
{
    public class CreateFacturaGenerarLotes : ICommand
    {
        public FacturasVM VM { get; set; }


        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public CreateFacturaGenerarLotes(FacturasVM vm)
        {
            VM = vm;
        }


        public bool CanExecute(object parameter)
        {
            //return true;
            return !VM.NewFacturaNewDetalle.HasErrors && VM.NewFacturaNewDetalle.cantidadCheck && VM.SelectedProduct.nameCheck;
        }

        public void Execute(object parameter)
        {
            VM.generateLotesFromProduct();
        }
    }
}
