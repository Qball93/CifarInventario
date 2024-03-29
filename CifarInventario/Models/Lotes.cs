﻿ using CifarInventario.ViewModels.Classes;
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
        private bool _estado;

        

        public LoteEntrada()
        {
            FechaFabricacion = DateTime.Today;
            FechaVencimiento = DateTime.Today;
            FechaEntrada = DateTime.Today;
        }

        public LoteEntrada(LoteEntrada old)
        {
            CodLote = old.CodLote;
            Unidad = old.Unidad;
            CantidadActual = old.CantidadActual;
            CantidadOriginal = old.CantidadOriginal;
            CantidadExacta = old.CantidadExacta;
            CodMP = old.CodMP;
            CertificadoAnalysis = old.CertificadoAnalysis;
            NombreMP = old.NombreMP;
            CodProveedor = old.CodProveedor;
            NombreProveedor = old.NombreProveedor;
            NombreFabricante = old.NombreFabricante;
            Procedencia = old.Procedencia;
            FechaFabricacion = old.FechaFabricacion;
            FechaVencimiento = old.FechaVencimiento;
            FechaEntrada = old.FechaEntrada;
            ConversionUnitaria = old.ConversionUnitaria;
            CodInterno = old.CodInterno;

        }

        public bool CantidadCheck, CodCheck, FabricanteCheck, FechaCheck, ProcedenciaCheck = false;

        public string CodInterno
        {
            get { return _codInterno; }
            set
            {
                _codInterno = value;
                OnPropertyChanged(nameof(CodInterno));
            }
        }
        public double ConversionUnitaria
        {
            get { return _conversionUnitaria; }
            set
            {
                _conversionUnitaria = value;
                OnPropertyChanged(nameof(ConversionUnitaria));
            }
        }
        public DateTime FechaEntrada
        {
            get { return _fechaEntrada; }
            set
            {
                _fechaEntrada = value;
                FechaCheck = true;
                ClearErrors(nameof(FechaEntrada));
                IsEmptyString(value.ToString(), nameof(FechaEntrada));
                OnPropertyChanged(nameof(FechaEntrada));
            }
        }
        public DateTime FechaVencimiento
        {
            get { return _fechaVencimiento; }
            set
            {
                _fechaVencimiento = value;
                OnPropertyChanged(nameof(FechaVencimiento));
            }
        }
        public DateTime FechaFabricacion
        {
            get { return _fechaFabricacion; }
            set
            {
                _fechaFabricacion = value;
                OnPropertyChanged(nameof(FechaFabricacion));
            }
        }
        public string Procedencia
        {
            get { return _procedencia; }
            set
            {
                _procedencia = value;
                ProcedenciaCheck = true;
                ClearErrors(nameof(Procedencia));
                IsEmptyString(value, nameof(Procedencia));
                OnPropertyChanged(nameof(Procedencia));
            }
        }
        public string NombreFabricante
        {
            get { return _nombreFabricante; }
            set {
                _nombreFabricante = value;
                FabricanteCheck = true;
                ClearErrors(nameof(NombreFabricante));
                IsEmptyString(value, nameof(NombreFabricante));
                OnPropertyChanged(nameof(NombreFabricante));
            }
        }
        public string NombreProveedor
        {
            get { return _nombreProveedor; }
            set
            {
                _nombreProveedor = value;
                OnPropertyChanged(nameof(NombreProveedor));
            }
        }
        public string CodLote
        {
            get { return _codLote; }
            set
            {
                _codLote = value;
                CodCheck = true;
                ClearErrors(nameof(CodLote));
                IsEmptyString(value, nameof(CodLote));
                isAlphaNumeric(value, nameof(CodLote));
                OnPropertyChanged(nameof(CodLote));
            }
        }
        public string Unidad
        {
            get { return _unidad; }
            set
            {
                _unidad = value;
                OnPropertyChanged(nameof(Unidad));
            }
        }
        public double CantidadActual
        {
            get { return _cantidadActual; }
            set
            {
                _cantidadActual = value;
                ClearErrors(nameof(CantidadActual));
                IsEmptyString(value.ToString(), nameof(CantidadActual));
                is0Decimal(value.ToString(), nameof(CantidadActual));
                OnPropertyChanged(nameof(CantidadActual));
            }
        }
        public double CantidadOriginal
        {
            get { return _cantidadOriginal; }
            set
            {
                _cantidadOriginal = value;
                CantidadCheck = true;
                ClearErrors(nameof(CantidadOriginal));
                IsEmptyString(value.ToString(), nameof(CantidadOriginal));
                is0Decimal(value.ToString(), nameof(CantidadOriginal));
                OnPropertyChanged(nameof(CantidadOriginal));
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
                OnPropertyChanged(nameof(CertificadoAnalysis));
            }
        }
        public string NombreMP
        {
            get { return _nombreMP; }
            set
            {
                _nombreMP = value;
                OnPropertyChanged(nameof(NombreMP));
            }
        }
        public string CodProveedor
        {
            get { return _codProveedor; }
            set
            {
                _codProveedor = value;
                OnPropertyChanged(nameof(CodProveedor));
            }
        }

        public bool Estado
        {
            get { return _estado; }
            set
            {
                _estado = value;
                OnPropertyChanged(nameof(Estado));
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

        public LoteSalida(LoteSalida old)
        {
            OriginalLote = old.OriginalLote;
            CodLote = old.CodLote;
            CantidadActual = old.CantidadActual;
            Unidad = old.Unidad;
            CodFormula = old.CodFormula;
            NombreFormula = old.NombreFormula;
            CantidadCreacion = old.CantidadCreacion;
            FechaCreacion = old.FechaCreacion;
            FechaVencimiento = old.FechaVencimiento;

        }

        private string _originalLote;
        public string OriginalLote
        {
            get { return _originalLote; }
            set
            {
                _originalLote = value;
                OnPropertyChanged(nameof(OriginalLote));
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
                ClearErrors(nameof(CodLote));
                IsEmptyString(value, nameof(CodLote));
                isAlphaNumeric(value, nameof(CodLote));
                OnPropertyChanged(nameof(CodLote));

            }
        }

        private double _cantidadActual;
        public double CantidadActual
        {
            get { return _cantidadActual; }
            set
            {
                _cantidadActual = value;
                OnPropertyChanged(nameof(CantidadActual));
            }
        }

        private string _unidad;
        public string Unidad
        {
            get { return _unidad; }
            set
            {
                _unidad = value;
                OnPropertyChanged(nameof(Unidad));
            }
        }

        private string _codFormula;
        public string CodFormula
        {
            get { return _codFormula; }
            set
            {
                _codFormula = value;
                OnPropertyChanged(nameof(CodFormula));
            }
        }

        private string _nombreFormula;
        public string NombreFormula
        {
            get { return _nombreFormula; }
            set
            {
                _nombreFormula = value;
                OnPropertyChanged(nameof(NombreFormula));
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
                    ClearErrors(nameof(CantidadCreacion));
                    isDecimal(value.ToString(), nameof(CantidadCreacion));
                    OnPropertyChanged(nameof(CantidadCreacion));
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


        public LoteSalidaDetalle(LoteSalidaDetalle old)
        {
            CodLoteEntrada = old.CodLoteEntrada;
            CodLoteSalida = old.CodLoteSalida;
            Cantidad = old.Cantidad;
            LotesProducto = old.LotesProducto;
            Unidad = old.Unidad;
            NombreMP = old.NombreMP;
            CodMP = old.CodMP;
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

    public class LotePTDetalle : Validators, INotifyPropertyChanged
    {

        

        private string _codigoLotePT;
        public string CodigoLotePT
        {
            get { return _codigoLotePT; }
            set
            {
                _codigoLotePT = value;
                OnPropertyChanged(nameof(CodigoLotePT));
            }
        }


        private string _codigoLoteMP;
        public string CodigoLoteMP
        {
            get { return _codigoLoteMP; }
            set
            {
                _codigoLoteMP = value;
                OnPropertyChanged(nameof(CodigoLoteMP));
            }
        }

        private string _codigoMP;
        public string CodigoMP
        {
            get { return _codigoMP; }
            set
            {
                _codigoMP = value;
                OnPropertyChanged(nameof(CodigoMP));
            }
        }

        private string _nombreEmpaqe;
        public string NombreEmpaque
        {
            get { return _nombreEmpaqe; }
            set
            {
                _nombreEmpaqe = value;
                OnPropertyChanged(nameof(NombreEmpaque));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class LotePT : Validators, INotifyPropertyChanged
    {
        public bool CodigoCheck, CantidadCheck = false;

        private List<LotePTDetalle> _detalles;
        public List<LotePTDetalle> Detalles
        {
            get { return _detalles; }
            set
            {
                _detalles = value;
                OnPropertyChanged(nameof(Detalles));
            }
        }

        private string _codigoLoteSalida;
        public string CodigoLoteSalida
        {
            get { return _codigoLoteSalida; }
            set
            {
                _codigoLoteSalida = value;
                OnPropertyChanged(nameof(CodigoLoteSalida));
            }
        }

        private string _codigoPT;
        public string CodigoPT
        {
            get { return _codigoPT; }
            set
            {
                _codigoPT = value;
                OnPropertyChanged(nameof(CodigoPT));
            }
        }    

        private string _codigoCorrelativo;
        public string CodigoCorrelativo
        {
            get { return _codigoCorrelativo; }
            set
            {
                _codigoCorrelativo = value;
                CodigoCheck = true;
                ClearErrors(nameof(CodigoCorrelativo));
                isAlphaNumeric(value, nameof(CodigoCorrelativo));
                IsEmptyString(value, nameof(CodigoCorrelativo));
                OnPropertyChanged(nameof(CodigoCorrelativo));
            }
        }

        private string _cantidadOriginal;
        public string CantidadOriginal
        {
            get { return _cantidadOriginal; }
            set
            {
                
                _cantidadOriginal = value;
                CantidadCheck = true;
                ClearErrors(nameof(CantidadOriginal));
                IsEmptyString(value.ToString(), nameof(CantidadOriginal));
                isStepNumber(value.ToString(), nameof(CantidadOriginal));
                OnPropertyChanged(nameof(CantidadOriginal));
            }
        }

        private int _existencia;
        public int Existencia
        {
            get { return _existencia; }
            set
            {
                _existencia = value;
                OnPropertyChanged(nameof(Existencia));
            }
        }

        private string _nombrePT;
        public string NombrePT
        {
            get { return _nombrePT; }
            set
            {
                _nombrePT = value;
                OnPropertyChanged(nameof(NombrePT));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


    public class Registro: Validators, INotifyPropertyChanged
    {


        private DateTime _fechaEvento;
        public DateTime FechaEvento
        {
            get { return _fechaEvento; }
            set
            {
                _fechaEvento = value;
                OnPropertyChanged(nameof(FechaEvento));
            }
        }

        private string _accion;
        public string Accion
        {
            get { return _accion; }
            set
            {
                _accion = value;
                OnPropertyChanged(nameof(Accion));
            }
        }

        private string _loteRelevante;
        public string LoteRelevante
        {
            get { return _loteRelevante;  }
            set
            {
                _loteRelevante = value;
                OnPropertyChanged(nameof(LoteRelevante));
            }
        }

        private string _tipoEvento;
        public string TipoEvento
        {
            get { return _tipoEvento; }
            set
            {
                _tipoEvento = value;
                OnPropertyChanged(nameof(TipoEvento));
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


    public class emptyObject : Validators, INotifyPropertyChanged
    {
        public emptyObject()
        {
            EmptyAmount = 0.00;

            
        }
        
        
        public bool AmountCheck, CantidadCheck, WordCheck = false;


        private string _emptyWord;
        public string EmptyWord
        {
            get { return _emptyWord; }
            set
            {
                _emptyWord = value;
                WordCheck = true;
                ClearErrors(nameof(EmptyWord));
                IsEmptyString(value, nameof(EmptyWord));
                OnPropertyChanged(nameof(EmptyWord));
            }
        }


        private int _emptyCantidad;
        public int EmptyCantidad
        {
            get { return _emptyCantidad; }
            set
            {
                _emptyCantidad = value;
                CantidadCheck = true;
                ClearErrors(nameof(EmptyCantidad));
                IsEmptyString(value.ToString(), nameof(EmptyCantidad));
                OnPropertyChanged(nameof(EmptyCantidad));
            }
        }


        private double _emptyAmount;
        public double EmptyAmount
        {
            get { return _emptyAmount; }
            set
            {
                _emptyAmount = value;
                AmountCheck = true;
                ClearErrors(nameof(EmptyAmount));
                IsEmptyString(value.ToString(), nameof(EmptyAmount));
                isDecimal(value.ToString(), nameof(EmptyAmount));
                OnPropertyChanged(nameof(EmptyAmount));
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    
}
