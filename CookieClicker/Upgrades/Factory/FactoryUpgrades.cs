using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookieClicker.Buildings;
using Newtonsoft.Json;
using System.IO;

namespace CookieClicker.Upgrades.Factory
{
    class FactoryUpgrades
    {
        private bool isContinueClicker;
        private FactoryBuilding factoryBuilding;
        public List<Upgrade> allUpgrades;

        private FiveFactoriesUpgrade fiveFactoriesUpgrade;
        private FifteenFactoriesUpgrade fifteenFactoriesUpgrade;
        private TwentyFiveFactoriesUpgrade twentyFiveFactoriesUpgrade;
        private FiftyFactoriesUpgrade fiftyFactoriesUpgrade;
        private SeventyFiveFactoriesUpgrade seventyFiveFactoriesUpgrade;
        private OneHundredFactoriesUpgrade oneHundredFactoriesUpgrade;
        private OneHundredFiftyFactoriesUpgrade oneHundredFiftyFactoriesUpgrade;

        public FactoryUpgrades(FactoryBuilding factoryBuilding, bool isContinueClicker)
        {
            this.isContinueClicker = isContinueClicker;
            this.factoryBuilding = factoryBuilding;

            InitializeUpgrades();

            allUpgrades = new List<Upgrade>();

            allUpgrades.Add(fiveFactoriesUpgrade);
            allUpgrades.Add(fifteenFactoriesUpgrade);
            allUpgrades.Add(twentyFiveFactoriesUpgrade);
            allUpgrades.Add(fiftyFactoriesUpgrade);
            allUpgrades.Add(seventyFiveFactoriesUpgrade);
            allUpgrades.Add(oneHundredFactoriesUpgrade);
            allUpgrades.Add(oneHundredFiftyFactoriesUpgrade);
        }

        private void InitializeUpgrades()
        {
            if (!isContinueClicker)
            {
                fiveFactoriesUpgrade = new FiveFactoriesUpgrade(factoryBuilding, "5 Factories Upgrade", 1300000.0, false, false);
                fifteenFactoriesUpgrade = new FifteenFactoriesUpgrade(factoryBuilding, "15 Factories Upgrade", 6500000.0, false, false);
                twentyFiveFactoriesUpgrade = new TwentyFiveFactoriesUpgrade(factoryBuilding, "25 Factories Upgrade", 65000000.0, false, false);
                fiftyFactoriesUpgrade = new FiftyFactoriesUpgrade(factoryBuilding, "50 Factories Upgrade", 6500000000.0, false, false);
                seventyFiveFactoriesUpgrade = new SeventyFiveFactoriesUpgrade(factoryBuilding, "75 Factories Upgrade", 650000000000.0, false, false);
                oneHundredFactoriesUpgrade = new OneHundredFactoriesUpgrade(factoryBuilding, "100 Factories Upgrade", 65000000000000.0, false, false);
                oneHundredFiftyFactoriesUpgrade = new OneHundredFiftyFactoriesUpgrade(factoryBuilding, "150 Factories Upgrade", 6500000000000000.0, false, false);
            }
            else
            {
                List<List<FiveFactoriesUpgrade>> upgrades = JsonConvert.DeserializeObject<List<List<FiveFactoriesUpgrade>>>(File.ReadAllText(@"upgrades.json"));
                fiveFactoriesUpgrade = new FiveFactoriesUpgrade(factoryBuilding, "5 Factories Upgrade", 1300000.0, upgrades[4][0].IsShownIcon, upgrades[4][0].IsBought);
                fifteenFactoriesUpgrade = new FifteenFactoriesUpgrade(factoryBuilding, "15 Factories Upgrade", 6500000.0, upgrades[4][1].IsShownIcon, upgrades[4][1].IsBought);
                twentyFiveFactoriesUpgrade = new TwentyFiveFactoriesUpgrade(factoryBuilding, "25 Factories Upgrade", 65000000.0, upgrades[4][2].IsShownIcon, upgrades[4][2].IsBought);
                fiftyFactoriesUpgrade = new FiftyFactoriesUpgrade(factoryBuilding, "50 Factories Upgrade", 6500000000.0, upgrades[4][3].IsShownIcon, upgrades[4][3].IsBought);
                seventyFiveFactoriesUpgrade = new SeventyFiveFactoriesUpgrade(factoryBuilding, "75 Factories Upgrade", 650000000000.0, upgrades[4][4].IsShownIcon, upgrades[4][4].IsBought);
                oneHundredFactoriesUpgrade = new OneHundredFactoriesUpgrade(factoryBuilding, "100 Factories Upgrade", 65000000000000.0, upgrades[4][5].IsShownIcon, upgrades[4][5].IsBought);
                oneHundredFiftyFactoriesUpgrade = new OneHundredFiftyFactoriesUpgrade(factoryBuilding, "150 Factories Upgrade", 6500000000000000.0, upgrades[4][6].IsShownIcon, upgrades[4][6].IsBought);
            }
        }

        public List<Upgrade> GetFactoryUpgrades()
        {
            return allUpgrades;
        }
    }
}
