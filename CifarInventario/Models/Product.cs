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
        private double _existencia;
        private double _precio;
        private string _nombreProducto;
        private bool _esRentable;
        private string _unidad;
        private double _entrada;
        private double _salida;


        public MpProduct()
        {
        }

        public double Entrada
        {
            get { return _entrada; }
            set
            {
                _entrada = value;
                OnPropertyChanged("Entrada");
            }
        }

        public double Salida
        {
            get { return _salida; }
            set
            {
                _salida = value;
                OnPropertyChanged("Salida");
            }
        }


        public string Unidad
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

        public double Existencia
        {
            get { return _existencia; }
            set
            {
                _existencia = value;
                OnPropertyChanged("Existencia");
            }
        }

        public double Precio
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

        private string _codigo;
        private string _nombre;
        private string _unidad;
        private double _conversionValue;
        private string _quantity;
        private string _unidadMuestra;

        public string UnidadMuestra
        {
            get { return _unidadMuestra; }
            set
            {
                _unidadMuestra = value;
                OnPropertyChanged("UnidadMuestra");
            }
        }




        public string Codigo
        {
            get { return _codigo; }
            set
            {
                _codigo = value;
                OnPropertyChanged("Codigo");
            }
        }


        public string Nombre
        {
            get { return _nombre; }
            set
            {
                _nombre = value;
                OnPropertyChanged("Nombre");
            }
        }

        public string Unidad
        {
            get { return _unidad; }
            set { 
                _unidad = value;
                OnPropertyChanged("Unidad");

            }
        }

        public double ConversionValue
        {
            get { return _conversionValue; }
            set
            {
                _conversionValue = value;
                OnPropertyChanged("ConversionValue");
            }
        }

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

    public class MateriaPrima: Validators, INotifyPropertyChanged
    {





        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    /*public class EmpaqueProduct:Validators, INotifyPropertyChanged
    {
        private 



        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }*/

    public class LotePackage: Validators, INotifyPropertyChanged
    {


        public bool existenciaCheck = false;

        private string _codPT;
        public string CodPT
        {
            get { return _codPT; }
            set
            {
                _codPT = value;
                OnPropertyChanged("CodPT");
            }
        }

        private string _nombrePT;
        public string NombrePT
        {
            get { return _nombrePT; }
            set
            {
                _nombrePT = value;
                OnPropertyChanged("NombrePT");
            }
        }

        private string _idLote;
        public string IdLote
        {
            get { return _idLote; }
            set
            {
                _idLote = value;
                OnPropertyChanged("IdLote");
            }
        }

        private int _existencia;
        public int Existencia
        {
            get { return _existencia; }
            set
            {
                _existencia = value;
                existenciaCheck = true;
                ClearErrors("Existencia");
                isStepNumber(value.ToString(),"Existencia");
                OnPropertyChanged("Existencia");
                
            }
        }

        private double _precio;
        public double Precio
        {
            get { return _precio; }
            set
            {
                _precio = value;
                OnPropertyChanged("Precio");
            }
        }

        private DateTime _fechaVencimiento;
        public DateTime FechaVencimiento
        {
            get { return _fechaVencimiento; }
            set
            {
                _fechaVencimiento = value;
                OnPropertyChanged("FechaVencimiento");
            }
        }

        private List<LotePackageDetalle> _detalles;
        public List<LotePackageDetalle> Detalles
        {
            get { return _detalles; }
            set
            {
                _detalles = value;
                OnPropertyChanged("Detalles");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class LotePackageDetalle: Validators, INotifyPropertyChanged
    {


        public bool cantidadCheck = false;



        private string _codLoteSalida;
        public string CodLoteSalida
        {
            get { return _codLoteSalida; }
            set
            {
                _codLoteSalida = value;
                OnPropertyChanged("CodLoteSalida");
            }
        }

        private string _codPT;
        public string CodPT
        {
            get { return _codPT; }
            set
            {
                _codPT = value;
                OnPropertyChanged("CodPT");
            }
        }

        private int _cantidad;
        public int Cantidad
        {
            get { return _cantidad; }
            set
            {
                cantidadCheck = true;
                _cantidad = value;
                ClearErrors("Cantidad");
                IsEmptyString(value.ToString(), "Cantidad");
                isStepNumber(value.ToString(),"Cantidad");
                OnPropertyChanged("Cantidad");
            }
        }

        private string _codLoteEntrada;
        public string CodLoteEntrada
        {
            get { return _codLoteEntrada; }
            set
            {
                _codLoteEntrada = value;
                OnPropertyChanged("CodLoteEntrada");
            }
        }

        private string _nombreEmpaque;
        public string NombreEmpaque
        {
            get { return _nombreEmpaque; }
            set
            {
                _nombreEmpaque = value;
                OnPropertyChanged("NombreEmpaque");
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class ProductoTeminadoParaLista: Validators, INotifyPropertyChanged
    {
        private string _codPT;
        public string CodPT
        {
            get { return _codPT; }
            set
            {
                _codPT = value;
                OnPropertyChanged("CodPT");
            }
        }

        private string _nombrePT;
        public string NombrePT
        {
            get { return _nombrePT; }
            set
            {
                _nombrePT = value;
                OnPropertyChanged("NombrePT");
            }
        }

        private double _precio;
        public double Precio
        {
            get { return _precio; }
            set
            {
                _precio = value;
                OnPropertyChanged("Precio");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


    public class ProductoTerminado
    {
        private string _codPT;
        public string CodPT
        {
            get { return _codPT; }
            set
            {
                _codPT = value;
                OnPropertyChanged("CodPT");
            }
        }

        private string _nombrePT;
        public string NombrePT
        {
            get { return _nombrePT; }
            set
            {
                _nombrePT = value;
                OnPropertyChanged("NombrePT");
            }
        }

        private int _existencia;
        public int Existencia
        {
            get { return _existencia; }
            set
            {
                _existencia = value;
                OnPropertyChanged("Existencia");
            }
        }

        private int _entrada;
        public int Entrada
        {
            get { return _entrada; }
            set
            {
                _entrada = value;
                OnPropertyChanged("Entrada");
            }
        }

        private int _salida;
        public int Salida
        {
            get { return _salida; }
            set
            {
                _salida = value;
                OnPropertyChanged("Saida");
            }
        }

        private double _precio;
        public double Precio
        {
            get { return _precio; }
            set
            {
                _precio = value;
                OnPropertyChanged("Precio");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }



    
}
