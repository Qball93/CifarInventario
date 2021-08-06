using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using CifarInventario.ViewModels.Classes.Queries;
using CifarInventario.Models;
using System.Collections.ObjectModel;

namespace CifarInventario.ViewModels
{
    public class EmpleadosVM: INotifyPropertyChanged
    {
        public EmpleadosVM()
        {
            Empleados = new ObservableCollection<Empleado>(PersonaQueries.GetEmpleados());
        }


        private ObservableCollection<Empleado> _empleados;

        public ObservableCollection<Empleado> Empleados
        {
            get { return _empleados; }
            set
            {
                _empleados = value;
                OnPropertyChanged("Empleados");

            }
        }

        private EntidadCommercial _selectedEmpleado;

        public EntidadCommercial SelectedEmpleado
        {
            get { return _selectedEmpleado; }
            set
            {
                _selectedEmpleado = value;
                OnPropertyChanged("SelectedEmpleado");
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
