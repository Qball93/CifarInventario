using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CifarInventario.Models;
using CifarInventario.Views.Modals.InventarioModals;
using System.Text;
using CifarInventario.ViewModels.Classes;
using System.Threading.Tasks;
using CifarInventario.ViewModels.Commands;
using System.ComponentModel;
using CifarInventario.ViewModels.Classes.Queries;
using System.Windows.Input;
using CifarInventario.ViewModels.Commands.InventoryCommands;

namespace CifarInventario.ViewModels
{
    public class InventarioMpVM : INotifyPropertyChanged
    {

        public InventarioMpVM() 
        {
            InventarioMP = new ObservableCollection<MpProduct>(ProductQueries.GetMP());
            Unidades = new ObservableCollection<string>(ProductQueries.GetUnidades());
            editMp = new EditMpCommand(this);
            createMp = new NewMpCommnand(this);
        }


        private ObservableCollection<MpProduct> _inventarioMP;
        public ObservableCollection<MpProduct> InventarioMP
        {
            get { return _inventarioMP; }
            set
            {
                _inventarioMP = value;
                OnPropertyChanged(nameof(InventarioMP));
            }
        }

        private MpProduct _selectedMP;
        public MpProduct SelectedMP
        {
            get { return _selectedMP; }
            set
            {
                _selectedMP = value;
                OnPropertyChanged(nameof(SelectedMP));
            }
        }

        

        private MpProduct _newProduct;
        public MpProduct NewProduct
        {
            get { return _newProduct; }
            set
            {
                _newProduct = value;
                OnPropertyChanged(nameof(NewProduct));
            }
        }

        private ObservableCollection<string> _unidades;
        public ObservableCollection<string> Unidades
        {
            get { return _unidades; }
            set
            {
                _unidades = value;
                OnPropertyChanged(nameof(Unidades));
            }
        }

        public EditMpModal NewModal { get; set; }
        public string testCode { get; set; }

        public ICommand limpiar => new DelegateCommand(Limpiar);
        public ICommand openUpdateModal => new DelegateCommand(OpenUpdateModal);
        public ICommand openNewModal => new DelegateCommand(OpenNewModal);

        public NewMpCommnand createMp { get; set; }
        public EditMpCommand editMp { get; set; }


        public void OpenUpdateModal(object parameter)
        {
            NewProduct = new MpProduct(SelectedMP);
            /*NewProduct = new MpProduct();
            SelectedMP = new MpProduct();*/

            NewModal = new EditMpModal(this);
            NewModal.ShowDialog();
        }

        public void UpdateMP()
        {
            if (ProductQueries.isRepeatedMpCode(NewProduct.Id) && NewProduct.Id != SelectedMP.Id)
            {
                System.Windows.MessageBox.Show("El codigo de MP ya existe.");
            }
            else
            {

                if(NewProduct.Conversion != SelectedMP.Conversion)
                {
                    InventoryQueries.UpdateLoteConversion(SelectedMP.Id, NewProduct.Conversion);
                }
                ProductQueries.updateMateriaPrimaInfo(NewProduct, SelectedMP.Id);
                
                updateCollectionInstance(NewProduct);
                System.Windows.MessageBox.Show("Informacion de MP actualizada.");
                NewModal.Close();
            }


        }

        public void updateCollectionInstance(MpProduct updatedInstance)
        {
            SelectedMP.Id = updatedInstance.Id;
            SelectedMP.NombreProducto = updatedInstance.NombreProducto;
            SelectedMP.Conversion = updatedInstance.Conversion;
            SelectedMP.UnidadMetrica = updatedInstance.UnidadMetrica;
            SelectedMP.UnidadMuestra = updatedInstance.UnidadMuestra;

        }

        public void CreateNewMp()
        {


            if (ProductQueries.isRepeatedMpCode(NewProduct.Id))
            {
                System.Windows.MessageBox.Show("El codigo de MP ya existe.");
            }
            else
            {
                ProductQueries.CreateMateriaPrima(NewProduct);
                NewProduct.Existencia = NewProduct.Entrada =  NewProduct.Salida = 0;
                InventarioMP.Add(NewProduct);
                Limpiar("");
                System.Windows.MessageBox.Show("Nueva MP agregada al inventario.");
            }




        }

        public void Limpiar(object parameter)
        {
            NewProduct = new MpProduct();
        }


        public void OpenNewModal(object parameter)
        {
            var test = new NewMpModal(this);
            NewProduct = new MpProduct();

            test.ShowDialog();
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
