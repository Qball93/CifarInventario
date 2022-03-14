using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CifarInventario.ViewModels.Classes
{
    static class Globals
    {

        private static int roleId;
        private static int userId;
        private static int empleadoId;


        public static int getEmpleadoId()
        {
            return empleadoId;
        }

        public static void setEmpladoId(int id)
        {
            empleadoId = id;
        }

        public static void setId(int id)
        {
            roleId = id;
        }

        public static int getId()
        {
            return roleId;
        }

        public static int getUserId()
        {
            return userId;
        }

        public static void setUserId(int id)
        {
            userId = id;
        }
        
    }


    public class IdName: INotifyPropertyChanged, IEquatable<IdName>
    {

        

        public IdName()
        {
            this.ID = "";
            this.Name = "";
        }


        public IdName(string id, string name)
        {
            this.ID = id;
            this.Name = name;
        }


        private string _id;
        private string _name;

        public string ID
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(ID));
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }



        public override string ToString()
        {
            return this.Name;
        }



        public override int GetHashCode()
        {
            return this.ID.GetHashCode() ^ this.Name.GetHashCode(); // or whatever
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            IdName idnameObj = obj as IdName;
            if (idnameObj == null)
                return false;
            else
                return Equals(idnameObj);
        }
        
        public bool Equals(IdName other)
        {
            if (other == null)
                return false;

            if (this.ID == other.ID && this.Name == other.Name)
                return true;
            else
                return false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
    }


    public class NameAmountdouble : Validators, INotifyPropertyChanged/*, IEquatable<NameAmountdouble>*/
    {

        private string _nombreUnidad;
        private double _cantidadUnidad;
        bool cantidadCheck = false;

        public string NombreUnidad
        {
            get { return _nombreUnidad; }
            set
            {
                _nombreUnidad = value;
                OnPropertyChanged(nameof(NombreUnidad));
            }
        }


        public double CantidadUnidad
        {
            get { return _cantidadUnidad; }
            set
            {
                _cantidadUnidad = value;
                isDecimal(value.ToString(), nameof(CantidadUnidad));
                OnPropertyChanged(nameof(CantidadUnidad));
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }

}
