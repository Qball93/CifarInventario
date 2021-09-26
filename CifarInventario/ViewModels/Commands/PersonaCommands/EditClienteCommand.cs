using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CifarInventario.ViewModels.Commands.PersonaCommands
{
    public class EditClienteCommand : ICommand
    {
        public ClientesVM VM { get; set; }


        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public EditClienteCommand(ClientesVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            //return true;
            return !VM.NewClient.HasErrors && VM.NewClient.DireccionCheck && VM.NewClient.NombreCheck && VM.NewClient.TelefonoCheck;
        }

        public void Execute(object parameter)
        {
            VM.editarCliente();
        }
    }
}
