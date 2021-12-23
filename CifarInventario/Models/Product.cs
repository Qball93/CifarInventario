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
        private string _nombreProducto;
        private string _unidadMetrica;
        private double _entrada;
        private double _salida;
        private double _conversion;
        private double _cantidadExacta;
        private string _unidadMuestra;


        public bool nombreCheck, IdCheck, ConversionCheck = false;

        public MpProduct(MpProduct old)
        {
            Id = old.Id;
            NombreProducto = old.NombreProducto;
            Existencia = old.Existencia;
            UnidadMetrica = old.UnidadMetrica;
            Entrada = old.Entrada;
            Salida = old.Salida;
            Conversion = old.Conversion;
            CantidadExacta = old.CantidadExacta;
            UnidadMuestra = old.UnidadMuestra;
        }

        public MpProduct()
        {
        }

        public double Entrada
        {
            get { return _entrada; }
            set
            {
                _entrada = value;
                OnPropertyChanged(nameof(Entrada));
            }
        }

        public double Salida
        {
            get { return _salida; }
            set
            {
                _salida = value;
                OnPropertyChanged(nameof(Salida));
            }
        }

        public string UnidadMetrica
        {
            get { return _unidadMetrica; }
            set
            {
                _unidadMetrica = value;
                OnPropertyChanged(nameof(UnidadMetrica));
            }
        }

        public string Id
        {
            get { return _id; }
            set
            {
                _id = value;
                IdCheck = true;
                ClearErrors(nameof(Id));
                IsEmptyString(value, nameof(Id));
                isAlphaNumeric(value, nameof(Id));
                OnPropertyChanged(nameof(Id));
            }
        }

        public double Existencia
        {
            get { return _existencia; }
            set
            {
                _existencia = value;
                OnPropertyChanged(nameof(Existencia));
            }
        }

        public string NombreProducto
        {
            get { return _nombreProducto; }
            set
            {
                _nombreProducto = value;
                nombreCheck = true;
                ClearErrors(nameof(NombreProducto));
                IsEmptyString(value, nameof(NombreProducto));
                isAlphaNumeric(value, nameof(NombreProducto));
                OnPropertyChanged(nameof(NombreProducto));
            }
        }

        public double Conversion
        {
            get { return _conversion; }
            set
            {
                _conversion = value;
                ConversionCheck = true;
                ClearErrors(nameof(Conversion));
                isDecimal(value.ToString(),nameof(Conversion));
                OnPropertyChanged(nameof(Conversion));
            }
        }
        
        public double CantidadExacta
        {
            get { return _cantidadExacta; }
            set
            {
                _cantidadExacta = value;
                OnPropertyChanged(nameof(CantidadExacta));
            }
        }

        public string UnidadMuestra
        {
            get { return _unidadMuestra; }
            set
            {
                _unidadMuestra = value;
                OnPropertyChanged(nameof(UnidadMuestra));
            }
        }




        





        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class PtProduct : Validators, INotifyPropertyChanged
    {
        private string _id;
        private string _nombre;
        private int _existencia;
        private int _entrada;
        private int _salida;
        private double _precio;

        public bool idCheck, nombreCheck, precioCheck = false;

        public PtProduct() { }


        public PtProduct(PtProduct copy)
        {
            Id = copy.Id;
            Nombre = copy.Nombre;
            Precio = copy.Precio;
            Existencia = copy.Existencia;
            Entrada = copy.Entrada;
            Salida = copy.Salida;

        }


        public string Id
        {
            get { return _id; }
            set
            {
                _id = value;
                idCheck = true;
                ClearErrors(nameof(Id));
                IsEmptyString(value,nameof(Id));
                isAlphaNumeric(value, nameof(Id));
                OnPropertyChanged(nameof(Id));
            }

        }

        public string Nombre
        {
            get { return _nombre; }
            set
            {
                _nombre = value;
                nombreCheck = true;
                ClearErrors(nameof(Nombre));
                IsEmptyString(value,nameof(Nombre));
                isAlphaNumeric(value, nameof(Nombre));
                OnPropertyChanged(nameof(Nombre));

            }
        }

        public double Precio
        {
            get { return _precio; }
            set
            {
                _precio = value;
                precioCheck = true;
                ClearErrors(nameof(Precio));
                isDecimal(value.ToString(),nameof(Precio));
                OnPropertyChanged(nameof(Precio));

            }
        }

        public int Existencia
        {
            get { return _existencia;  }
            set
            {
                _existencia = value;
                OnPropertyChanged(nameof(Existencia));
            }
        }

        public int Entrada
        {
            get { return _entrada; }
            set
            {
                _entrada = value;
                OnPropertyChanged(nameof(Entrada));
            }
        }

        public int Salida
        {
            get { return _salida; }
            set
            {
                _salida = value;
                OnPropertyChanged(nameof(Salida));
            }
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
                OnPropertyChanged(nameof(UnidadMuestra));
            }
        }




        public string Codigo
        {
            get { return _codigo; }
            set
            {
                _codigo = value;
                OnPropertyChanged(nameof(Codigo));
            }
        }


        public string Nombre
        {
            get { return _nombre; }
            set
            {
                _nombre = value;
                OnPropertyChanged(nameof(Nombre));
            }
        }

        public string Unidad
        {
            get { return _unidad; }
            set { 
                _unidad = value;
                OnPropertyChanged(nameof(Unidad));

            }
        }

        public double ConversionValue
        {
            get { return _conversionValue; }
            set
            {
                _conversionValue = value;
                OnPropertyChanged(nameof(ConversionValue));
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
                ClearErrors(nameof(Quantity));
                IsEmptyString(value, nameof(Quantity));
                isDecimal(value, nameof(Quantity));
                OnPropertyChanged(nameof(Quantity));
            }
        }



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
                ClearErrors(nameof(Existencia));
                isStepNumber(value.ToString(),nameof(Existencia));
                OnPropertyChanged(nameof(Existencia));
                
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

        private int cantidad_original;
        public int Cantidad_Original
        {
            get { return cantidad_original; }
            set
            {
                cantidad_original = value;
                OnPropertyChanged(nameof(Cantidad_Original));
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

        public LotePackageDetalle()
        {

        }

        public LotePackageDetalle(LotePackageDetalle old)
        {
            CodLoteEntrada = old.CodLoteEntrada;
            CodLoteSalida = old.CodLoteSalida;
            CodPT = old.CodPT;
            Cantidad = old.Cantidad;
            NombreEmpaque = old.NombreEmpaque;

        }


        private string _codLoteSalida;
        public string CodLoteSalida
        {
            get { return _codLoteSalida; }
            set
            {
                _codLoteSalida = value;
                OnPropertyChanged(nameof(CodLoteSalida));
            }
        }

        private string _codPT;
        public string CodPT
        {
            get { return _codPT; }
            set
            {
                _codPT = value;
                OnPropertyChanged(nameof(CodPT));
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
                ClearErrors(nameof(Cantidad));
                IsEmptyString(value.ToString(), nameof(Cantidad));
                isStepNumber(value.ToString(),nameof(Cantidad));
                OnPropertyChanged(nameof(Cantidad));
            }
        }

        private string _codLoteEntrada;
        public string CodLoteEntrada
        {
            get { return _codLoteEntrada; }
            set
            {
                _codLoteEntrada = value;
                OnPropertyChanged(nameof(CodLoteEntrada));
            }
        }

        private string _nombreEmpaque;
        public string NombreEmpaque
        {
            get { return _nombreEmpaque; }
            set
            {
                _nombreEmpaque = value;
                OnPropertyChanged(nameof(NombreEmpaque));
            }
        }

        private string _codMp;
        public string CodMp
        {
            get { return _codMp; }
            set
            {
                _codMp = value;
                OnPropertyChanged(nameof(_codMp));
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class ProductoTeminadoParaLista : Validators, INotifyPropertyChanged
    {
        public bool nameCheck = false;


        public ProductoTeminadoParaLista()
        {

        }

        public ProductoTeminadoParaLista(ProductoTeminadoParaLista old)
        {
            CodPT = old.CodPT;
            NombrePT = old.NombrePT;
            Precio = old.Precio;
            Cantidad = old.Cantidad;
        }

        private string _codPT;
        public string CodPT
        {
            get { return _codPT; }
            set
            {
                _codPT = value;
                OnPropertyChanged(nameof(CodPT));
            }
        }

        private string _nombrePT;
        public string NombrePT
        {
            get { return _nombrePT; }
            set
            {
                _nombrePT = value;
                nameCheck = true;
                OnPropertyChanged(nameof(NombrePT));
            }
        }

        private double _precio;
        public double Precio
        {
            get { return _precio; }
            set
            {
                _precio = value;
                OnPropertyChanged(nameof(Precio));
            }
        }

        private int _cantidad;
        public int Cantidad
        {
            get { return _cantidad; }
            set
            {
                _cantidad = value;
                OnPropertyChanged(nameof(Cantidad));
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

        public ProductoTerminado(ProductoTerminado old)
        {
            CodPT = old.CodPT;
            NombrePT = old.NombrePT;
            Existencia = old.Existencia;
            Entrada = old.Entrada;
            Salida = old.Salida;
            Precio = old.Precio;
        }

        public ProductoTerminado() { }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }



    
}
