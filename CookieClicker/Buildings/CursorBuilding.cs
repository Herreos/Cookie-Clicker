using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookieClicker.Upgrades;
using CookieClicker.Upgrades.Cursor;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace CookieClicker.Buildings
{
    public class CursorBuilding : Building
    {
        private readonly CursorUpgrades cursorUpgrades;
        public CursorBuilding(int id, string name, int quantity, double value, double price, bool isContinueClicker) : base(id, name, quantity, value, price, isContinueClicker)
        {
            PrepareIcon();
            cursorUpgrades = new CursorUpgrades(this, isContinueClicker);
        }
        private void PrepareIcon()
        {
            IconImage = new Image();
            IconImage.Source = new BitmapImage(new Uri("/Images/Buildings/CursorImage.png", UriKind.Relative));
        }

        public override List<Upgrade> GetUpgrades()
        {
            return cursorUpgrades.GetCursorUpgrades();
        }
    }
}
