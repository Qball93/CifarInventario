using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using CifarInventario.Models;
using System.Text;
using CifarInventario.ViewModels.Classes.Queries;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace CifarInventario.ViewModels
{
    class ProveedoresVM : INotifyPropertyChanged
    {
        
        public ProveedoresVM()
        {
            Proveedores = new ObservableCollection<EntidadCommercial>(PersonaQueries.GetEntity("proveedor"));
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



        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
