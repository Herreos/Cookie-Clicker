using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookieClicker.Upgrades;
using CookieClicker.Upgrades.Idleverse;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace CookieClicker.Buildings
{
    class IdleverseBuilding : Building
    {
        private IdleverseUpgrades idleverseUpgrades;
        public IdleverseBuilding(int id, string name, int quantity, double value, double price, bool isContinueClicker) : base(id, name, quantity, value, price, isContinueClicker)
        {
            PrepareIcon();
            idleverseUpgrades = new IdleverseUpgrades(this, isContinueClicker);
        }

        private void PrepareIcon()
        {
            IconImage = new Image();
            IconImage.Source = new BitmapImage(new Uri("/Images/Buildings/IdleverseImage.png", UriKind.Relative));
        }

        public override List<Upgrade> GetUpgrades()
        {
            return idleverseUpgrades.GetIdleverseUpgrades();
        }
    }
}
