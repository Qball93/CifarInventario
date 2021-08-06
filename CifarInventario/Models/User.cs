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
                OnPropertyChanged(nameof(Id));
            }
        }


        public string RoleName
        {
            get { return _roleName;  }
            set
            {
                _roleName = value;
                OnPropertyChanged(nameof(RoleName));
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

    public class Preguntas : Validators, INotifyPropertyChanged
    {



        public bool preguntaCheck, respuestaCheck = false;



        private int _userId;
        public int UserId
        {
            get { return _userId; }
            set
            {
                _userId = value;
                OnPropertyChanged(nameof(UserId));
            }
        }


        private string _pregunta;
        public string Pregunta
        {
            get { return _pregunta; }
            set
            {
                _pregunta = value;
                ClearErrors(nameof(Pregunta));
                IsEmptyString(value, nameof(Pregunta));
                isAlphaNumeric(value, nameof(Pregunta));
                OnPropertyChanged(nameof(Pregunta));
            }
        }

        private string _respuesta;
        public string Respuesta
        {
            get { return _respuesta; }
            set
            {
                _respuesta = value;
                ClearErrors(nameof(Respuesta));
                IsEmptyString(value, nameof(Respuesta));
                isAlphaNumeric(value, nameof(Respuesta));
                OnPropertyChanged(nameof(Respuesta));
            }
        }

        private string _salt;
        public string Salt
        {
            get { return _salt; }
            set
            {
                _salt = value;
                OnPropertyChanged(nameof(Salt));
            }
        }



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
                ClearErrors(nameof(UserName));
                IsEmptyString(value, nameof(UserName));
                isAlphaNumeric(value, nameof(UserName));
                OnPropertyChanged(nameof(UserName));

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
                ClearErrors(nameof(Password));
                IsEmptyString(value, nameof(Password));
                isAlphaNumeric(value, nameof(Password));
                OnPropertyChanged(nameof(Password));
            }
        }

        
        private bool _status;

        public bool Status
        {
            get { return _status; }
            set
            {
                _status = value;
                OnPropertyChanged(nameof(Status));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
