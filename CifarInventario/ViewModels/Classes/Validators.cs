using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;

namespace CifarInventario.ViewModels.Classes
{
    public  class Validators : INotifyDataErrorInfo
    {

        public readonly string OnetoNine = @"^[0-9]*$";
        public readonly string PreciseNumber = @"/\d+\.?\d*/";
        public readonly string moneyRegEx = @"^(0|0?[1-9]\d*)\.\d\d$";
        public readonly string alphanumeric = @"[a-zA-Z0-9_]*$";


        public void isStepNumber(string property, string propertyName)
        {
            if (!(Regex.IsMatch(property, OnetoNine)))
                AddError(propertyName, "Este campo solo acepta numeros.");
        }

        public void IsEmptyString(string value, string propertyName)
        {
            if (String.IsNullOrEmpty(value))
                AddError(propertyName, "Campo no puede estar vacio.");
        }

        public void isEmptyInt(int? property, string propertyName)
        {
            if (!property.HasValue)
                AddError(propertyName, "Campo no puede estar vacio.");
        }

        public void isAlphaNumeric(string property, string propertyName)
        {
            if (!(Regex.IsMatch(property, alphanumeric)))
                AddError(propertyName, "Este campo tiene que ser alpha numerico.");
        }

        public void isDecimal(string property, string propertyName)
        {
            if ((Regex.IsMatch(property, PreciseNumber)))
                AddError(propertyName, "Este campo solo acepta numeros y decimales.");
        }

        #region INotifyDataErrorInfo members

        private readonly Dictionary<string, List<string>> _propertyErrors = new Dictionary<string, List<string>>();


        public bool HasErrors => _propertyErrors.Any();

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            return _propertyErrors.GetValueOrDefault(propertyName, null);
        }

        public string GetPropertyError(string propertyName)
        {
            return _propertyErrors[propertyName][0];
        }

        public void AddError(string propertyName, string errorMessage)
        {
            if (!_propertyErrors.ContainsKey(propertyName))
            {
                _propertyErrors.Add(propertyName, new List<string>());
            }

            _propertyErrors[propertyName].Add(errorMessage);
            OnErrorsChanged(propertyName);
        }

        private void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        public void ClearErrors(string propertyName)
        {
            if (_propertyErrors.Remove(propertyName))
            {
                OnErrorsChanged(propertyName);
            }

        }

        #endregion
    }
}
