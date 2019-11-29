using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WholeWeek.ViewModels;

namespace WholeWeek.Views
{
    /// <summary>
    /// Interaction logic for OrderView.xaml
    /// </summary>
    public partial class OrderView : Page
    {
        public NavigationModel navigation = null;

        public OrderView()
        {
            InitializeComponent();
        }

        private void DeleteOrder(object sender, RoutedEventArgs e)
        {
            var viewModel = (ShellViewModel)this.DataContext;
            viewModel.DeleteOrder(viewModel.SelectedOrder);
        }

        private void NewOrder(object sender, RoutedEventArgs e)
        {
            var viewModel = (ShellViewModel)this.DataContext;
            NewOrderView nOView = new NewOrderView(viewModel, navigation);

            navigation.Frame.Navigate(nOView);
        }

        private void MarkAsDelivered(object sender, RoutedEventArgs e)
        {
            var viewModel = (ShellViewModel)this.DataContext;
            viewModel.MarkOrderAsDelivered();
        }
    }
}
