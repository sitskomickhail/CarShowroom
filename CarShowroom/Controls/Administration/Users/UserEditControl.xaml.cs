using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using CarShowroom.Interfaces;
using CarShowroom.ViewModel.Administration.Users;

namespace CarShowroom.Controls.Administration.Users
{
    /// <summary>
    /// Interaction logic for UserEditControl.xaml
    /// </summary>
    public partial class UserEditControl : UserControl, IControl
    {
        public UserEditViewModel ViewModel { get; set; }

        public UserEditControl(UserEditViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = ViewModel;
            InitializeComponent();
        }

        private void SaveButton_OnClick(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            Guid vehicleId = Guid.Parse(clickedButton.DataContext.ToString());

            ViewModel.SaveUserCommand.Execute(vehicleId);
        }

        private void DeleteButton_OnClick(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Do you really want to delete this user?",
                "Warning",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question,
                MessageBoxResult.No);

            if (result == MessageBoxResult.Yes)
            {
                Button clickedButton = sender as Button;
                Guid vehicleId = Guid.Parse(clickedButton.DataContext.ToString());

                ViewModel.DeleteUserCommand.Execute(vehicleId);
            }
        }

        public async Task LoadInitialData()
        {
            await ViewModel.SetDefaultValues();
        }
    }
}