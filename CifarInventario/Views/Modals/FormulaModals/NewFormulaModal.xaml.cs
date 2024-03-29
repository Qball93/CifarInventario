﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CifarInventario.Models;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using CifarInventario.ViewModels.Classes;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using CifarInventario.ViewModels;
using System.Windows.Shapes;

namespace CifarInventario.Views.Modals.FormulaModals
{
    /// <summary>
    /// Interaction logic for NewFormulaModal.xaml
    /// </summary>
    public partial class NewFormulaModal : Window
    {
        


        public NewFormulaModal(FormulasVM vm)
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

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
