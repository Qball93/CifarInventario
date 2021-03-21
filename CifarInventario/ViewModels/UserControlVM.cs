using System;
using System.Collections.Generic;
using CifarInventario.Models;
using CifarInventario.ViewModels.Classes;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CifarInventario.ViewModels
{
    class UserControlVM: INotifyPropertyChanged
    {
        public UserControlVM()
        {
            Usuarios = new ObservableCollection<User>(UserQueries.GetUsers()); 
        }


        private ObservableCollection<User> _usuarios;

        public ObservableCollection<User> Usuarios
        {
            get { return _usuarios;  }
            set {
                _usuarios = value;
                OnPropertyChanged("Usuarios");

            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
