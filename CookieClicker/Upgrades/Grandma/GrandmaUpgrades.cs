using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookieClicker.Buildings;
using Newtonsoft.Json;
using System.IO;

namespace CookieClicker.Upgrades.Grandma
{
    class GrandmaUpgrades
    {
        private bool isContinueClicker;
        private GrandmaBuilding grandmaBuilding;
        public List<Upgrade> allUpgrades;

        private FiveGrandmasUpgrade fiveGrandmasUpgrade;
        private FifteenGrandmasUpgrade fifteenGrandmasUpgrade;
        private TwentyFiveGrandmasUpgrade twentyFiveGrandmasUpgrade;
        private FiftyGrandmasUpgrade fiftyGrandmasUpgrade;
        private SeventyFiveGrandmasUpgrade seventyFiveGrandmasUpgrade;
        private OneHundredGrandmasUpgrade oneHundredGrandmasUpgrade;
        private OneHundredFiftyGrandmasUpgrade oneHundredFiftyGrandmasUpgrade;

        public GrandmaUpgrades(GrandmaBuilding grandmaBuilding, bool isContinueClicker)
        {
            this.isContinueClicker = isContinueClicker;
            this.grandmaBuilding = grandmaBuilding;

            InitializeUpgrades();

            allUpgrades = new List<Upgrade>();

            allUpgrades.Add(fiveGrandmasUpgrade);
            allUpgrades.Add(fifteenGrandmasUpgrade);
            allUpgrades.Add(twentyFiveGrandmasUpgrade);
            allUpgrades.Add(fiftyGrandmasUpgrade);
            allUpgrades.Add(seventyFiveGrandmasUpgrade);
            allUpgrades.Add(oneHundredGrandmasUpgrade);
            allUpgrades.Add(oneHundredFiftyGrandmasUpgrade);
        }

        private void InitializeUpgrades()
        {
            if (!isContinueClicker)
            {
                fiveGrandmasUpgrade = new FiveGrandmasUpgrade(grandmaBuilding, "5 Grandmas Upgrade", 1000.0, false, false);
                fifteenGrandmasUpgrade = new FifteenGrandmasUpgrade(grandmaBuilding, "15 Grandmas Upgrade", 5000.0, false, false);
                twentyFiveGrandmasUpgrade = new TwentyFiveGrandmasUpgrade(grandmaBuilding, "25 Grandmas Upgrade", 50000.0, false, false);
                fiftyGrandmasUpgrade = new FiftyGrandmasUpgrade(grandmaBuilding, "50 Grandmas Upgrade", 5000000.0, false, false);
                seventyFiveGrandmasUpgrade = new SeventyFiveGrandmasUpgrade(grandmaBuilding, "75 Grandmas Upgrade", 500000000.0, false, false);
                oneHundredGrandmasUpgrade = new OneHundredGrandmasUpgrade(grandmaBuilding, "100 Grandmas Upgrade", 50000000000.0, false, false);
                oneHundredFiftyGrandmasUpgrade = new OneHundredFiftyGrandmasUpgrade(grandmaBuilding, "150 Grandmas Upgrade", 500000000000.0, false, false);
            }
            else
            {
                List<List<FiveGrandmasUpgrade>> upgrades = JsonConvert.DeserializeObject<List<List<FiveGrandmasUpgrade>>>(File.ReadAllText(@"upgrades.json"));
                fiveGrandmasUpgrade = new FiveGrandmasUpgrade(grandmaBuilding, "5 Grandmas Upgrade", 1000.0, upgrades[1][0].IsShownIcon, upgrades[1][0].IsBought);
                fifteenGrandmasUpgrade = new FifteenGrandmasUpgrade(grandmaBuilding, "15 Grandmas Upgrade", 5000.0, upgrades[1][1].IsShownIcon, upgrades[1][1].IsBought);
                twentyFiveGrandmasUpgrade = new TwentyFiveGrandmasUpgrade(grandmaBuilding, "25 Grandmas Upgrade", 50000.0, upgrades[1][2].IsShownIcon, upgrades[1][2].IsBought);
                fiftyGrandmasUpgrade = new FiftyGrandmasUpgrade(grandmaBuilding, "50 Grandmas Upgrade", 5000000.0, upgrades[1][3].IsShownIcon, upgrades[1][3].IsBought);
                seventyFiveGrandmasUpgrade = new SeventyFiveGrandmasUpgrade(grandmaBuilding, "75 Grandmas Upgrade", 500000000.0, upgrades[1][4].IsShownIcon, upgrades[1][4].IsBought);
                oneHundredGrandmasUpgrade = new OneHundredGrandmasUpgrade(grandmaBuilding, "100 Grandmas Upgrade", 50000000000.0, upgrades[1][5].IsShownIcon, upgrades[1][5].IsBought);
                oneHundredFiftyGrandmasUpgrade = new OneHundredFiftyGrandmasUpgrade(grandmaBuilding, "150 Grandmas Upgrade", 500000000000.0, upgrades[1][6].IsShownIcon, upgrades[1][6].IsBought);
            }
        }

        public List<Upgrade> GetGrandmaUpgrades()
        {
            return allUpgrades;
        }
    }
}
