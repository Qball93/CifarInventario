using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CifarInventario.ViewModels.Commands.UserCommands
{
    public class UpdateUserCommand : ICommand
    {
        public UserPageVM VM { get; set; }


        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public UpdateUserCommand(UserPageVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            //return true;
            return !VM.NewUser.HasErrors && VM.NewUser.UserCheck;
        }

        public void Execute(object parameter)
        {
            VM.UpdateUser();
        }
    }
}
