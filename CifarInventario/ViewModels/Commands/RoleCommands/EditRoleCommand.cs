using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CifarInventario.ViewModels.Commands.RoleCommands
{
    public class EditRoleCommand
    {
        public RolesVM VM { get; set; }


        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public EditRoleCommand(RolesVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            
            return !VM.SelectedRole.HasErrors && VM.SelectedRole.NameCheck;
        }

        public void Execute(object parameter)
        {
            VM.agregarRole();
        }
    }
}
