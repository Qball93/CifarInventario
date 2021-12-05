using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CifarInventario.Models;
using CifarInventario.ViewModels.Classes.Queries;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using CifarInventario.ViewModels.Commands;
using System.Windows.Input;
using CifarInventario.ViewModels.Commands.PersonaCommands;
using CifarInventario.Views.Modals.ClientesModals;

namespace CifarInventario.ViewModels
{
    public class ClientesVM : INotifyPropertyChanged
    {

        public ClientesVM()
        {
            Clientes = new ObservableCollection<EntidadCommercial>(PersonaQueries.GetEntity("clientes"));
            nuevoClientecommand = new NuevoClienteCommand(this);
            editClienteCommand = new EditClienteCommand(this);
        }


        private ObservableCollection<EntidadCommercial> _clientes;

        public ObservableCollection<EntidadCommercial> Clientes
        {
            get { return _clientes; }
            set
            {
                _clientes = value;
                OnPropertyChanged(nameof(Clientes));

            }
        }

        private EntidadCommercial _selectedClient;
        public EntidadCommercial SelectedClient
        {
            get { return _selectedClient; }
            set
            {
                _selectedClient = value;
                OnPropertyChanged(nameof(SelectedClient));
            }
        }

        private EntidadCommercial _newClient;
        public EntidadCommercial NewClient
        {
            get { return _newClient; }
            set
            {
                _newClient = value;
                OnPropertyChanged(nameof(NewClient));
            }
        }

        public ICommand openEdit => new DelegateCommand(openEditModal);
        public ICommand openNew => new DelegateCommand(openNewClienteModal);
        public NuevoClienteCommand nuevoClientecommand { get; set; }
        public EditClienteCommand editClienteCommand { get; set; }
        public EditarClienteModal editModal { get; set; }

        public void openNewClienteModal(object parameter)
        {
            
            var temp = new NuevoClienteModal(this);
            NewClient = new EntidadCommercial();
            temp.ShowDialog();

        }

        public void openEditModal(object parameter)
        {
            NewClient = new EntidadCommercial(SelectedClient);
            editModal = new EditarClienteModal(this);
            editModal.ShowDialog();
        }

        public void agregarCliente()
        {
            NewClient.Id = PersonaQueries.CreateEntidad(NewClient, "clientes");
            Clientes.Add(NewClient);
        }

        public void editarCliente()
        {
            PersonaQueries.updateEntidad(NewClient, "clientes");


            updateCollectionInstance(NewClient);

            editModal.Close();
        }

        public void updateCollectionInstance(EntidadCommercial updatedInstance)
        {

            SelectedClient.Id = updatedInstance.Id;


            SelectedClient.NombreCommercial = updatedInstance.NombreCommercial;
            SelectedClient.NombreContacto = updatedInstance.NombreContacto;
            SelectedClient.Direccion = updatedInstance.Direccion;
            SelectedClient.Telefono = updatedInstance.Telefono;
            SelectedClient.CorreoContacto = updatedInstance.CorreoContacto;
            SelectedClient.Commentario = updatedInstance.Commentario;
            SelectedClient.RTN = updatedInstance.RTN;

        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
