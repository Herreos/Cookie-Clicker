using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookieClicker.Upgrades;
using CookieClicker.Upgrades.TimeMachine;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace CookieClicker.Buildings
{
    class TimeMachineBuilding : Building
    {
        private TimeMachineUpgrades timeMachineUpgrades;
        public TimeMachineBuilding(int id, string name, int quantity, double value, double price, bool isContinueClicker) : base(id, name, quantity, value, price, isContinueClicker)
        {
            PrepareIcon();
            timeMachineUpgrades = new TimeMachineUpgrades(this, isContinueClicker);
        }

        private void PrepareIcon()
        {
            IconImage = new Image();
            IconImage.Source = new BitmapImage(new Uri("/Images/Buildings/TimeMachineImage.png", UriKind.Relative));
        }

        public override List<Upgrade> GetUpgrades()
        {
            return timeMachineUpgrades.GetTimeMachineUpgrades();
        }
    }
}
