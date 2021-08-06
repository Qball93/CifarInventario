using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using System.Text;
using System.Threading.Tasks;

namespace CifarInventario.ViewModels.Commands.InventoryCommands
{
    public class NewPtCommand : ICommand
    {
        public InventarioPtVM VM { get; set; }


        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public NewPtCommand(InventarioPtVM vm)
        {
            VM = vm;
        }


        public bool CanExecute(object parameter)
        {
            return !VM.NewProduct.HasErrors && VM.NewProduct.idCheck && VM.NewProduct.precioCheck && VM.NewProduct.nombreCheck;
        }

        public void Execute(object parameter)
        {
            VM.CreatePT();
        }
    }
}
