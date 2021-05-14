using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CifarInventario.Models
{
    public class LoteEntrada : INotifyPropertyChanged
    {
        private string _codLote;
        private string _unidad;
        private long _cantidadActual;
        private long _cantidadOriginal;
        private long _cantidadExacta;
        private string _codMP;
        private string _certificadoAnalysis;
        private string _nombreMP;
        private string _codProveedor;
        private string _nombreProveedor;
        private string _nombreFabricante;
        private string _procedencia;
        private string _fechaFabricacion;
        private string _fechaVencimiento;
        private string _fechaEntrada;


        public string FechaEntrada
        {
            get { return _fechaEntrada; }
            set
            {
                _fechaEntrada = value;
                OnPropertyChanged("FechaEntrada");
            }
        }

        public string FechaVencimiento
        {
            get { return _fechaVencimiento; }
            set
            {
                _fechaVencimiento = value;
                OnPropertyChanged("FechaVencimiento");
            }
        }

        public string FechaFabricacion
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
                OnPropertyChanged("Procedencia");
            }
        }

        public string NombreFabricante
        {
            get { return _nombreFabricante; }
            set {
                _nombreFabricante = value;
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

        public long CantidadActual
        {
            get { return _cantidadActual; }
            set
            {
                _cantidadActual = value;
                OnPropertyChanged("CantidadActual");
            }
        }

        public long CantidadOriginal
        {
            get { return _cantidadOriginal; }
            set
            {
                _cantidadOriginal = value;
                OnPropertyChanged("CantidadOriginal");
            }
        }

        public long CantidadExacta
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
}
