using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using CifarInventario.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CifarInventario.ViewModels.Classes.Queries;
using System.Windows.Input;
using CifarInventario.ViewModels.Commands;

namespace CifarInventario.ViewModels
{
    public class PermisoVM: INotifyPropertyChanged
    {
        public PermisoVM()
        {
            Roles = new ObservableCollection<Role>(RoleQueries.GetRoles());
            Permissions = new ObservableCollection<SubMenuPermission>();
            SelectedRol = new Role();
        }


        private ObservableCollection<Role> _roles;

        public ObservableCollection<Role> Roles
        {
            get { return _roles; }
            set
            {
                _roles = value;
                OnPropertyChanged(nameof(Roles));
            }
        }

        private ObservableCollection<SubMenuPermission> _permissions;
        public ObservableCollection<SubMenuPermission> Permissions
        {
            get { return _permissions; }
            set
            {
                _permissions = value;
                OnPropertyChanged(nameof(Permissions));
            }
        }


        private Role _selectedRol;
        
        public Role SelectedRol
        {
            get { return _selectedRol;  }
            set
            {
                _selectedRol = value;
                OnPropertyChanged(nameof(SelectedRol));
            }
        }


        private SubMenuPermission _selectedPermission;
        public SubMenuPermission SelectedPermission
        {
            get { return _selectedPermission; }
            set
            {
                _selectedPermission = value;
                OnPropertyChanged(nameof(SelectedPermission));
            }
        }

        public ICommand getSubs => new DelegateCommand(GetSubMenusForRole);
        public ICommand togglePermissions => new DelegateCommand(TogglePermission);
        public ICommand agregarSubMenuToRole => new DelegateCommand(AgregarSubMenuToRole);


        public void GetSubMenusForRole(object parameter)
        {
            Permissions = new ObservableCollection<SubMenuPermission>(MenuQueries.getSubMenusForRole(SelectedRol.Id));
        }


        public void openNewSubMenuModal()
        {

        }

        public void AgregarSubMenuToRole(object parameter)
        {

        }

        public void TogglePermission(object parameter)
        {

            
            MenuQueries.cambiarEstadoPermiso(SelectedRol.Id, SelectedPermission.IdSubMenu, !SelectedPermission.Estado);
            SelectedPermission.Estado = !SelectedPermission.Estado;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }





}
