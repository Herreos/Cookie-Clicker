using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookieClicker.Upgrades;
using System.Windows.Controls;

namespace CookieClicker.Buildings
{
    public abstract class Building
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Image IconImage { get; set; }
        public int BuildingsQuantity { get; set; }
        public double BuildingValue { get; set; }
        public double Price { get; set; }
        public bool IsContinueClicker { get; set; }

        public Building(int id, string name, int quantity, double value, double price, bool isContinueClicker)
        {
            this.Id = id;
            this.Name = name;
            this.BuildingsQuantity = quantity;
            this.BuildingValue = value;
            this.Price = price;
            this.IsContinueClicker = isContinueClicker;
        }

        public abstract List<Upgrade> GetUpgrades();
    }
}
