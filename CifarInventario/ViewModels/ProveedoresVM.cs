using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using CifarInventario.Models;
using System.Text;
using CifarInventario.Views.Modals.Proveedores;
using CifarInventario.ViewModels.Commands.PersonaCommands;
using CifarInventario.ViewModels.Classes.Queries;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CifarInventario.ViewModels.Commands;

namespace CifarInventario.ViewModels
{
    public class ProveedoresVM : INotifyPropertyChanged
    {
        
        public ProveedoresVM()
        {
            Proveedores = new ObservableCollection<EntidadCommercial>(PersonaQueries.GetEntity("proveedor"));
            nuevoProveedorCommand = new NuevoProveedorCommand(this);
            editProveedorCommand = new EditProveedorCommand(this);
            editModal = new EditarProveedor(this);
        }


        private ObservableCollection<EntidadCommercial> _proveedores;

        public ObservableCollection<EntidadCommercial> Proveedores
        {
            get { return _proveedores; }
            set
            {
                _proveedores = value;
                OnPropertyChanged("Proveedores");

            }
        }

        private EntidadCommercial _selectedProveedor;

        public EntidadCommercial SelectedProveedor
        {
            get { return _selectedProveedor; }
            set
            {
                _selectedProveedor = value;
                OnPropertyChanged("SelectedProveedor");
            }
        }


        private EntidadCommercial _nuevoProveedor;
        public EntidadCommercial NuevoProveedor
        {
            get { return _nuevoProveedor; }
            set
            {
                _nuevoProveedor = value;
                OnPropertyChanged("NuevoProveedor");
            }
        }


        public ICommand openEdit => new DelegateCommand(OpenEditModal);
        public ICommand openNew => new DelegateCommand(OpenNewModal);
        public NuevoProveedorCommand nuevoProveedorCommand { get; set; }
        public EditProveedorCommand editProveedorCommand { get; set; }
        public EditarProveedor editModal { get; set; }


        public void OpenEditModal(object parameter)
        {
            editModal.ShowDialog();
        }

        public void OpenNewModal(object parameter)
        {
            var temp = new NuevoProveedor(this);
            temp.ShowDialog();
        }


        public void CreateProveedor()
        {
            PersonaQueries.CreateEntidad(NuevoProveedor,"proveedor");
        }

        public void EditProveedor()
        {

            PersonaQueries.updateEntidad(SelectedProveedor, "proveedor");
            editModal.Close();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
