using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WholeWeek.Models;
using WholeWeek.ViewModels;

namespace WholeWeek.Views
{
    /// <summary>
    /// Interaction logic for NewOrderView.xaml
    /// </summary>
    public partial class NewOrderView : Page
    {
        private ShellViewModel _shellModel;
        private NewOrderViewModel _viewModel;
        public NavigationModel navigation;
        public NewOrderView(ShellViewModel model, NavigationModel _navigation)
        {
            InitializeComponent();
            _shellModel = model;
            _viewModel = new NewOrderViewModel(_shellModel.Tables.ToList());
            DataContext = _viewModel;
            navigation = _navigation;
        }

        private void CreateOrder(object sender, RoutedEventArgs e)
        {
            var order = _viewModel.CreateOrder(_shellModel);
            navigation.ToOrders();
        }

        private void CancelOrder(object sender, RoutedEventArgs e)
        {
            navigation.ToOrders();
        }
    }
}
