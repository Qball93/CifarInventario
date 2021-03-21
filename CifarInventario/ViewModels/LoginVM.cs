using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CifarInventario.ViewModels.Commands;
using CifarInventario.Models;
using System.ComponentModel;
using CifarInventario.ViewModels.Classes;
using System.Threading.Tasks;

namespace CifarInventario.ViewModels
{
    public class LoginVM : INotifyPropertyChanged
    {

        public LoginVM()
        {
            loginCommand = new LoginCommand(this);
            LoginUser = new User();
        }

        

        //public Converters myConverter { get; set; }

        public LoginCommand loginCommand { get; set; }

        public User LoginUser { get; set; }

        

        

        public void MakeLogin()
        {
            User realUser = LoginHelper.GetLoginUser(LoginUser.UserName);

            

            string testPassword = Hasher.Encrypt(LoginUser.Password, realUser.salt);

            System.Windows.MessageBox.Show("this is the password " + realUser.Password + " and this is the salt " + realUser.salt);

            if (testPassword == realUser.Password)
            {
                System.Windows.MessageBox.Show("yayyy");
            }
            else
            {
                System.Windows.MessageBox.Show("Contrasena o Usuario invalido");
            }

        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
