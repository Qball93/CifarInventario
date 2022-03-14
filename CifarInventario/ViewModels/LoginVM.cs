using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CifarInventario.ViewModels.Commands;
using CifarInventario.Models;
using System.ComponentModel;
using CifarInventario.ViewModels.Classes;
using System.Threading.Tasks;
using CifarInventario.ViewModels.Classes.Queries;
using CifarInventario.Views;

namespace CifarInventario.ViewModels
{
    public class LoginVM : INotifyPropertyChanged, ICloseWindows
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
            string testPassword = Hasher.Encrypt(LoginUser.Password,realUser.salt);

           // System.Windows.MessageBox.Show(testPassword);

            if (testPassword == realUser.Password)
            {
                Globals.setId(realUser.UserRole.Id);
                Globals.setEmpladoId(int.Parse(realUser.Empleado.ID));
                NavigationMenu newWindow = new NavigationMenu();
                CloseWindow();
                newWindow.Show();
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


        void CloseWindow()
        {
            Close?.Invoke();
        }

        public Action Close { get; set; }
    }



    
}
