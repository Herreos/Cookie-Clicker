using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookieClicker.Upgrades;
using CookieClicker.Upgrades.Prism;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace CookieClicker.Buildings
{
    class PrismBuilding : Building
    {
        private PrismUpgrades prismUpgrades;
        public PrismBuilding(int id, string name, int quantity, double value, double price, bool isContinueClicker) : base(id, name, quantity, value, price, isContinueClicker)
        {
            PrepareIcon();
            prismUpgrades = new PrismUpgrades(this, isContinueClicker);
        }

        private void PrepareIcon()
        {
            IconImage = new Image();
            IconImage.Source = new BitmapImage(new Uri("/Images/Buildings/PrismImage.png", UriKind.Relative));
        }

        public override List<Upgrade> GetUpgrades()
        {
            return prismUpgrades.GetPrismUpgrades();
        }
    }
}
