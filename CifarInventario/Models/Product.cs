using CifarInventario.ViewModels.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CifarInventario.Models
{
    public class MpProduct : Validators, INotifyPropertyChanged
    {
        private string _id;
        private int _existencia;
        private float _precio;
        private string _nombreProducto;
        private bool _esRentable;
        private UnidadMetrica _unidad;
        private int _entrada;
        private int _salida;


        public MpProduct()
        {
            Unidad = new UnidadMetrica();
        }

        public int Entrada
        {
            get { return _entrada; }
            set
            {
                _entrada = value;
                OnPropertyChanged("Entrada");
            }
        }

        public int Salida
        {
            get { return _salida; }
            set
            {
                _salida = value;
                OnPropertyChanged("Salida");
            }
        }


        public UnidadMetrica Unidad
        {
            get { return _unidad; }
            set
            {
                _unidad = value;
                OnPropertyChanged("Unidad");
            }
        }

        public string Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }

        public int Existencia
        {
            get { return _existencia; }
            set
            {
                _existencia = value;
                OnPropertyChanged("Existencia");
            }
        }

        public float Precio
        {
            get { return _precio; }
            set { 
                _precio = value;
                OnPropertyChanged("Precio");
            }
        }

        public string NombreProducto
        {
            get { return _nombreProducto; }
            set
            {
                _nombreProducto = value;
                OnPropertyChanged("NombreProducto");
            }
        }

        public bool EsRentable
        {
            get { return _esRentable; }
            set
            {
                _esRentable = value;
                OnPropertyChanged("EsRentable");
            }
        }




        public override string ToString()
        {
            return "dsaddsaasd";
        }





        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class UnidadMetrica: Validators, INotifyPropertyChanged
    {

        private int _id;
        private string _nombreUnidad;

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }

        public string NombreUnidad
        {
            get { return _nombreUnidad; }
            set
            {
                _nombreUnidad = value;
                OnPropertyChanged("NombreUnidad");
            }
        }
        



        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class formulaProduct:Validators, INotifyPropertyChanged
    {
        public string codigo { get; set; }
        public string nombre { get; set; }

        private string _quantity;
        public string unidad { get; set; }

        public bool QuantityCheck = false;

        public string Quantity
        {
            get { return _quantity; }
            set
            {
                QuantityCheck = true;
                _quantity = value;
                ClearErrors("Quantity");
                IsEmptyString(value, "Quantity");
                isDecimal(value, "Quantity");
                OnPropertyChanged("Quantity");
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }


    
}
