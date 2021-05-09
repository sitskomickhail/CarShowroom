using System.Windows;
using System.Windows.Controls;
using CarShowroom.Events.Layout;

namespace CarShowroom.Controls
{
    /// <summary>
    /// Interaction logic for Connector.xaml
    /// </summary>
    public partial class ConnectorControl : UserControl
    {
        public ConnectorControl()
        {
            InitializeComponent();
            selfWatcher.ChangeTarget(this);

            selfWatcher.Changed += RecalcLine;
            fromWatcher.Changed += RecalcLine;
            toWatcher.Changed += RecalcLine;
            RecalcLine(null, null);
        }

        LayoutWatcher selfWatcher = new LayoutWatcher(),
                      fromWatcher = new LayoutWatcher(),
                      toWatcher = new LayoutWatcher();

        #region dp FrameworkElement From
        public FrameworkElement From
        {
            get { return (FrameworkElement)GetValue(FromProperty); }
            set { SetValue(FromProperty, value); }
        }

        public static readonly DependencyProperty FromProperty =
            DependencyProperty.Register("From", typeof(FrameworkElement), typeof(ConnectorControl),
                new FrameworkPropertyMetadata((o, args) =>
                { var self = (ConnectorControl)o; self.fromWatcher.ChangeTarget(self.From); }));
        #endregion

        #region dp FrameworkElement To
        public FrameworkElement To
        {
            get { return (FrameworkElement)GetValue(ToProperty); }
            set { SetValue(ToProperty, value); }
        }

        public static readonly DependencyProperty ToProperty =
            DependencyProperty.Register("To", typeof(FrameworkElement), typeof(ConnectorControl),
                new FrameworkPropertyMetadata((o, args) =>
                { var self = (ConnectorControl)o; self.toWatcher.ChangeTarget(self.To); }));
        #endregion

        void RecalcLine(object sender, LayoutChangeEventArgs e)
        {
            if (From == null || To == null)
            {
                ConnectingLine.Visibility = Visibility.Collapsed;
                return;
            }

            ConnectingLine.Visibility = Visibility.Visible;

            var fromRect = LayoutWatcher.ComputeRenderRect(From, this);
            var toRect = LayoutWatcher.ComputeRenderRect(To, this);

            ConnectingLine.X1 = fromRect.Right + 5;
            ConnectingLine.Y1 = fromRect.Top + fromRect.Height / 2;

            ConnectingLine.X2 = toRect.Left - 5;
            ConnectingLine.Y2 = toRect.Top + toRect.Height / 2;
        }
    }
}