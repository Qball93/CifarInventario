using System;
using System.IO;
using iText.IO.Font.Constants;
using iText.IO.Util;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Borders;
using iText.Layout.Properties;
using System.Collections.Generic;
using CifarInventario.Models;
using CifarInventario.ViewModels.Classes;
using System.Collections.ObjectModel;
using System.ComponentModel;
using CifarInventario.Views.Modals.UserModals;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CifarInventario.ViewModels.Classes.Queries;
using CifarInventario.ViewModels.Commands;
using CifarInventario.ViewModels.Commands.UserCommands;
using Table = iText.Layout.Element.Table;
using Paragraph = iText.Layout.Element.Paragraph;
using Border = iText.Layout.Borders.Border;

namespace CifarInventario.ViewModels
{
    public class UserPageVM : INotifyPropertyChanged
    {
        public UserPageVM()
        {
            Usuarios = new ObservableCollection<User>(UserQueries.GetUsers());
            Empleados = new List<IdName>(PersonaQueries.GetEmpleadosDropDown());
            Roles = new ObservableCollection<Role>(UserQueries.GetRoles());
            SelectedRole = new Role();
            NuevoUsuarioCommand = new NewUserCommand(this);
            UpdateUsuarioCommand = new UpdateUserCommand(this);
            NewPasswordCommand = new UpdateUserPassword(this);
            NewUser = new User();

        }


        #region commands
        public ICommand CreateNew => new DelegateCommand(CreateNewUserModal);

        public ICommand EditUser => new DelegateCommand(UpdateUserModal);

        public ICommand NewPass => new DelegateCommand(UpdatePasswordModal);

        public ICommand PdfList => new DelegateCommand(ExportPdf);

        public NewUserCommand NuevoUsuarioCommand { get; set; }

        public UpdateUserCommand UpdateUsuarioCommand { get; set;}

        public UpdateUserPassword NewPasswordCommand { get; set; }


        #endregion




        private ObservableCollection<User> _usuarios;

        public ObservableCollection<User> Usuarios
        {
            get { return _usuarios;  }
            set {
                _usuarios = value;
                OnPropertyChanged("Usuarios");

            }
        }


        private List<IdName> _empleados;

        public List<IdName> Empleados
        {
            get { return _empleados; }
            set
            {
                _empleados = value;
                OnPropertyChanged(nameof(Empleados));
            }
        }


        //public ObservableCollection<Role> Roles { get; set; }


        private bool _estado;

        public bool Estado {
            get { return _estado; }
            set {
                _estado = value;
                OnPropertyChanged("Estado");
            }
        }

        public ObservableCollection<Role> Roles { get; set; }

        public Role SelectedRole { get; set; }


        public EditUserModal editModal { get; set; }


        private User _newUser;

        public User NewUser
        {
            get { return _newUser; }
            set { _newUser = value;
                }
        }


        private User _selectedUser;

        public User SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                _selectedUser = value;
                OnPropertyChanged(nameof(SelectedUser));
            }
        }





        #region User functions

        public void CreateUser()
        {
            NewUser.salt = Hasher.generateSalt();
            NewUser.Password = Hasher.Encrypt(NewUser.Password, NewUser.salt);

           // System.Windows.MessageBox.Show(SelectedRole.Id + " " + Estado + " " + NewUser.UserName + " " + NewUser.Password + " " + NewUser.salt + " " + NewUser.Empleado.ID);

            UserQueries.CreateNewUser(SelectedRole.Id, NewUser.Status, NewUser.UserName, NewUser.Password, NewUser.salt, int.Parse(NewUser.Empleado.ID));
            NewUser.UserRole = SelectedRole;

            Usuarios.Add(NewUser);

           // System.Windows.MessageBox.Show(" This is the selected role " + SelectedRole.Id  +  "this is the estado "+ Estado +
               // "This is the password" + NewUser.Password+ " and this is the salt " + NewUser.salt   +   "this is the username " + NewUser.UserName);


           // System.Windows.MessageBox.Show("success???");
        }

        public void UpdateUser()
        {


            
            UserQueries.SetNewUserInfo(NewUser.UserRole.Id, NewUser.Status, NewUser.UserName, NewUser.id, int.Parse(NewUser.Empleado.ID));

            updateCollectionInstance();

            System.Windows.MessageBox.Show("Usuario Actualizado");


            editModal.Close();
        }

        public void UpdateUserPassword()
        {
            NewUser.salt = Hasher.generateSalt();
            
            string temp = Hasher.Encrypt(NewUser.Password, NewUser.salt);


            UserQueries.SetNewUserPassword(temp, NewUser.salt, SelectedUser.id);

            
        }

        #endregion

        #region modal opening functions

        public void CreateNewUserModal(object parameter)
        {
            var TestView = new NewUser(this);

            //NewUser.UserName = "asdsadas";
            //TestView.DataContext = this;



            //System.Windows.MessageBox.Show(TestView.DataContext.ToString());



            TestView.ShowDialog();
        }

        public void UpdateUserModal(object parameter)
        {

            NewUser = new User(SelectedUser);


            editModal = new EditUserModal(this);
            editModal.ShowDialog();



           // Usuarios.Remove(Usuarios.Where(i => i.id == SelectedUser.id).Single());

        }


        public void updateCollectionInstance()
        {
            SelectedUser.UserName = NewUser.UserName;
            SelectedUser.Empleado = NewUser.Empleado;
            SelectedUser.UserRole = NewUser.UserRole;

        }

        public void ExportPdf(object parameter)
        {
            string DEST = @"D:\Downloads\ListaUsuarios.pdf";


            FileInfo file = new FileInfo(DEST);
            file.Directory.Create();

            PdfWriter writer = new PdfWriter(DEST);

            PdfDocument pdf = new PdfDocument(writer);

            Document document = new Document(pdf, PageSize.A4);

            document.SetMargins(40, 40, 20, 20);









        }

        public void UpdatePasswordModal(object parameter)
        {
            var TestView = new NewPasswordModal(this);

            TestView.ShowDialog();
        }

        #endregion

        

        

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
