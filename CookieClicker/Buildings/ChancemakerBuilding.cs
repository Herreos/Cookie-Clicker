using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookieClicker.Upgrades;
using CookieClicker.Upgrades.Chancemaker;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace CookieClicker.Buildings
{
    class ChancemakerBuilding : Building
    {
        private ChancemakerUpgrades chancemakerUpgrades;
        public ChancemakerBuilding(int id, string name, int quantity, double value, double price, bool isContinueClicker) : base(id, name, quantity, value, price, isContinueClicker)
        {
            PrepareIcon();
            chancemakerUpgrades = new ChancemakerUpgrades(this, isContinueClicker);
        }

        private void PrepareIcon()
        {
            IconImage = new Image();
            IconImage.Source = new BitmapImage(new Uri("/Images/Buildings/ChancemakerImage.png", UriKind.Relative));
        }

        public override List<Upgrade> GetUpgrades()
        {
            return chancemakerUpgrades.GetChancemakerUpgrades();
        }
    }
}
