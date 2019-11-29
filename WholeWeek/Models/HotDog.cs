using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WholeWeek.Models.HotDogCondiments;

namespace WholeWeek.Models
{
    public class HotDog
    {
        private Sausage.Variant _sausage;
        private List<LiquidCondiments.Variant> _liquidCondiments = new List<LiquidCondiments.Variant>();
        private List<SolidCondiments.Variant> _solidCondiments = new List<SolidCondiments.Variant>();

        public Sausage.Variant Sausage { get => _sausage; set => _sausage = value; }
        public List<LiquidCondiments.Variant> LiquidCondiments { get => _liquidCondiments; set => _liquidCondiments = value; }
        public List<SolidCondiments.Variant> SolidCondiments { get => _solidCondiments; set => _solidCondiments = value; }

        public HotDog(Sausage.Variant sausage, List<LiquidCondiments.Variant> liquidCondiments, List<SolidCondiments.Variant> solidCondiments)
        {
            Sausage = sausage;
            LiquidCondiments = liquidCondiments;
            SolidCondiments = solidCondiments;
        }

        //Default hotdog
        public HotDog()
        {
            Sausage = HotDogCondiments.Sausage.Variant.Boiled;

            LiquidCondiments = new List<LiquidCondiments.Variant>()
            {
                HotDogCondiments.LiquidCondiments.Variant.Mustard,
                HotDogCondiments.LiquidCondiments.Variant.Ketchup
            };

            SolidCondiments = new List<SolidCondiments.Variant>()
            {
                HotDogCondiments.SolidCondiments.Variant.CucumberSalad,
                HotDogCondiments.SolidCondiments.Variant.RoastedOnion
            };
        }
    }
}
