using System.Windows;
using System.Windows.Controls;

namespace CarShowroom.Controls.Administration
{
    public class AdministrationBaseControl : UserControl
    {
        public static readonly DependencyProperty CurrentCheckedControlProperty = DependencyProperty.Register(
            "CurrentCheckedControl", typeof(AdministrationBaseControl), typeof(UserControl));

        public AdministrationBaseControl CurrentCheckedControl
        {
            get { return GetValue(CurrentCheckedControlProperty) as AdministrationBaseControl; }
            set
            {
                SetValue(CurrentCheckedControlProperty, value);
            }
        }

        public virtual void HideControl()
        {
            this.Visibility = Visibility.Hidden;
        }

        public virtual void ShowControl()
        {
            this.Visibility = Visibility.Visible;
        }
    }
}