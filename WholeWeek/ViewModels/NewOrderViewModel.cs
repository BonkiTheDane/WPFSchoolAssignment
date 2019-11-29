using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using WholeWeek.Models;
using WholeWeek.Models.HotDogCondiments;

namespace WholeWeek.ViewModels
{
    public class NewOrderViewModel : INotifyPropertyChanged
    {

        public NewOrderViewModel(List<Table> tables)
        {
            _tables = tables.Where(x => x.Occupied == false).ToList();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        //For creating orders
        private string _recipient = "";
        private List<Table> _tables;
        private Table _selectedTable;
        public string Recipient { get => _recipient; set { _recipient = value; NotifyChange("Recipient"); } }
        public Table SelectedTable { get => _selectedTable; set => _selectedTable = value; }
        public List<Table> Tables { get => _tables; }

        //Sausages
        private bool _boiled = true;
        private bool _fried = false;
        private bool _xLFried = false;

        public bool Boiled { get => _boiled; set { _boiled = value; NotifyChange("Boiled"); } }
        public bool Fried { get => _fried; set { _fried = value; NotifyChange("Fried"); } }
        public bool XLFried { get => _xLFried; set { _xLFried = value; NotifyChange("XLFried"); } }


        //Liquid Condiments
        private bool _mustard = true;
        private bool _ketchup = true;
        private bool _remoulade = false;

        public bool Mustard { get => _mustard; set { _mustard = value; NotifyChange("Mustard"); } }
        public bool Ketchup { get => _ketchup; set { _ketchup = value; NotifyChange("Ketchup"); } }
        public bool Remoulade { get => _remoulade; set { _remoulade = value; NotifyChange("Remoulade"); } }


        //Solid Condiments
        private bool _roastedOnion = true;
        private bool _rawOnion = true;
        private bool _pickledOnion = false;
        private bool _cucumberSalad = false;

        public bool RoastedOnion { get => _roastedOnion; set { _roastedOnion = value; NotifyChange("RoastedOnion"); } }
        public bool RawOnion { get => _rawOnion; set { _rawOnion = value; NotifyChange("RawOnion"); } }
        public bool PickledOnion { get => _pickledOnion; set { _pickledOnion = value; NotifyChange("PickledOnion"); } }
        public bool CucumberSalad { get => _cucumberSalad; set { _cucumberSalad = value; NotifyChange("CucumberSalad"); } }




        public OrderItem CreateHotDog()
        {

            Sausage.Variant sausage = new Sausage.Variant();
            List<LiquidCondiments.Variant> liquidCondiments = new List<LiquidCondiments.Variant>();
            List<SolidCondiments.Variant> solidCondiments = new List<SolidCondiments.Variant>();

            if (Boiled == true)
                sausage = Sausage.Variant.Boiled;
            else if(Fried == true)
                sausage = Sausage.Variant.Fried;
            else if (XLFried == true)
                sausage = Sausage.Variant.XLFried;


            if (Mustard == true)
                liquidCondiments.Add(LiquidCondiments.Variant.Mustard);
            if (Ketchup == true)
                liquidCondiments.Add(LiquidCondiments.Variant.Ketchup);
            if (Remoulade == true)
                liquidCondiments.Add(LiquidCondiments.Variant.Remoulade);


            if (RoastedOnion == true)
                solidCondiments.Add(SolidCondiments.Variant.RoastedOnion);
            if (RawOnion == true)
                solidCondiments.Add(SolidCondiments.Variant.RawOnion);
            if (PickledOnion == true)
                solidCondiments.Add(SolidCondiments.Variant.PickledOnion);
            if (CucumberSalad == true)
                solidCondiments.Add(SolidCondiments.Variant.CucumberSalad);

            HotDog hotdog = new HotDog(sausage, liquidCondiments, solidCondiments);
            return new OrderItem(hotdog, Recipient);
    }


        public bool CreateOrder(ShellViewModel shellModel)
        {
            var order = new Order(
                shellModel.Orders.Count(),
                new List<OrderItem>() { CreateHotDog() },
                SelectedTable
                );

            shellModel.Orders.Add(order);

            Table table = shellModel.Tables.Where(x => x == order.Table).FirstOrDefault();
            shellModel.Tables.Remove(order.Table);

            table.Occupied = true;

            shellModel.Tables.Add(table);

            return true;
        }


        private void NotifyChange(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
