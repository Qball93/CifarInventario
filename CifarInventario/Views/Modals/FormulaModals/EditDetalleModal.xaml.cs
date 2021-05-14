﻿using System;
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
using CifarInventario.ViewModels;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CifarInventario.Views.Modals.FormulaModals
{
    /// <summary>
    /// Interaction logic for EditDetalleModal.xaml
    /// </summary>
    public partial class EditDetalleModal : Window
    {
        public EditDetalleModal(FormulasVM vm)
        {
            InitializeComponent();
            DataContext = vm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
