using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CifarInventario.ViewModels.Commands.PersonaCommands
{
    public class EditProveedorCommand : ICommand
    {
        public ProveedoresVM VM { get; set; }


        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public EditProveedorCommand(ProveedoresVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            //return true;
            return !VM.SelectedProveedor.HasErrors && VM.SelectedProveedor.DireccionCheck && VM.SelectedProveedor.NombreCheck && VM.SelectedProveedor.TelefonoCheck;
        }

        public void Execute(object parameter)
        {
            VM.EditProveedor();
        }
    }
}
