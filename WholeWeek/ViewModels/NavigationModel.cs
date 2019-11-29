using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WholeWeek.Views;

namespace WholeWeek.ViewModels
{
    public class NavigationModel
    {
        private Frame _frame;
        public Frame Frame { get => _frame; set => _frame = value; }

        private TableView _tables;
        private HomeView _homeView;
        private OrderView _orderView;

        public NavigationModel(Frame frame, TableView tables, HomeView homeView, OrderView orderView)
        {
            Frame = frame;
            _tables = tables;
            _homeView = homeView;
            _orderView = orderView;
        }

        public void ToHome()
        {
            _frame.Navigate(_homeView);
        }

        public void ToTables()
        {
            _frame.Navigate(_tables);
        }

        public void ToOrders()
        {
            _frame.Navigate(_orderView);
        }
    }
}
