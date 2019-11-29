using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WholeWeek.Models
{
    public class Table
    {
        private string _name;
        private bool _occupied = false;

        public string Name { get => _name; }
        public bool Occupied { get => _occupied; set => _occupied = value; }

        public Table(string name)
        {
            _name = name;
        }
    }
}
