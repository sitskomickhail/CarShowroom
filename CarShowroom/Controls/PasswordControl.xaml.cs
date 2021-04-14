using System.Windows;
using System.Windows.Controls;

namespace CarShowroom.Controls
{
    /// <summary>
    /// Interaction logic for PasswordControl.xaml
    /// </summary>
    public partial class PasswordControl : UserControl
    {
        public static readonly DependencyProperty SecurePasswordProperty = DependencyProperty.Register(
            "SecurePassword", typeof(string), typeof(PasswordControl), new PropertyMetadata(default(string)));

        public string SecurePassword
        {
            get { return (string)GetValue(SecurePasswordProperty); }
            set { SetValue(SecurePasswordProperty, value); }
        }

        public PasswordControl()
        {
            InitializeComponent();
        }

        private void PasswordBox_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            SecurePassword = ((PasswordBox)sender).Password;
        }
    }
}