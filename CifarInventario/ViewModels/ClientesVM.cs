using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CifarInventario.Models;
using CifarInventario.ViewModels.Classes.Queries;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace CifarInventario.ViewModels
{
    class ClientesVM : INotifyPropertyChanged
    {

        public ClientesVM()
        {
            Clientes = new ObservableCollection<EntidadCommercial>(PersonaQueries.GetEntity("clientes"));
        }


        private ObservableCollection<EntidadCommercial> _clientes;

        public ObservableCollection<EntidadCommercial> Clientes
        {
            get { return _clientes; }
            set
            {
                _clientes = value;
                OnPropertyChanged("Clientes");

            }
        }

        private EntidadCommercial _selectedClient;

        public EntidadCommercial SelectedClient
        {
            get { return _selectedClient; }
            set
            {
                _selectedClient = value;
                OnPropertyChanged("SelectedClient");
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
