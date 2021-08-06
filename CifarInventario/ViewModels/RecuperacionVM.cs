using System;
using System.Collections.Generic;
using System.ComponentModel;
using CifarInventario.Models;
using System.Linq;
using CifarInventario.ViewModels.Classes.Queries;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CifarInventario.Views.Modals.LotesEntModals;
using System.Windows.Input;
using CifarInventario.ViewModels.Commands;
using CifarInventario.ViewModels.Commands.UserCommands;
using System.Collections.ObjectModel;
using CifarInventario.ViewModels.Classes;

namespace CifarInventario.ViewModels
{
    public class RecuperacionVM: Validators, INotifyPropertyChanged
    {
        public RecuperacionVM()
        {
            userCheck = false;
            userExists = false;
            obtainQuestion = new ObtainUserQuestion(this);
            updatePassword = new UpdateSelfPasswords(this);
            validate = new ValidateQuestionCommand(this);
        }

        public bool userCheck { get; set; }
        public bool passOneCheck { get; set; }
        public bool passTwoCheck { get; set; }
        public bool userExists { get; set; }

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
                passOneCheck = true;
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
                userCheck = true;
                IsEmptyString(value, nameof(UserName));
                isAlphaNumeric(value, nameof(UserName));
                OnPropertyChanged(nameof(UserName));
            }
        }


        public ObtainUserQuestion obtainQuestion;
        public UpdateSelfPasswords updatePassword;
        public ValidateQuestionCommand validate;

        public void ObtainPregunta()
        {
            OriginalPregunta = UserQueries.getPregunta(UserName);


            if (OriginalPregunta.Pregunta == "N/A")
            {
                System.Windows.MessageBox.Show("No existe ese Usuario.");
            }
            else
            {
                userExists = true;
            }
        }

        public void ValidarPregunta()
        {
            NewPregunta.Respuesta = Hasher.Encrypt(NewPregunta.Respuesta, OriginalPregunta.Salt);


            if(NewPregunta.Respuesta == OriginalPregunta.Respuesta)
            {

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
                //NewPasswordOne = Hasher.Encrypt(NewPasswordTwo, temp);
                UserQueries.SetNewUserPassword(NewPasswordOne, temp, OriginalPregunta.UserId);
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
