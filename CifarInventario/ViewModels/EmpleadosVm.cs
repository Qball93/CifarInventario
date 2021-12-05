using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using CifarInventario.ViewModels.Classes.Queries;
using CifarInventario.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CifarInventario.ViewModels.Commands;
using CifarInventario.ViewModels.Commands.PersonaCommands;
using CifarInventario.Views.Modals.EmpleadosModals;

namespace CifarInventario.ViewModels
{
    public class EmpleadosVM: INotifyPropertyChanged
    {
        public EmpleadosVM()
        {
            Empleados = new ObservableCollection<Empleado>(PersonaQueries.GetEmpleados());
            nuevoEmpleadoCommand = new NuevoEmpleadoCommand(this);
            editEmpleadoCommand = new EditEmpleadoCommand(this);
        }


        private ObservableCollection<Empleado> _empleados;

        public ObservableCollection<Empleado> Empleados
        {
            get { return _empleados; }
            set
            {
                _empleados = value;
                OnPropertyChanged(nameof(Empleados));

            }
        }

        private Empleado _selectedEmpleado;

        public Empleado SelectedEmpleado
        {
            get { return _selectedEmpleado; }
            set
            {
                _selectedEmpleado = value;
                OnPropertyChanged(nameof(SelectedEmpleado));
            }
        }

        private Empleado _newEmpleado;
        public Empleado NewEmpleado
        {
            get { return _newEmpleado; }
            set
            {
                _newEmpleado = value;
                OnPropertyChanged(nameof(NewEmpleado));
            }
        }
        

        public ICommand openEdit => new DelegateCommand(OpenEditModal);
        public ICommand openNew => new DelegateCommand(OpenNewModal);
        public NuevoEmpleadoCommand nuevoEmpleadoCommand { get; set; }
        public EditEmpleadoCommand editEmpleadoCommand { get; set; }
        public EditEmpleadoModal editModal { get; set; }
        public ICommand limpiarModal => new DelegateCommand(limpiar);

        public void AgregarEmpleado()
        {
            PersonaQueries.CreateEmpleado(NewEmpleado);
            Empleados.Add(NewEmpleado);
            limpiar(1);
        }

        public void EditarEmpleado()
        {
            PersonaQueries.updateEmpleado(SelectedEmpleado);
            
            UpdateCollectionInstance();
            System.Windows.MessageBox.Show("Empleado Actualizado");
            editModal.Close();
            
        }

        public void UpdateCollectionInstance()
        {
            SelectedEmpleado.Id = NewEmpleado.Id;
            SelectedEmpleado.Nombre = NewEmpleado.Nombre;
            SelectedEmpleado.Apellido = NewEmpleado.Apellido;
            SelectedEmpleado.Correo = NewEmpleado.Correo;
        }

        public void OpenEditModal(object parameter)
        {
            NewEmpleado = new Empleado(SelectedEmpleado);
            editModal = new EditEmpleadoModal(this);
            editModal.ShowDialog();
        }

        public void OpenNewModal(object parameter)
        {
            NewEmpleado = new Empleado();
            var temp = new NewEmpleadoModal(this);
            temp.ShowDialog();
        }

        public void limpiar(object parameter)
        {
            NewEmpleado = new Empleado();
        }

        


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
