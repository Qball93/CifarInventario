using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
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

        public ICommand SubMenuCommand { get; }

        public SubMenu()
        {
            SubMenuCommand = new MenuCommand(Execute);
        }

        private void Execute()
        {

            string SMT = SubMenuText.Replace(" ", string.Empty);
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
}
