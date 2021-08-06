﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CifarInventario.ViewModels.Commands.FacturaCommands
{
    public class CreateFacturaCommand : ICommand
    {
        public FacturasVM VM { get; set; }


        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public CreateFacturaCommand(FacturasVM vm)
        {
            VM = vm;
        }


        public bool CanExecute(object parameter)
        {
            //return true;
            return VM.NewFactura.HasErrors && VM.NewFactura.IdCheck;
        }

        public void Execute(object parameter)
        {
            VM.CreateFactura();
        }
    }
}
