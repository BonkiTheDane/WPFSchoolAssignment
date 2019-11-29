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
using System.Windows.Shapes;
using WholeWeek.ViewModels;

namespace WholeWeek.Views
{
    /// <summary>
    /// Interaction logic for ShellView.xaml
    /// </summary>
    public partial class ShellView : Window
    {
        public NavigationModel navigation;

        public ShellView()
        {
            var viewModel = new ShellViewModel();
            this.DataContext = viewModel;
            InitializeComponent();

            var tables = new TableView();
            var orders = new OrderView();
            var home = new HomeView();


            tables.DataContext = this.DataContext;
            orders.DataContext = this.DataContext;
            home.DataContext = this.DataContext;

            navigation = new NavigationModel(frame, tables, home, orders);

            orders.navigation = navigation;

            navigation.ToHome();

        }

        private void ButtonHome(object sender, RoutedEventArgs e)
        {
            navigation.ToHome();
        }

        private void ButtonTables(object sender, RoutedEventArgs e)
        {
            navigation.ToTables();
        }

        private void ButtonOrders(object sender, RoutedEventArgs e)
        {
            navigation.ToOrders();
        }
    }
}