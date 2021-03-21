using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookieClicker.Upgrades;
using CookieClicker.Upgrades.Factory;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace CookieClicker.Buildings
{
    class FactoryBuilding : Building
    {
        private FactoryUpgrades factoryUpgrades;
        public FactoryBuilding(int id, string name, int quantity, double value, double price, bool isContinueClicker) : base(id, name, quantity, value, price, isContinueClicker)
        {
            PrepareIcon();
            factoryUpgrades = new FactoryUpgrades(this, isContinueClicker);
        }

        private void PrepareIcon()
        {
            IconImage = new Image();
            IconImage.Source = new BitmapImage(new Uri("/Images/Buildings/FactoryImage.png", UriKind.Relative));
        }

        public override List<Upgrade> GetUpgrades()
        {
            return factoryUpgrades.GetFactoryUpgrades();
        }
    }
}
