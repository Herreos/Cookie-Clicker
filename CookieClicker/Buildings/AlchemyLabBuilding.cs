using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookieClicker.Upgrades;
using CookieClicker.Upgrades.AlchemyLab;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace CookieClicker.Buildings
{
    class AlchemyLabBuilding : Building
    {
        private AlchemyLabUpgrades alchemyLabUpgrades;
        public AlchemyLabBuilding(int id, string name, int quantity, double value, double price, bool isContinueClicker) : base(id, name, quantity, value, price, isContinueClicker)
        {
            PrepareIcon();
            alchemyLabUpgrades = new AlchemyLabUpgrades(this, isContinueClicker);
        }

        private void PrepareIcon()
        {
            IconImage = new Image();
            IconImage.Source = new BitmapImage(new Uri("/Images/Buildings/AlchemyLabImage.png", UriKind.Relative));
        }

        public override List<Upgrade> GetUpgrades()
        {
            return alchemyLabUpgrades.GetAlchemyLabUpgrades();
        }
    }
}
