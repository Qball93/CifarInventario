using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CifarInventario.ViewModels.Commands.PersonaCommands
{
    public class NuevoProveedorCommand: ICommand
    {
        public ProveedoresVM VM { get; set; }


        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public NuevoProveedorCommand(ProveedoresVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            //return true;
            return !VM.NuevoProveedor.HasErrors && VM.NuevoProveedor.DireccionCheck && VM.NuevoProveedor.NombreCheck && VM.NuevoProveedor.TelefonoCheck;
        }

        public void Execute(object parameter)
        {
            VM.CreateProveedor();
        }
    }
}
