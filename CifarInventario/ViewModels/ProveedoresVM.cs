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
            //editModal = new EditarProveedor(this);
            Proveedores = new ObservableCollection<EntidadCommercial>(PersonaQueries.GetEntity("proveedor"));
            nuevoProveedorCommand = new NuevoProveedorCommand(this);
            editProveedorCommand = new EditProveedorCommand(this);
        }


        private ObservableCollection<EntidadCommercial> _proveedores;

        public ObservableCollection<EntidadCommercial> Proveedores
        {
            get { return _proveedores; }
            set
            {
                _proveedores = value;
                OnPropertyChanged(nameof(Proveedores));

            }
        }
        
        private EntidadCommercial _selectedProveedor;

        public EntidadCommercial SelectedProveedor
        {
            get { return _selectedProveedor; }
            set
            {
                _selectedProveedor = value;
                OnPropertyChanged(nameof(SelectedProveedor));
            }
        }
        

        private EntidadCommercial _nuevoProveedor;
        public EntidadCommercial NuevoProveedor
        {
            get { return _nuevoProveedor; }
            set
            {
                _nuevoProveedor = value;
                OnPropertyChanged(nameof(NuevoProveedor));
            }
        }
      

        public ICommand openEdit => new DelegateCommand(OpenEditModal);
        public ICommand openNew => new DelegateCommand(OpenNewModal);
        public ICommand limpiar => new DelegateCommand(Limpiar);
        public NuevoProveedorCommand nuevoProveedorCommand { get; set; }
        public EditProveedorCommand editProveedorCommand { get; set; }
        public EditarProveedor editModal { get; set; }


        public void Limpiar(object parameter)
        {
            NuevoProveedor = new EntidadCommercial();
        }


        public void OpenEditModal(object parameter)
        {
            editModal = new EditarProveedor(this);
            NuevoProveedor = new EntidadCommercial(SelectedProveedor);
            editModal.ShowDialog();
        }

        public void OpenNewModal(object parameter)
        {
            NuevoProveedor = new EntidadCommercial(); 
            var temp = new NuevoProveedorModal(this);
            temp.ShowDialog();
        }


        public void CreateProveedor()
        {
            NuevoProveedor.Id = PersonaQueries.CreateEntidad(NuevoProveedor,"proveedor");
            Proveedores.Add(NuevoProveedor);
        }

        public void EditProveedor()
        {

            PersonaQueries.updateEntidad(NuevoProveedor, "proveedor");
            updateInstanceCollection(NuevoProveedor);
            editModal.Close();
        }

        public void updateInstanceCollection(EntidadCommercial updatedInstance)
        {
            SelectedProveedor.Id = updatedInstance.Id;
            SelectedProveedor.NombreCommercial = updatedInstance.NombreCommercial;
            SelectedProveedor.NombreContacto = updatedInstance.NombreContacto;
            SelectedProveedor.Direccion = updatedInstance.Direccion;
            SelectedProveedor.Telefono = updatedInstance.Telefono;
            SelectedProveedor.CorreoContacto = updatedInstance.CorreoContacto;
            SelectedProveedor.Commentario = updatedInstance.Commentario;
            SelectedProveedor.RTN = updatedInstance.RTN;
        }

        

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
