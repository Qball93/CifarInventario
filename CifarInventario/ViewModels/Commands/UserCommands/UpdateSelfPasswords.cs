using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CifarInventario.ViewModels.Commands.UserCommands
{
    public class UpdateSelfPasswords : ICommand
    {
        public RecuperacionVM VM { get; set; }


        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public UpdateSelfPasswords(RecuperacionVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return !VM.HasErrors && VM.PassOneCheck && VM.passTwoCheck;
            // return !VM.NewUser.HasErrors && VM.NewUser.UserCheck;
        }

        public void Execute(object parameter)
        {
            VM.SetNewPregunta();
        }
    }
}
