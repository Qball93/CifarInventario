using System;
using System.Collections.Generic;
using System.Linq;
using CifarInventario.ViewModels.Classes;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace CifarInventario.Models
{
    public class Role: INotifyPropertyChanged
    {
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }


        public string RoleName
        {
            get { return _roleName;  }
            set
            {
                _roleName = value;
                OnPropertyChanged("RoleName");
            }
        }



        private int _id;

        private string _roleName;
        





        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


    public class User : Validators, INotifyPropertyChanged
    {
        /// <summary>
        /// methods used for firsttime Validation Check on the corresponding command during validations
        /// </summary>
        public bool UserCheck, PasswordCheck = false;

        public int id { get; set; }
        public string salt { get; set; }
        public Role UserRole { get; set; }


        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set
            {
                UserCheck = true;
                _userName = value;
                ClearErrors("UserName");
                IsEmptyString(value, "UserName");
                isAlphaNumeric(value, "UserName");
                OnPropertyChanged("UserName");

            }
        }


        private string _password; 


        public string Password 
        { 
            get { return _password; }
            set
            {
                PasswordCheck = true;
                _password = value;
                ClearErrors("Password");
                IsEmptyString(value, "Password");
                isAlphaNumeric(value, "Password");
                OnPropertyChanged("Password");
            }
        }

        
        private bool _status;

        public bool Status
        {
            get { return _status; }
            set
            {
                _status = value;
                OnPropertyChanged("Status");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
