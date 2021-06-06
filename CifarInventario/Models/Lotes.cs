using CifarInventario.ViewModels.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CifarInventario.Models
{
    public class LoteEntrada :Validators, INotifyPropertyChanged
    {
        private string _codLote;
        private string _unidad;
        private double _cantidadActual;
        private double _cantidadOriginal;
        private double _cantidadExacta;
        private string _codMP;
        private string _certificadoAnalysis;
        private string _nombreMP;
        private string _codProveedor;
        private string _nombreProveedor;
        private string _nombreFabricante;
        private string _procedencia;
        private DateTime _fechaFabricacion;
        private DateTime _fechaVencimiento;
        private DateTime _fechaEntrada;
        private double _conversionUnitaria;
        private string _codInterno;

        public LoteEntrada()
        {
            FechaFabricacion = DateTime.Today;
            FechaVencimiento = DateTime.Today;
            FechaEntrada = DateTime.Today;
        }


        public bool CantidadCheck, CodCheck, FabricanteCheck, FechaCheck, ProcedenciaCheck = false;

        public string CodInterno
        {
            get { return _codInterno; }
            set
            {
                _codInterno = value;
                OnPropertyChanged("CodInterno");
            }
        }

        public double ConversionUnitaria
        {
            get { return _conversionUnitaria; }
            set
            {
                _conversionUnitaria = value;
                OnPropertyChanged("ConversionUnitaria");
            }
        }

        public DateTime FechaEntrada
        {
            get { return _fechaEntrada; }
            set
            {
                _fechaEntrada = value;
                FechaCheck = true;
                ClearErrors("FechaEntrada");
                IsEmptyString(value.ToString(), "FechaEntrada");
                OnPropertyChanged("FechaEntrada");
            }
        }

        public DateTime FechaVencimiento
        {
            get { return _fechaVencimiento; }
            set
            {
                _fechaVencimiento = value;
                OnPropertyChanged("FechaVencimiento");
            }
        }

        public DateTime FechaFabricacion
        {
            get { return _fechaFabricacion; }
            set
            {
                _fechaFabricacion = value;
                OnPropertyChanged("FechaFabricacion");
            }
        }

        public string Procedencia
        {
            get { return _procedencia; }
            set
            {
                _procedencia = value;
                ProcedenciaCheck = true;
                ClearErrors("Procedencia");
                IsEmptyString(value, "Procedencia");
                OnPropertyChanged("Procedencia");
            }
        }

        public string NombreFabricante
        {
            get { return _nombreFabricante; }
            set {
                _nombreFabricante = value;
                FabricanteCheck = true;
                ClearErrors("NombreFabricante");
                IsEmptyString(value, "NombreFabricante");
                OnPropertyChanged("NombreFabricante");
            }
        }

        public string NombreProveedor
        {
            get { return _nombreProveedor; }
            set
            {
                _nombreProveedor = value;
                OnPropertyChanged("NombreProveedor");
            }
        }

        public string CodLote
        {
            get { return _codLote; }
            set
            {
                _codLote = value;
                CodCheck = true;
                ClearErrors("CodLote");
                IsEmptyString(value, "CodLote");
                isAlphaNumeric(value, "CodLote");
                OnPropertyChanged("CodLote");
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

        public double CantidadActual
        {
            get { return _cantidadActual; }
            set
            {
                _cantidadActual = value;
                OnPropertyChanged("CantidadActual");
            }
        }

        public double CantidadOriginal
        {
            get { return _cantidadOriginal; }
            set
            {
                _cantidadOriginal = value;
                CantidadCheck = true;
                ClearErrors("CantidadOriginal");
                IsEmptyString(value.ToString(), "CantidadOriginal");
                isDecimal(value.ToString(), "CantidadOriginal");
                OnPropertyChanged("CantidadOriginal");
            }
        }

        public double CantidadExacta
        {
            get { return _cantidadExacta; }
            set
            {
                _cantidadExacta = value;
                OnPropertyChanged("CantidadExacta");
            }
        }

        public string CodMP
        {
            get { return _codMP; }
            set
            {
                _codMP = value;
                OnPropertyChanged("CodMP");
            }
        }

        public string CertificadoAnalysis
        {
            get { return _certificadoAnalysis; }
            set
            {
                _certificadoAnalysis = value;
                OnPropertyChanged("CertificadoAnalysis");
            }
        }

        public string NombreMP
        {
            get { return _nombreMP; }
            set
            {
                _nombreMP = value;
                OnPropertyChanged("NombreMP");
            }
        }

        public string CodProveedor
        {
            get { return _codProveedor; }
            set
            {
                _codProveedor = value;
                OnPropertyChanged("CodProveedor");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class LoteSalida : Validators, INotifyPropertyChanged
    {

        public bool CodCheck, FechaCreateCheck, FechaVentCheck, CantidadCheck = false;

        public LoteSalida()
        {
            FechaVencimiento = DateTime.Today;
            FechaCreacion = DateTime.Today;
        }

        private string _originalLote;
        public string OriginalLote
        {
            get { return _originalLote; }
            set
            {
                _originalLote = value;
                OnPropertyChanged("OriginalLote");
            }
        }

        private string _codLote;
        public string CodLote
        {
            get { return _codLote; }
            set
            {
                _codLote = value;
                CodCheck = true;
                ClearErrors("CodLote");
                IsEmptyString(value, "CodLote");
                isAlphaNumeric(value, "CodLote");
                OnPropertyChanged("CodLote");

            }
        }

        private double _cantidadActual;
        public double CantidadActual
        {
            get { return _cantidadActual; }
            set
            {
                _cantidadActual = value;
                OnPropertyChanged("CantidadActual");
            }
        }

        private string _unidad;
        public string Unidad
        {
            get { return _unidad; }
            set
            {
                _unidad = value;
                OnPropertyChanged("Unidad");
            }
        }

        private string _codFormula;
        public string CodFormula
        {
            get { return _codFormula; }
            set
            {
                _codFormula = value;
                OnPropertyChanged("CodFormula");
            }
        }

        private string _nombreFormula;
        public string NombreFormula
        {
            get { return _nombreFormula; }
            set
            {
                _nombreFormula = value;
                OnPropertyChanged("NombreFormula");
            }
        }

        private double _CantidadCreacion;
        public double CantidadCreacion
        {
            get { return _CantidadCreacion; }
            set
            {
                if(_CantidadCreacion != value)
                {
                    _CantidadCreacion = value;
                    CantidadCheck = true;
                    ClearErrors("CantidadCreacion");
                    isDecimal(value.ToString(), "CantidadCreacion");
                    OnPropertyChanged("CantidadCreacion");
                }
            }
        }

        private DateTime _fechaCreacion;
        public DateTime FechaCreacion
        {
            get { return _fechaCreacion; }
            set
            {
                _fechaCreacion = value;
                FechaCreateCheck = true;
                ClearErrors("FechaCreacion");
                IsEmptyString(value.ToString(),"FechaCreacion");
                OnPropertyChanged("FechaCreacion");
            }
        }

        private DateTime _fechaVencimiento;
        public DateTime FechaVencimiento
        {
            get { return _fechaVencimiento; }
            set
            {
                _fechaVencimiento = value;
                FechaVentCheck = true;
                ClearErrors("FechaVencimiento");
                IsEmptyString(value.ToString(), "FechaVencimiento");
                OnPropertyChanged("FechaVencimiento");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class LoteSalidaDetalle: INotifyPropertyChanged
    {
        public LoteSalidaDetalle()
        {
            LotesProducto = new ObservableCollection<string>();
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

        private string _codLoteSalida;
        public string CodLoteSalida
        {
            get { return _codLoteSalida; }
            set
            {
                _codLoteSalida = value;
                OnPropertyChanged("OnLoteSalida");
            }
        }

        private double _cantidad;
        public double Cantidad
        {
            get { return _cantidad; }
            set
            {
                _cantidad = value;
                OnPropertyChanged("Cantidad");
            }
        }

        private ObservableCollection<string> _lotesProducto;
        public ObservableCollection<string> LotesProducto
        {
            get { return _lotesProducto; }
            set
            {
                _lotesProducto = value;
                OnPropertyChanged("LotesProducto");
            }
        }

        private string _unidad;
        public string Unidad
        {
            get { return _unidad; }
            set
            {
                _unidad = value;
                OnPropertyChanged("Unidad");
            }
        }

        private string _nombreMP;
        public string NombreMP
        {
            get { return _nombreMP; }
            set
            {
                _nombreMP = value;
                OnPropertyChanged("NombreMP");
            }
        }

        private string _codMP;
        public string CodMP
        {
            get { return _codMP; }
            set
            {
                _codMP = value;
                OnPropertyChanged("CodMP");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
