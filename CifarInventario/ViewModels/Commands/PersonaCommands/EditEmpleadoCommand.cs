using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CifarInventario.ViewModels.Commands.PersonaCommands
{
    public class EditEmpleadoCommand : ICommand
    {
        public EmpleadosVM VM { get; set; }


        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public EditEmpleadoCommand(EmpleadosVM vm)
        {
            VM = vm;
        }

        public bool CanExecute(object parameter)
        {
            //return true;
            return !VM.NewEmpleado.HasErrors && VM.NewEmpleado.nombreCheck && VM.NewEmpleado.apellidoCheck && VM.NewEmpleado.telefonoCheck && VM.NewEmpleado.correoCheck;
        }

        public void Execute(object parameter)
        {
            VM.EditarEmpleado();
        }
    }
}
