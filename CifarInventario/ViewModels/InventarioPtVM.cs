using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CifarInventario.Models;
using CifarInventario.Views.Modals.InventarioModals;
using System.Text;
using System.Threading.Tasks;
using CifarInventario.ViewModels.Commands;
using System.ComponentModel;
using CifarInventario.ViewModels.Classes.Queries;
using System.Windows.Input;
using CifarInventario.ViewModels.Commands.InventoryCommands;

namespace CifarInventario.ViewModels
{
    public class InventarioPtVM : INotifyPropertyChanged
    {
        public InventarioPtVM()
        {
            InventarioPt = new ObservableCollection<PtProduct>(ProductQueries.getPTInventario());
            editPt = new EditPtCommand(this);
            createPt = new NewPtCommand(this);
        }

        private ObservableCollection<PtProduct> _inventarioPt;
        public ObservableCollection<PtProduct> InventarioPt
        {
            get { return _inventarioPt; }
            set
            {
                _inventarioPt = value;
                OnPropertyChanged(nameof(InventarioPt));
            }
        }

        private PtProduct _selectedProduct;
        public PtProduct SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                _selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));
            }
        }

        private PtProduct _newProduct;
        public PtProduct NewProduct
        {
            get { return _newProduct; }
            set
            {
                _newProduct = value;
                OnPropertyChanged(nameof(NewProduct));
            }
        }

        public EditPtModal NewModal;



        public ICommand openEditModal => new DelegateCommand(OpenEditModal);
        public ICommand openNewModal => new DelegateCommand(OpenCreateModal);
        public ICommand limpiar => new DelegateCommand(Limpiar);

        public EditPtCommand editPt { get; set; }
        public NewPtCommand createPt { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public void updateCollectionInstance(PtProduct newEntity)
        {
            SelectedProduct.Id = NewProduct.Id;
            SelectedProduct.Nombre = NewProduct.Nombre;
            SelectedProduct.Precio = NewProduct.Precio;
        }

        public void Limpiar(object parameter)
        {
            NewProduct = new PtProduct();
        }

        public void OpenEditModal(object parameter)
        {
            NewProduct = new PtProduct(SelectedProduct);
            /*NewProduct = new MpProduct();
            SelectedMP = new MpProduct();*/

            NewModal = new EditPtModal(this);
            NewModal.ShowDialog();
        }

        public void OpenCreateModal(object parameter)
        {
            var test = new NewPtModal(this);
            NewProduct = new PtProduct();
            test.ShowDialog();
        }




        public void CreatePT()
        {
            if (ProductQueries.isRepeatedPtCode(NewProduct.Id))
            {
                System.Windows.MessageBox.Show("Este Codigo de PT ya existe.");
            }
            else
            {
                ProductQueries.CreateInventarioProductoTerminado(NewProduct);
                NewProduct.Existencia = 0;
                NewProduct.Entrada = 0;
                NewProduct.Salida = 0;
                System.Windows.MessageBox.Show("Producto creado en el inventario.");
                Limpiar();
                InventarioPt.Add(NewProduct);
            }




        }


        public void Limpiar()
        {
            NewProduct = new PtProduct();
        }

        public void EditPT()
        {
            if (ProductQueries.isRepeatedPtCode(NewProduct.Id))
            {
                System.Windows.MessageBox.Show("Este Codigo de PT ya existe.");
            }
            else
            {
                System.Windows.MessageBox.Show(NewProduct.Id  + NewProduct.Nombre + NewProduct.Precio);
                ProductQueries.updateInventarioProductoTerminadoInfo(NewProduct, SelectedProduct.Id);
                System.Windows.MessageBox.Show("Informacion de Producto Actualizada.");
                updateCollectionInstance(NewProduct);
                NewModal.Close();
            }
        }

    }
}
