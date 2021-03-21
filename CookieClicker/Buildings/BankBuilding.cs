using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookieClicker.Upgrades;
using CookieClicker.Upgrades.Bank;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace CookieClicker.Buildings
{
    class BankBuilding : Building
    {
        private BankUpgrades bankUpgrades;
        public BankBuilding(int id, string name, int quantity, double value, double price, bool isContinueClicker) : base(id, name, quantity, value, price, isContinueClicker)
        {
            PrepareIcon();
            bankUpgrades = new BankUpgrades(this, isContinueClicker);
        }

        private void PrepareIcon()
        {
            IconImage = new Image();
            IconImage.Source = new BitmapImage(new Uri("/Images/Buildings/BankImage.png", UriKind.Relative));
        }

        public override List<Upgrade> GetUpgrades()
        {
            return bankUpgrades.GetBankUpgrades();
        }
    }
}
