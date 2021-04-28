using System.Windows;
using CarShowroom.Entities.Models.AnswerModels.Clients;

namespace CarShowroom.Controls.Administration.Clients
{
    /// <summary>
    /// Interaction logic for ClientDealsInfo.xaml
    /// </summary>
    public partial class ClientDealsInfo : Window
    {
        public ClientDealsInfo(ClientDealsAnswerModel model)
        {
            DataContext = model;
            this.Title = $"Deals of {model.Name}";

            InitializeComponent();
        }
    }
}