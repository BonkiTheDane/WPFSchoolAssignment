using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using WholeWeek.Models;
using WholeWeek.Models.HotDogCondiments;
using System.Windows;
using System.Windows.Input;
using System.Collections.ObjectModel;
using WholeWeek.Views;
using System.Windows.Controls.Primitives;

namespace WholeWeek.ViewModels
{
    public class ShellViewModel : INotifyPropertyChanged
    {

        //Placeholder definitions
        private ObservableCollection<Table> _tables = new ObservableCollection<Table>() {
        new Table("Brown Sugar"),
        new Table("Honky Tonk Woman"),
        new Table("Gimme Shelter"),
        new Table("Satisfaction"),
        new Table("Street Fighting Man"),
        new Table("Ruby Tuesday"),
        new Table("Tumbling Dice"),
        new Table("Angie"),
        new Table("Wild Horses"),
        new Table("Jumping Jack Flash"),
        };

        //Placeholder definitions
        private ObservableCollection<Order> _orders = new ObservableCollection<Order>() 
        { 
        };

        private Order selectedOrder;

        public Order SelectedOrder { get => selectedOrder; set { selectedOrder = value; NotifyChange("SelectedOrderString"); } }
        public string SelectedOrderString 
        { 
            get 
            {
                if (selectedOrder == null)
                    return "No order selected";
                else
                    return selectedOrder.ToString(); 
            } 
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Order> Orders { get => _orders; set { _orders = value; NotifyChange("Orders"); } }

        public ObservableCollection<Table> Tables { get => _tables; set { _tables = value; NotifyChange("Tables"); } }


        public ShellViewModel() 
        {
        }

        public void NotifyChange(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public void DeleteOrder(Order order)
        {
            Orders.Remove(order);

            Table table = Tables.Where(x => x == order.Table).FirstOrDefault();
            Tables.Remove(order.Table);

            table.Occupied = false;

            Tables.Add(table);


            NotifyChange("Orders");
        }


        public void MarkOrderAsDelivered()
        {
            var order = selectedOrder;

            Orders.Remove(selectedOrder);

            order.Delivered = true;

            Orders.Add(order);
        }





    }
}
