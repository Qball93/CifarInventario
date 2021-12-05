using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CifarInventario.ViewModels.Classes;
using CifarInventario.ViewModels.Commands;
using CifarInventario.Views;

namespace CifarInventario.Models
{
    public class Menu
    {

        public string MenuText { get; set; }
        public List<SubMenu> SubMenuList{ get; set; }
        public string MenuIcon { get; set; }
    }

    public class SubMenu
    {
        public string SubMenuText { get; set; }
        public string SubMenuPage { get; set; }

        public ICommand SubMenuCommand { get; }

        public SubMenu()
        {
            SubMenuCommand = new MenuCommand(Execute);
        }

        private void Execute()
        {

            string SMT = SubMenuPage.Replace(" ", string.Empty);
            if (!string.IsNullOrEmpty(SMT))
                navigateToPage(SMT);
        }

        private void navigateToPage(string Menu)
        {

            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(NavigationMenu))
                {
                    (window as NavigationMenu).MainWindowFrame.Navigate(new Uri(string.Format("{0}{1}{2}", "Views/Pages/", Menu, "Page.xaml"), UriKind.RelativeOrAbsolute));
                }
            }
        }

    }


    public class SubMenuPermission : Validators, INotifyPropertyChanged
    {
        private int _idRol;
        private string _nombreSubMenu;
        private int _idSubMenu;
        private bool _estado;


        public int IdRol
        {
            get { return _idRol; }
            set
            {
                _idRol = value;
                OnPropertyChanged(nameof(IdRol));
            }
        }

        public string NombreSubMenu
        {
            get { return _nombreSubMenu; }
            set
            {
                _nombreSubMenu = value;
                OnPropertyChanged(nameof(NombreSubMenu));
            }
        }

        public int IdSubMenu
        {
            get { return _idSubMenu; }
            set
            {
                _idSubMenu = value;
                OnPropertyChanged(nameof(IdSubMenu));
            }
        }

        public bool Estado
        {
            get { return _estado; }
            set
            {
                _estado = value;
                OnPropertyChanged(nameof(Estado));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
