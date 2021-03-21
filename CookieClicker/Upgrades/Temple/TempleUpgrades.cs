using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookieClicker.Buildings;
using Newtonsoft.Json;
using System.IO;

namespace CookieClicker.Upgrades.Temple
{
    class TempleUpgrades
    {
        private bool isContinueClicker;
        private TempleBuilding templeBuilding;
        public List<Upgrade> allUpgrades;

        private FiveTemplesUpgrade fiveTemplesUpgrade;
        private FifteenTemplesUpgrade fifteenTemplesUpgrade;
        private TwentyFiveTemplesUpgrade twentyFiveTemplesUpgrade;
        private FiftyTemplesUpgrade fiftyTemplesUpgrade;
        private SeventyFiveTemplesUpgrade seventyFiveTemplesUpgrade;
        private OneHundredTemplesUpgrade oneHundredTemplesUpgrade;
        private OneHundredFiftyTemplesUpgrade oneHundredFiftyTemplesUpgrade;

        public TempleUpgrades(TempleBuilding templeBuilding, bool isContinueClicker)
        {
            this.isContinueClicker = isContinueClicker;
            this.templeBuilding = templeBuilding;

            InitializeUpgrades();

            allUpgrades = new List<Upgrade>();

            allUpgrades.Add(fiveTemplesUpgrade);
            allUpgrades.Add(fifteenTemplesUpgrade);
            allUpgrades.Add(twentyFiveTemplesUpgrade);
            allUpgrades.Add(fiftyTemplesUpgrade);
            allUpgrades.Add(seventyFiveTemplesUpgrade);
            allUpgrades.Add(oneHundredTemplesUpgrade);
            allUpgrades.Add(oneHundredFiftyTemplesUpgrade);
        }

        private void InitializeUpgrades()
        {
            if (!isContinueClicker)
            {
                fiveTemplesUpgrade = new FiveTemplesUpgrade(templeBuilding, "5 Temples Upgrade", 200000000.0, false, false);
                fifteenTemplesUpgrade = new FifteenTemplesUpgrade(templeBuilding, "15 Temples Upgrade", 1000000000.0, false, false);
                twentyFiveTemplesUpgrade = new TwentyFiveTemplesUpgrade(templeBuilding, "25 Temples Upgrade", 100000000000.0, false, false);
                fiftyTemplesUpgrade = new FiftyTemplesUpgrade(templeBuilding, "50 Temples Upgrade", 10000000000000.0, false, false);
                seventyFiveTemplesUpgrade = new SeventyFiveTemplesUpgrade(templeBuilding, "75 Temples Upgrade", 1000000000000000.0, false, false);
                oneHundredTemplesUpgrade = new OneHundredTemplesUpgrade(templeBuilding, "100 Temples Upgrade", 100000000000000000.0, false, false);
                oneHundredFiftyTemplesUpgrade = new OneHundredFiftyTemplesUpgrade(templeBuilding, "150 Temples Upgrade", 10000000000000000000.0, false, false);
            }
            else
            {
                List<List<FiveTemplesUpgrade>> upgrades = JsonConvert.DeserializeObject<List<List<FiveTemplesUpgrade>>>(File.ReadAllText(@"upgrades.json"));
                fiveTemplesUpgrade = new FiveTemplesUpgrade(templeBuilding, "5 Temples Upgrade", 200000000.0, upgrades[6][0].IsShownIcon, upgrades[6][0].IsBought);
                fifteenTemplesUpgrade = new FifteenTemplesUpgrade(templeBuilding, "15 Temples Upgrade", 1000000000.0, upgrades[6][1].IsShownIcon, upgrades[6][1].IsBought);
                twentyFiveTemplesUpgrade = new TwentyFiveTemplesUpgrade(templeBuilding, "25 Temples Upgrade", 100000000000.0, upgrades[6][2].IsShownIcon, upgrades[6][2].IsBought);
                fiftyTemplesUpgrade = new FiftyTemplesUpgrade(templeBuilding, "50 Temples Upgrade", 10000000000000.0, upgrades[6][3].IsShownIcon, upgrades[6][3].IsBought);
                seventyFiveTemplesUpgrade = new SeventyFiveTemplesUpgrade(templeBuilding, "75 Temples Upgrade", 1000000000000000.0, upgrades[6][4].IsShownIcon, upgrades[6][4].IsBought);
                oneHundredTemplesUpgrade = new OneHundredTemplesUpgrade(templeBuilding, "100 Temples Upgrade", 100000000000000000.0, upgrades[6][5].IsShownIcon, upgrades[6][5].IsBought);
                oneHundredFiftyTemplesUpgrade = new OneHundredFiftyTemplesUpgrade(templeBuilding, "150 Temples Upgrade", 10000000000000000000.0, upgrades[6][6].IsShownIcon, upgrades[6][6].IsBought);
            }
        }

        public List<Upgrade> GetTempleUpgrades()
        {
            return allUpgrades;
        }
    }
}
