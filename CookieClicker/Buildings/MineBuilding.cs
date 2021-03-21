using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookieClicker.Upgrades;
using CookieClicker.Upgrades.Mine;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace CookieClicker.Buildings
{
    public class MineBuilding : Building
    {
        private MineUpgrades mineUpgrades;
        public MineBuilding(int id, string name, int quantity, double value, double price, bool isContinueClicker) : base(id, name, quantity, value, price, isContinueClicker)
        {
            PrepareIcon();
            mineUpgrades = new MineUpgrades(this, isContinueClicker);
        }

        private void PrepareIcon()
        {
            IconImage = new Image();
            IconImage.Source = new BitmapImage(new Uri("/Images/Buildings/MineImage.png", UriKind.Relative));
        }

        public override List<Upgrade> GetUpgrades()
        {
            return mineUpgrades.GetMineUpgrades();
        }
    }
}
