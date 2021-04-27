using System;
using System.Threading.Tasks;
using System.Windows.Controls;
using CarShowroom.Interfaces;
using CarShowroom.ViewModel.Administration.Users;

namespace CarShowroom.Controls.Administration.Users
{
    /// <summary>
    /// Interaction logic for UserCreateControl.xaml
    /// </summary>
    public partial class UserCreateControl : UserControl, IControl
    {
        public UserCreateViewModel ViewModel { get; set; }

        public UserCreateControl(UserCreateViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = ViewModel;
            InitializeComponent();
        }

        public async Task LoadInitialData()
        {
            await ViewModel.SetDefaultValues();

            var passwordControl = this.FindName("passwordBox") as PasswordControl;
            passwordControl.SecurePassword = String.Empty;
        }
    }
}