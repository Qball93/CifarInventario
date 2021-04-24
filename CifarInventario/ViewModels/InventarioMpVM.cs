using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CifarInventario.Models;
using System.Text;
using CifarInventario.ViewModels.Classes;
using System.Threading.Tasks;
using System.ComponentModel;
using CifarInventario.ViewModels.Classes.Queries;

namespace CifarInventario.ViewModels
{
    public class InventarioMpVM : INotifyPropertyChanged
    {

        public InventarioMpVM() 
        {
            InventarioMP = new ObservableCollection<MpProduct>(InventoryQueries.GetMP());
        }


        private ObservableCollection<MpProduct> _inventarioMP;

        public ObservableCollection<MpProduct> InventarioMP
        {
            get { return _inventarioMP; }
            set
            {
                _inventarioMP = value;
                OnPropertyChanged("InventarioMP");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
