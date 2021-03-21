using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookieClicker.Upgrades;
using CookieClicker.Upgrades.CSharpConsole;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace CookieClicker.Buildings
{
    class CSharpConsoleBuilding : Building
    {
        private CSharpConsoleUpgrades cSharpConsoleUpgrades;
        public CSharpConsoleBuilding(int id, string name, int quantity, double value, double price, bool isContinueClicker) : base(id, name, quantity, value, price, isContinueClicker)
        {
            PrepareIcon();
            cSharpConsoleUpgrades = new CSharpConsoleUpgrades(this, isContinueClicker);
        }

        private void PrepareIcon()
        {
            IconImage = new Image();
            IconImage.Source = new BitmapImage(new Uri("/Images/Buildings/CSharpConsoleImage.png", UriKind.Relative));
        }

        public override List<Upgrade> GetUpgrades()
        {
            return cSharpConsoleUpgrades.GetCSharpConsoleUpgrades();
        }
    }
}
