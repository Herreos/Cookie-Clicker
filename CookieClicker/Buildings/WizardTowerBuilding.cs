using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookieClicker.Upgrades;
using CookieClicker.Upgrades.WizardTower;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace CookieClicker.Buildings
{
    class WizardTowerBuilding : Building
    {
        private WizardTowerUpgrades wizardTowerUpgrades;
        public WizardTowerBuilding(int id, string name, int quantity, double value, double price, bool isContinueClicker) : base(id, name, quantity, value, price, isContinueClicker)
        {
            PrepareIcon();
            wizardTowerUpgrades = new WizardTowerUpgrades(this, isContinueClicker);
        }

        private void PrepareIcon()
        {
            IconImage = new Image();
            IconImage.Source = new BitmapImage(new Uri("/Images/Buildings/WizardTowerImage.png", UriKind.Relative));
        }

        public override List<Upgrade> GetUpgrades()
        {
            return wizardTowerUpgrades.GetWizardTowerUpgrades();
        }
    }
}
