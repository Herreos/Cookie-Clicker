using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CookieClicker.Upgrades
{
    public abstract class Upgrade
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public Button Icon { get; set; }
        public Image IconImage { get; set; }
        public bool IsShownIcon { get; set; }
        public bool IsBought { get; set; }
        public string Description { get; set; }
        public bool IsUpgradeShown { get; set; }

        public Upgrade(string name, double price, bool isShownIcon, bool isBought)
        {
            this.Name = name;
            this.Price = price;
            this.IsShownIcon = isShownIcon;
            this.IsBought = isBought;
        }

        public abstract bool IsAvaliable();
        public abstract Button CreateUpgradeIcon();
    }
}
