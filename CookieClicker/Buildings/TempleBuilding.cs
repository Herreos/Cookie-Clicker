using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookieClicker.Upgrades;
using CookieClicker.Upgrades.Temple;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace CookieClicker.Buildings
{
    class TempleBuilding : Building
    {
        private TempleUpgrades templeUpgrades;
        public TempleBuilding(int id, string name, int quantity, double value, double price, bool isContinueClicker) : base(id, name, quantity, value, price, isContinueClicker)
        {
            PrepareIcon();
            templeUpgrades = new TempleUpgrades(this, isContinueClicker);
        }

        private void PrepareIcon()
        {
            IconImage = new Image();
            IconImage.Source = new BitmapImage(new Uri("/Images/Buildings/TempleImage.png", UriKind.Relative));
        }

        public override List<Upgrade> GetUpgrades()
        {
            return templeUpgrades.GetTempleUpgrades();
        }
    }
}
