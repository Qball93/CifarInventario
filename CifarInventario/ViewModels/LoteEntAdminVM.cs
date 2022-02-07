using System;
using System.Collections.Generic;
using System.ComponentModel;
using CifarInventario.Models;
using System.Linq;
using CifarInventario.ViewModels.Classes.Queries;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CifarInventario.Views.Modals.LotesEntModals;
using System.Windows.Input;
using CifarInventario.ViewModels.Commands;
using CifarInventario.ViewModels.Commands.LoteEntCommands;
using System.Collections.ObjectModel;

namespace CifarInventario.ViewModels
{
    public class LoteEntAdminVM: INotifyPropertyChanged
    {


        public LoteEntAdminVM()
        {
            Lotes = new ObservableCollection<LoteEntrada>(InventoryQueries.GetAllLotes());
            EnterAmounts = new AdminEnterLoteAmount(this);
            AdminModal = new AdminLoteEntUpdateAmountsModal(this);
        }


        private ObservableCollection<LoteEntrada> _lotes;
        public ObservableCollection<LoteEntrada> Lotes
        {
            get { return _lotes; }
            set
            {
                _lotes = value;
                OnPropertyChanged(nameof(Lotes));
            }
        }

        private LoteEntrada _selectedLote;
        public LoteEntrada SelectedLote
        {
            get { return _selectedLote; }
            set
            {
                _selectedLote = value;
                OnPropertyChanged(nameof(SelectedLote));
            }
        }


        public AdminEnterLoteAmount EnterAmounts { get; set; }
        public AdminLoteEntUpdateAmountsModal AdminModal { get; set; }
        



        public ICommand openAmountModal => new DelegateCommand(OpenAmountModal);
        public ICommand emptyLote => new DelegateCommand(EmptyLote);


        public void EmptyLote(object parameter)
        {
            MessageBoxResult result = MessageBox.Show("Vaciar este lote?", "Vaciar Lote", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                SelectedLote.CantidadActual = 0;
                SelectedLote.CantidadExacta = 0;
                SelectedLote.CantidadOriginal = 0;
                InventoryQueries.emptyLote(SelectedLote.CodInterno);
            }
        }

        public void ReEnterLote()
        {
            if(SelectedLote.CantidadActual > SelectedLote.CantidadOriginal)
            {
                
                MessageBox.Show("Cantidad Actual no puede ser mayor a la cantidad de Entrada");
            }
            else
            {

                //MessageBox.Show(SelectedLote.CodMP);

                double formAmount = (SelectedLote.CantidadActual * SelectedLote.ConversionUnitaria);
                InventoryQueries.reEntryLote(SelectedLote.CodInterno, SelectedLote.CantidadActual, SelectedLote.CantidadOriginal,formAmount);
                ProductQueries.reAddAmount(SelectedLote.CodMP, SelectedLote.CantidadOriginal, SelectedLote.CantidadActual, formAmount);

                MessageBox.Show("Lote MP reingresado");
                AdminModal.Close();

            }
        }

        public void OpenAmountModal(object paramter)
        {
            AdminModal = new AdminLoteEntUpdateAmountsModal(this);

            AdminModal.ShowDialog();


        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

