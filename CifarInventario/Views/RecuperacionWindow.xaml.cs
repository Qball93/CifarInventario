using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using CifarInventario.ViewModels;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CifarInventario.Views
{
    /// <summary>
    /// Interaction logic for RecuperacionWindow.xaml
    /// </summary>
    public partial class RecuperacionWindow : Window
    {
        




        public RecuperacionWindow()
        {
            InitializeComponent();

            Loaded += MainWindow_Loaded;
            
            

        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

       


        private void Button_Close(object sender, RoutedEventArgs e)
        {
            
            Login newLogin = new Login();
            newLogin.Show();
            this.Close();
        }



        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if(DataContext is ICloseWindows vm)
            {
                vm.Close += () =>
                {
                    this.Close();
                };
            }
        }
    }
}
