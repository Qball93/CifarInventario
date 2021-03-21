using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CifarInventario.Models;

namespace CifarInventario.ViewModels.Commands
{
    public class LoginCommand : ICommand
    {

        public LoginVM VM { get; set; }


        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public LoginCommand(LoginVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {

            return !VM.LoginUser.HasErrors && VM.LoginUser.PasswordCheck && VM.LoginUser.UserCheck;
        }

        public void Execute(object parameter)
        {
            VM.MakeLogin();
        }
    }
}
