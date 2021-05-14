using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Text;
using CifarInventario.ViewModels.Classes.Queries;
using CifarInventario.Models;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace CifarInventario.ViewModels
{
    public class LoteEntVM: INotifyPropertyChanged
    {
        public LoteEntVM()
        {
            LotesActivos = new ObservableCollection<LoteEntrada>(InventoryQueries.GetLotesEntradaActivos());
        }







        private LoteEntrada _selectedLoteActivo;

        public LoteEntrada SelectedLoteActivo
        {
            get { return _selectedLoteActivo; }
            set
            {
                _selectedLoteActivo = value;
                OnPropertyChanged("SelectedLoteActivo");
            }
        }


        private ObservableCollection<LoteEntrada> _lotesActivos;

        public ObservableCollection<LoteEntrada> LotesActivos
        {
            get { return _lotesActivos; }
            set
            {
                _lotesActivos = value;
                OnPropertyChanged("LotesActivos");

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
