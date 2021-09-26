using CifarInventario.ViewModels.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CifarInventario.Models
{

    public class Factura:Validators, INotifyPropertyChanged
    {

        public Factura()
        {
            Empleado = new IdName();
            Cliente = new IdName();
            Emission = DateTime.Today;
            Imp = 0.00;
            Sub = 0.00;
            Total = 0.00;
            Descuento = 0.00;
            
        }

        public Factura(Factura old)
        {
            IdFactura = old.IdFactura;
            Empleado = old.Empleado;
            Cliente = old.Cliente;
            Total = old.Total;
            Imp = old.Imp;
            Sub = old.Sub;
            Emission = old.Emission;
            EsAbonado = old.EsAbonado;
            Pendiente = old.Pendiente;
            Direccion = old.Direccion;
            RTN = old.RTN;
            Descuento = old.Descuento;

        }

        public bool IdCheck = false;


        private string _idFactura;
        public string IdFactura
        {
            get { return _idFactura; }
            set
            {
                _idFactura = value;
                IdCheck = true;
                ClearErrors(nameof(IdFactura));
                IsEmptyString(value, nameof(IdFactura));
                isAlphaNumeric(value, nameof(IdFactura));
                OnPropertyChanged(nameof(IdFactura));
            }
        }

        private IdName _empleado;
        public IdName Empleado
        {
            get { return _empleado; }
            set
            {
                _empleado = value;
                OnPropertyChanged(nameof(Empleado));
            }
        }

        private IdName _cliente;
        public IdName Cliente
        {
            get { return _cliente; }
            set
            {
                _cliente = value;
                OnPropertyChanged(nameof(Cliente));
            }
        }

        private double _total;
        public double Total
        {
            get { return _total; }
            set
            {
                _total = value;
                OnPropertyChanged(nameof(Total));
            }
        }

        private double _imp;
        public double Imp
        {
            get { return _imp;}
            set {
                _imp = value;
                OnPropertyChanged(nameof(Imp));
            }
        }

        private double _sub;
        public double Sub
        {
            get { return _sub; }
            set
            {
                _sub = value;
                OnPropertyChanged(nameof(Sub));
            }
        }

        private DateTime _emission;
        public DateTime Emission
        {
            get { return _emission; }
            set
            {
                _emission = value;
                OnPropertyChanged(nameof(Emission));
            }
        }

        private bool _esAbonado;
        public bool EsAbonado
        {
            get { return _esAbonado; }
            set
            {
                _esAbonado = value;
                OnPropertyChanged(nameof(EsAbonado));
            }
        
        }

        private double _pendiente;
        public double Pendiente
        {
            get { return _pendiente; }
            set
            {
                _pendiente = value;
                OnPropertyChanged(nameof(Pendiente));
            }
        }

        private string _direccion;
        public string Direccion
        {
            get { return _direccion; }
            set
            {
                _direccion = value;
                OnPropertyChanged(nameof(Direccion));
            }
        }

        private string _RTN;
        public string RTN
        {
            get { return _RTN; }
            set
            {
                _RTN = value;
                OnPropertyChanged(nameof(RTN));
            }
        }

        private double _descuento;
        public double Descuento
        {
            get { return _descuento; }
            set
            {
                _descuento = value;
                ClearErrors(nameof(Descuento));
                IsEmptyString(value.ToString(), nameof(Descuento));
                is0Decimal(value.ToString(), nameof(Descuento));
                OnPropertyChanged(nameof(Descuento));
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class ExtendedFactura : Validators, INotifyPropertyChanged
    {
        public ExtendedFactura()
        {

        }

        public ExtendedFactura(ExtendedFactura old)
        {
            IdFactura = old.IdFactura;
            Empleado = old.Empleado;
            Cliente = old.Cliente;
            Total = old.Total;
            Imp = old.Imp;
            Sub = old.Sub;
            Emission = old.Emission;
            EsAbonado = old.EsAbonado;
            Pendiente = old.Pendiente;
            NombreCommercial = old.NombreCommercial;
        }


        private int _idFactura;
        public int IdFactura
        {
            get { return _idFactura; }
            set
            {
                _idFactura = value;
                OnPropertyChanged("IdFactura");
            }
        }

        private (int id, string EmpleadoName) _empleado;
        public (int id, string EmpleadoName) Empleado
        {
            get { return _empleado; }
            set
            {
                _empleado = value;
                OnPropertyChanged("Empleado");
            }
        }

        private (int id, string nombre) _cliente;
        public (int id, string nombre) Cliente
        {
            get { return _cliente; }
            set
            {
                _cliente = value;
                OnPropertyChanged("Cliente");
            }
        }

        private double _total;
        public double Total
        {
            get { return _total; }
            set
            {
                _total = value;
                OnPropertyChanged("Total");
            }
        }

        private double _imp;
        public double Imp
        {
            get { return _imp; }
            set
            {
                _imp = value;
                OnPropertyChanged("Imp");
            }
        }

        private double _sub;
        public double Sub
        {
            get { return _sub; }
            set
            {
                _sub = value;
                OnPropertyChanged("Sub");
            }
        }

        private DateTime _emission;
        public DateTime Emission
        {
            get { return _emission; }
            set
            {
                _emission = value;
                OnPropertyChanged("Emission");
            }
        }

        private bool _esAbonado;
        public bool EsAbonado
        {
            get { return _esAbonado; }
            set
            {
                _esAbonado = value;
                OnPropertyChanged("EsAbonado");
            }

        }

        private double _pendiente;
        public double Pendiente
        {
            get { return _pendiente; }
            set
            {
                _pendiente = value;
                OnPropertyChanged("Pendiente");
            }
        }

        private string _nombreCommercial;
        public string NombreCommercial
        {
            get { return _nombreCommercial; }
            set
            {
                _nombreCommercial = value;
                OnPropertyChanged("NombreCommercial");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class DetalleFactura : Validators, INotifyPropertyChanged
    {
        public DetalleFactura()
        {
            Producto = new IdName();
        }

        public DetalleFactura(DetalleFactura old)
        {
            LoteCod = old.LoteCod;
            IdFactura = old.IdFactura;
            Producto = old.Producto;
            Precio = old.Precio;
            Total = old.Total;
            Cantidad = old.Cantidad;
        }

        public bool cantidadCheck = false;
        public bool loteCheck = false;
        public bool idCheck = false;



        private string _loteCod;
        public string LoteCod
        {
            get { return _loteCod; }
            set
            {
                loteCheck = true;
                _loteCod = value;
                OnPropertyChanged("LoteCod");
            }
        }

        private string _idFactura;
        public string IdFactura
        {
            get { return _idFactura; }
            set
            {
                _idFactura = value;
                idCheck = true;
                ClearErrors("IdFactura");
                isAlphaNumeric(value, "IdFactura");
                IsEmptyString(value, "IdFactura");
                OnPropertyChanged("IdFactura");
            }
        }

        private IdName _producto;
        public IdName Producto
        {
            get { return _producto; }
            set
            {
                _producto = value;
                OnPropertyChanged("Producto");
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

        private double _total;
        public double Total
        {
            get { return _total; }
            set
            {
                _total = value;
                OnPropertyChanged("Total");
            }
        }

        private int _cantidad;
        public int Cantidad
        {
            get { return _cantidad; }
            set
            {
                _cantidad = value;
                cantidadCheck = true;
                ClearErrors("Cantidad");
                isStepNumber(value.ToString(), "Cantidad");
                OnPropertyChanged("Cantidad");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
