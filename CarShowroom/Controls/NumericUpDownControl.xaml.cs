using System;
using System.Windows;
using System.Windows.Controls;

namespace CarShowroom.Controls
{
    /// <summary>
    /// Interaction logic for NumericUpDownControl.xaml
    /// </summary>
    public partial class NumericUpDownControl : UserControl
    {
        public static readonly DependencyProperty NumberValueProperty = DependencyProperty.Register(
            "NumberValue", typeof(int), typeof(NumericUpDownControl), new PropertyMetadata(default(int)));

        public int MaxNumberValue { get; set; } = Int32.MaxValue;

        public int MinNumberValue { get; set; } = Int32.MinValue;

        public int NumberValue
        {
            get { return (int)(GetValue(NumberValueProperty)); }
            set
            {
                if (value >= MinNumberValue && value <= MaxNumberValue)
                {
                    SetValue(NumberValueProperty, value);
                }
            }
        }

        public NumericUpDownControl()
        {
            InitializeComponent();
        }

        private void NumericDownButton_OnClick(object sender, RoutedEventArgs e)
        {
            NumberValue--;
        }

        private void NumericUpButton_OnClick(object sender, RoutedEventArgs e)
        {
            NumberValue++;
        }

        private void NumericTextValueChanged(object sender, TextChangedEventArgs e)
        {
            string value = (sender as TextBox)?.Text;
            int parsedValue = 0;

            if (Int32.TryParse(value, out parsedValue))
            {
                if (parsedValue >= MinNumberValue && parsedValue <= MaxNumberValue)
                {
                    NumberValue = parsedValue;
                }
            }
        }
    }
}