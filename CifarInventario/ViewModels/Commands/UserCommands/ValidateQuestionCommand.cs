using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CifarInventario.ViewModels.Commands.UserCommands
{
    public class ValidateQuestionCommand : ICommand
    {
        public RecuperacionVM VM { get; set; }


        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public ValidateQuestionCommand(RecuperacionVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return VM.NewPregunta.respuestaCheck && !VM.NewPregunta.HasErrors;
            // return !VM.NewUser.HasErrors && VM.NewUser.UserCheck;
        }

        public void Execute(object parameter)
        {
            VM.ValidarPregunta();
        }
    }
}
