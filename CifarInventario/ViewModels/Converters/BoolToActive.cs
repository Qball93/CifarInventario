using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CifarInventario.ViewModels.Converters
{
    class BoolToActive : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isActive = (bool)value;

            if (isActive)
                return "Activo";

            return "Inactivo";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string isActive = (string)value;

            if (isActive == "Activo")
                return true;
            return false;
        }
    }

}
