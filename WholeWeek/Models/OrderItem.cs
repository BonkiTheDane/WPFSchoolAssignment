using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WholeWeek.Models.HotDogCondiments;

namespace WholeWeek.Models
{
    public class OrderItem
    {
        private HotDog _hotDog;
        private string _recipient;


        public HotDog HotDog { get => _hotDog; set => _hotDog = value; }
        public string Recipient { get => _recipient; set => _recipient = value; }


        public OrderItem(HotDog hotDog, string recipient) 
        {
            HotDog = hotDog;
            Recipient = recipient;
        }

        public override string ToString()
        {
            string result = $"Sausage: {HotDog.Sausage}\nLiquid Condiments:";
            foreach (LiquidCondiments.Variant lCondiment in HotDog.LiquidCondiments)
                result += $", {lCondiment.ToString()}";

            result += "\nSolid Condiments:";

            foreach (SolidCondiments.Variant sCondiment in HotDog.SolidCondiments)
                result += $", {sCondiment.ToString()}";

            return result;
        }
    }
}
