using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WholeWeek.Models
{
    public class Order
    {
        private int _id;
        private List<OrderItem> _items = new List<OrderItem>();
        private Table _table;
        private bool _delivered = false;

        public int Id { get => _id; }
        public List<OrderItem> Items { get => _items; set => _items = value; }
        public Table Table { get => _table; set => _table = value; }
        public bool Delivered { get => _delivered; set => _delivered = value; }

        public Order(int id, List<OrderItem> items, Table table)
        {
            _id = id;
            Items = items;
            Table = table;
        }

        public override string ToString()
        {
            string reString = $"Id: {Id}\n" +
                $"ItemCount: {Items.Count}\n" +
                $"Table: {Table.Name}\n";

            foreach(OrderItem item in Items)
            {
                reString += $"{item.Recipient}\n";
                reString += $"{item.ToString()}";
            }


            return reString;
        }
    }
}
