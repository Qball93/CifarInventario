using System;
using System.Collections.Generic;
using System.ComponentModel;
using CifarInventario.Models;
using CifarInventario.ViewModels.Classes;
using System.Linq;
using CifarInventario.ViewModels.Classes.Queries;
using CifarInventario.ViewModels.Commands.UserCommands;
using System.Text;
using System.Threading.Tasks;

namespace CifarInventario.ViewModels
{
    public class PreguntasVM: INotifyPropertyChanged
    {
        public PreguntasVM()
        {
            App.Current.Properties["userID"] = "master";
            RecoveryQuestion = new Preguntas();
            RecoveryQuestion = UserQueries.getPregunta(App.Current.Properties["userID"].ToString());
            SingleQuestion = RecoveryQuestion.Pregunta;
            RecoveryQuestion.Pregunta = "";
            RecoveryQuestion.Respuesta = "";
            RecoveryQuestion.preguntaCheck = false;
            RecoveryQuestion.respuestaCheck = false;
            updatePregunta = new UpdatePreguntasCommand(this);


        }


        private string _singleQuestion;
        public string SingleQuestion
        {
            get { return _singleQuestion; }
            set
            {
                _singleQuestion = value;
                OnPropertyChanged(nameof(SingleQuestion));
            }
        }

        private Preguntas _recoveryQuestion;
        public Preguntas RecoveryQuestion
        {
            get { return _recoveryQuestion; }
            set
            {
                _recoveryQuestion = value;
                OnPropertyChanged(nameof(RecoveryQuestion));
            }
        }

        public UpdatePreguntasCommand updatePregunta { get; set; }



        public void ActualizarPregunta()
        {
            RecoveryQuestion.Salt = Hasher.generateSalt();
            RecoveryQuestion.Respuesta = Hasher.Encrypt(RecoveryQuestion.Respuesta, RecoveryQuestion.Salt);

            UserQueries.updatePregunta(RecoveryQuestion);

            SingleQuestion = RecoveryQuestion.Pregunta;

            RecoveryQuestion.Pregunta = "";
            RecoveryQuestion.Respuesta = "";
            RecoveryQuestion.preguntaCheck = false;
            RecoveryQuestion.respuestaCheck = false;


            System.Windows.MessageBox.Show("Pregunta Actualizada");
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
