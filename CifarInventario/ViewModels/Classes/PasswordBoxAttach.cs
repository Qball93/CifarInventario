using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace CifarInventario.ViewModels.Classes
{
    public static class PasswordBoxAttach
    {
        public static readonly DependencyProperty BoundPassword =
            DependencyProperty.RegisterAttached("BoundPassword", typeof(string), typeof(PasswordBoxAttach), new PropertyMetadata(string.Empty, OnBoundPasswordChanged));



        private static bool _isUpdating;

        private static void OnBoundPasswordChanged(DependencyObject dp, DependencyPropertyChangedEventArgs e)
        {
            if (_isUpdating)
                return;

            if (!(dp is PasswordBox pwBox))
                return;

            pwBox.PasswordChanged -= OnPasswordChanged;
            pwBox.Password = (string)e.NewValue;
            pwBox.PasswordChanged += OnPasswordChanged;


        }


        private static void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!(sender is PasswordBox pwBox))
                return;

            _isUpdating = true;
            SetBoundPassword(pwBox, pwBox.Password);
            _isUpdating = false;

        }

        public static string GetBoundPassword(DependencyObject dp)
        {
            return (string)dp.GetValue(BoundPassword);
        }

        public static void SetBoundPassword(DependencyObject dp, string value)
        {
            dp.SetValue(BoundPassword, value);
        }
    }
}
