﻿using CifarInventario.ViewModels;
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

namespace CifarInventario.Views.Modals.UserModals
{
    /// <summary>
    /// Interaction logic for NewPasswordModal.xaml
    /// </summary>
    public partial class NewPasswordModal : Window
    {
        public NewPasswordModal(UserPageVM vm)
        {
            InitializeComponent();
            DataContext = vm;
        }


        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
