using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CifarInventario.ViewModels.Commands.UserCommands
{
    public class UpdatePreguntasCommand : ICommand
    {
        public PreguntasVM VM { get; set; }


        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public UpdatePreguntasCommand(PreguntasVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            return !VM.RecoveryQuestion.HasErrors && VM.RecoveryQuestion.preguntaCheck && VM.RecoveryQuestion.respuestaCheck;
            //return false;
        }

        public void Execute(object parameter)
        {
            VM.ActualizarPregunta();
        }
    }
}
