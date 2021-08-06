using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CifarInventario.Views
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            //var tups = MainConnection.GetSaltPass(tbUser.Text);





            //Trace.WriteLine(Encoding.UTF8.GetString(new Security().generateSalt()));

            //MessageBox.Show(new Hasher().Encrypt("password", "SVcL4q8eTX2w0ZKo"));

            //MessageBox.Show(Convert.ToBase64String(new Hasher().generateSalt()));

        }

        private void Button_Close(object sender, RoutedEventArgs e)
        {

            RecuperacionWindow newWindow = new RecuperacionWindow();
            newWindow.Show();
            this.Close();
        }
    }
}
