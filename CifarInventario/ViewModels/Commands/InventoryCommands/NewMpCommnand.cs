using System;
using System.Collections.Generic;
using System.Windows.Input;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CifarInventario.ViewModels.Commands.InventoryCommands
{
    public class NewMpCommnand : ICommand
    {
        public InventarioMpVM VM { get; set; }


        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public NewMpCommnand(InventarioMpVM vm)
        {
            VM = vm;
        }


        public bool CanExecute(object parameter)
        {
            //return true;
            return !VM.NewProduct.HasErrors && VM.NewProduct.ConversionCheck && VM.NewProduct.nombreCheck && VM.NewProduct.IdCheck;
        }

        public void Execute(object parameter)
        {
            VM.CreateNewMp();
        }
    }
}
