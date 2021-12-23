using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CifarInventario.ViewModels.Classes;
using CifarInventario.Models;
using CifarInventario.ViewModels.Classes.Queries;
using System.Windows.Input;
using CifarInventario.ViewModels.Commands;

namespace CifarInventario.ViewModels
{
    public class EmpaqueVM
    {
        public EmpaqueVM() 
        {

            Registros = new ObservableCollection<Registro>(InfoQueries.getAllRecords());

            
        }


        private ObservableCollection<Registro> _registros;
        public ObservableCollection<Registro> Registros
        {
            get { return _registros; }
            set
            {
                _registros = value;
                OnPropertyChanged(nameof(Registros));
            }
        }

        private Registro _selectedRegistro;
        public Registro SelectedRegistro
        {
            get { return _selectedRegistro; }
            set
            {
                _selectedRegistro = value;
                OnPropertyChanged(nameof(SelectedRegistro));
            }
        }

        public ICommand openDesempaqueModal => new DelegateCommand(OpenInfoModal);


        public void OpenInfoModal(object parameter)
        {
            System.Windows.MessageBox.Show(SelectedRegistro.Accion);
        }




        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
