using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookieClicker.Upgrades;
using CookieClicker.Upgrades.AtomGenerator;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace CookieClicker.Buildings
{
    class AtomGeneratorBuilding : Building
    {
        private AtomGeneratorUpgrades atomGeneratorUpgrades;
        public AtomGeneratorBuilding(int id, string name, int quantity, double value, double price, bool isContinueClicker) : base(id, name, quantity, value, price, isContinueClicker)
        {
            PrepareIcon();
            atomGeneratorUpgrades = new AtomGeneratorUpgrades(this, isContinueClicker);
        }

        private void PrepareIcon()
        {
            IconImage = new Image();
            IconImage.Source = new BitmapImage(new Uri("/Images/Buildings/AtomGeneratorImage.png", UriKind.Relative));
        }

        public override List<Upgrade> GetUpgrades()
        {
            return atomGeneratorUpgrades.GetAtomGeneratorUpgrades();
        }
    }
}
