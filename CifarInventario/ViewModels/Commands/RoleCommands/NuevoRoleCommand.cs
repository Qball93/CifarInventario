using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CifarInventario.ViewModels.Commands.RoleCommands
{
    public class NuevoRoleCommand: ICommand
    {
        public RolesVM VM { get; set; }


        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public NuevoRoleCommand(RolesVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return !VM.NewRole.HasErrors && VM.NewRole.NameCheck;
        }

        public void Execute(object parameter)
        {
            VM.agregarRole();
        }
    }
}
