using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CifarInventario.ViewModels;
using System.Windows.Input;
using System.Threading.Tasks;

namespace CifarInventario.ViewModels.Commands.UserCommands
{
    public class NewUserCommand: ICommand
    {
        public UserPageVM VM { get; set; }


        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public NewUserCommand(UserPageVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            //return true;
            return !VM.NewUser.HasErrors && VM.NewUser.UserCheck && VM.NewUser.PasswordCheck && (VM.SelectedRole != null);
        }

        public void Execute(object parameter)
        {
            VM.CreateUser();
        }
    }
}
