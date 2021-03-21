using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookieClicker.Upgrades;
using CookieClicker.Upgrades.FractalEngine;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace CookieClicker.Buildings
{
    class FractalEngineBuilding : Building
    {
        private FractalEngineUpgrades fractalEngineUpgrades;
        public FractalEngineBuilding(int id, string name, int quantity, double value, double price, bool isContinueClicker) : base(id, name, quantity, value, price, isContinueClicker)
        {
            PrepareIcon();
            fractalEngineUpgrades = new FractalEngineUpgrades(this, isContinueClicker);
        }

        private void PrepareIcon()
        {
            IconImage = new Image();
            IconImage.Source = new BitmapImage(new Uri("/Images/Buildings/FractalEngineImage.png", UriKind.Relative));
        }

        public override List<Upgrade> GetUpgrades()
        {
            return fractalEngineUpgrades.GetFractalEngineUpgrades();
        }
    }
}
