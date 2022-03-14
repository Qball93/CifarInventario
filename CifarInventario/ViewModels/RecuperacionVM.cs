using System;
using System.Collections.Generic;
using System.ComponentModel;
using CifarInventario.Models;
using System.Linq;
using CifarInventario.ViewModels.Classes.Queries;
using System.Text;
using System.Threading.Tasks;
using CifarInventario.Views;
using System.Windows;
using CifarInventario.Views.Modals.LotesEntModals;
using System.Windows.Input;
using CifarInventario.ViewModels.Commands;
using CifarInventario.ViewModels.Commands.UserCommands;
using System.Collections.ObjectModel;
using CifarInventario.ViewModels.Classes;

namespace CifarInventario.ViewModels
{
    public class RecuperacionVM: Validators, INotifyPropertyChanged, ICloseWindows
    {
        public RecuperacionVM()
        {
            UserCheck = false;
            UserExists = false;
            obtainQuestion = new ObtainUserQuestion(this);
            updatePassword = new UpdateSelfPasswords(this);
            validate = new ValidateQuestionCommand(this);
            NewPregunta = new Preguntas();

        }



        
        public bool UserCheck { get; set; }
        public bool PassOneCheck { get; set; }
        public bool passTwoCheck { get; set; }

        private bool _userExists;
        public bool UserExists
        {
            get { return _userExists; }
            set
            {
                _userExists = value;
                OnPropertyChanged(nameof(UserExists));
            }
        }


        private Preguntas _newPregunta;
        public Preguntas NewPregunta
        {
            get { return _newPregunta; }
            set
            {
                _newPregunta = value;
                OnPropertyChanged(nameof(NewPregunta));
            }
        }

        private Preguntas _originalPregunta;
        public Preguntas OriginalPregunta
        {
            get { return _originalPregunta; }
            set
            {
                _originalPregunta = value;
                OnPropertyChanged(nameof(OriginalPregunta));
            }
        }

        private string _newPasswordOne;
        public string NewPasswordOne
        {
            get { return _newPasswordOne; }
            set
            {
                _newPasswordOne = value;
                PassOneCheck = true;
                ClearErrors(nameof(NewPasswordOne));
                IsEmptyString(value, nameof(NewPasswordOne));
                isAlphaNumeric(value, nameof(NewPasswordOne));
                OnPropertyChanged(nameof(NewPasswordOne));
            }
        }

        private string _newPasswordTwo;
        public string NewPasswordTwo
        {
            get { return _newPasswordTwo; }
            set
            {
                _newPasswordTwo = value;
                passTwoCheck = true;
                ClearErrors(nameof(NewPasswordTwo));
                IsEmptyString(value, nameof(NewPasswordTwo));
                isAlphaNumeric(value, nameof(NewPasswordTwo));
                OnPropertyChanged(nameof(NewPasswordTwo));
            }
        }


        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                UserCheck = true;
                ClearErrors(nameof(UserName));
                IsEmptyString(value, nameof(UserName));
                isAlphaNumeric(value, nameof(UserName));
                OnPropertyChanged(nameof(UserName));
            }
        }


        public ObtainUserQuestion obtainQuestion { get; set; }
        public UpdateSelfPasswords updatePassword { get; set; }
        public ValidateQuestionCommand validate { get; set; }

        public void ObtainPregunta()
        {
            OriginalPregunta = UserQueries.getPregunta(UserName);


            if (OriginalPregunta.Pregunta == "N/A")
            {
                System.Windows.MessageBox.Show("No existe ese Usuario.");
            }
            else
            {
                UserExists = true;
            }
        }

        public void ValidarPregunta()
        {
            NewPregunta.Respuesta = Hasher.Encrypt(NewPregunta.Respuesta, OriginalPregunta.Salt);


            if(NewPregunta.Respuesta == OriginalPregunta.Respuesta)
            {

                Globals.setId(UserQueries.GetRoleId(UserName));
                Globals.setEmpladoId(UserQueries.GetEmpleadoId(UserName));
                NavigationMenu newWindow = new NavigationMenu();
                CloseWindow();
                newWindow.Show();


            }
            else
            {
                MessageBox.Show("Respuesta Incorrecta");
            }
        }

        public void SetNewPregunta()
        {
            if(NewPasswordOne == NewPasswordTwo)
            {
                var temp = Hasher.generateSalt();
                UserQueries.SetNewUserPassword(NewPasswordOne, temp, OriginalPregunta.UserId);
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        


        void CloseWindow()
        {
            Close?.Invoke();
        }

        public Action Close { get; set; }

        
    }


    interface ICloseWindows
    {
        Action Close { get; set; }
    }
}
