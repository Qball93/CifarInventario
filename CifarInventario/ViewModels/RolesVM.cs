using System;
using System.Collections.Generic;
using System.Linq;
using CifarInventario.Models;
using CifarInventario.ViewModels.Classes.Queries;
using System.Text;
using System.Threading.Tasks;
using CifarInventario.Views.Modals.RoleModals;
using System.ComponentModel;
using CifarInventario.ViewModels.Commands.RoleCommands;
using CifarInventario.ViewModels.Commands;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace CifarInventario.ViewModels
{
    public class RolesVM : INotifyPropertyChanged
    {
        public RolesVM()
        {
            Roles = new ObservableCollection<Role>(RoleQueries.GetRoles());
            newRoleCommand = new NuevoRoleCommand(this);
            editRoleCommand = new EditRoleCommand(this);
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

        private Role _selectedRole;
        public Role SelectedRole
        {
            get { return _selectedRole; }
            set
            {
                _selectedRole = value;
                OnPropertyChanged(nameof(SelectedRole));
            }
        }

        private Role _newRole;
        public Role NewRole
        {
            get { return _newRole; }
            set
            {
                _newRole = value;
                OnPropertyChanged(nameof(NewRole));
            }
        }
        
        public ICommand openEdit => new DelegateCommand(openEditModal);
        public ICommand openNew => new DelegateCommand(openNewRoleModal);
        public NuevoRoleCommand newRoleCommand  { get; set; }
        public EditRoleCommand editRoleCommand { get; set; }
        public EditRoleModal editModal { get; set; }
        
        public void openNewRoleModal(object parameter)
        {
            NewRole = new Role();
            var temp = new NewRoleModal(this);
            temp.ShowDialog();

        }

        public void openEditModal(object parameter)
        {
            NewRole = new Role(SelectedRole);
            editModal = new EditRoleModal(this);
            editModal.ShowDialog();
        }
        
        public void agregarRole()
        {
            RoleQueries.CreateRole(NewRole.RoleName);
            NewRole = new Role();
            System.Windows.MessageBox.Show("Nuevo Role Creado.");
            Roles.Add(NewRole);
        }

        public void editarRole()
        {
            RoleQueries.EditName(SelectedRole);
            updateCollectionInstance(NewRole);
            System.Windows.MessageBox.Show("Nombre de Role cambiado.");
            editModal.Close();
        }


        public void updateCollectionInstance(Role updatedInstance)
        {
            SelectedRole.Id = updatedInstance.Id;
            SelectedRole.RoleName = updatedInstance.RoleName;

        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
