using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using System.Text;
using System.Threading.Tasks;

namespace CifarInventario.ViewModels.Commands.InventoryCommands
{
    public class EditMpCommand : ICommand
    {
        public InventarioMpVM VM { get; set; }


        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public EditMpCommand(InventarioMpVM vm)
        {
            VM = vm;
        }


        public bool CanExecute(object parameter)
        {
            
            return !VM.NewProduct.HasErrors && VM.NewProduct.ConversionCheck && VM.NewProduct.nombreCheck && VM.NewProduct.IdCheck;
        }

        public void Execute(object parameter)
        {
            VM.UpdateMP();
        }
    }
}