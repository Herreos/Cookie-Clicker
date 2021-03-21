using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookieClicker.Upgrades;
using CookieClicker.Upgrades.Grandma;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace CookieClicker.Buildings
{
    public class GrandmaBuilding : Building
    {
        private readonly GrandmaUpgrades grandmaUpgrades;
        public GrandmaBuilding(int id, string name, int quantity, double value, double price, bool isContinueClicker) : base(id, name, quantity, value, price, isContinueClicker)
        {
            PrepareIcon();
            grandmaUpgrades = new GrandmaUpgrades(this, isContinueClicker);
        }

        private void PrepareIcon()
        {
            IconImage = new Image();
            IconImage.Source = new BitmapImage(new Uri("/Images/Buildings/GrandmaImage.png", UriKind.Relative));
        }

        public override List<Upgrade> GetUpgrades()
        {
            return grandmaUpgrades.GetGrandmaUpgrades();
        }
    }
}
