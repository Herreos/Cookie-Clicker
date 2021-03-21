using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookieClicker.Buildings;
using Newtonsoft.Json;
using System.IO;

namespace CookieClicker.Upgrades.Prism
{
    class PrismUpgrades
    {
        private bool isContinueClicker;
        private PrismBuilding prismBuilding;
        public List<Upgrade> allUpgrades;

        private FivePrismsUpgrade fivePrismsUpgrade;
        private FifteenPrismsUpgrade fifteenPrismsUpgrade;
        private TwentyFivePrismsUpgrade twentyFivePrismsUpgrade;
        private FiftyPrismsUpgrade fiftyPrismsUpgrade;
        private SeventyFivePrismsUpgrade seventyFivePrismsUpgrade;
        private OneHundredPrismsUpgrade oneHundredPrismsUpgrade;
        private OneHundredFiftyPrismsUpgrade oneHundredFiftyPrismsUpgrade;

        public PrismUpgrades(PrismBuilding prismBuilding, bool isContinueClicker)
        {
            this.isContinueClicker = isContinueClicker;
            this.prismBuilding = prismBuilding;

            InitializeUpgrades();

            allUpgrades = new List<Upgrade>();

            allUpgrades.Add(fivePrismsUpgrade);
            allUpgrades.Add(fifteenPrismsUpgrade);
            allUpgrades.Add(twentyFivePrismsUpgrade);
            allUpgrades.Add(fiftyPrismsUpgrade);
            allUpgrades.Add(seventyFivePrismsUpgrade);
            allUpgrades.Add(oneHundredPrismsUpgrade);
            allUpgrades.Add(oneHundredFiftyPrismsUpgrade);
        }

        private void InitializeUpgrades()
        {
            if (!isContinueClicker)
            {
                fivePrismsUpgrade = new FivePrismsUpgrade(prismBuilding, "5 Prisms Upgrade", 21000000000000000.0, false, false);
                fifteenPrismsUpgrade = new FifteenPrismsUpgrade(prismBuilding, "15 Prisms Upgrade", 105000000000000000.0, false, false);
                twentyFivePrismsUpgrade = new TwentyFivePrismsUpgrade(prismBuilding, "25 Prisms Upgrade", 1050000000000000000.0, false, false);
                fiftyPrismsUpgrade = new FiftyPrismsUpgrade(prismBuilding, "50 Prisms Upgrade", 10500000000000000000.0, false, false);
                seventyFivePrismsUpgrade = new SeventyFivePrismsUpgrade(prismBuilding, "75 Prisms Upgrade", 105000000000000000000.0, false, false);
                oneHundredPrismsUpgrade = new OneHundredPrismsUpgrade(prismBuilding, "100 Prisms Upgrade", 1050000000000000000000.0, false, false);
                oneHundredFiftyPrismsUpgrade = new OneHundredFiftyPrismsUpgrade(prismBuilding, "150 Prisms Upgrade", 10500000000000000000000.0, false, false);
            }
            else
            {
                List<List<FivePrismsUpgrade>> upgrades = JsonConvert.DeserializeObject<List<List<FivePrismsUpgrade>>>(File.ReadAllText(@"upgrades.json"));
                fivePrismsUpgrade = new FivePrismsUpgrade(prismBuilding, "5 Prisms Upgrade", 21000000000000000.0, upgrades[13][0].IsShownIcon, upgrades[13][0].IsBought);
                fifteenPrismsUpgrade = new FifteenPrismsUpgrade(prismBuilding, "15 Prisms Upgrade", 105000000000000000.0, upgrades[13][1].IsShownIcon, upgrades[13][1].IsBought);
                twentyFivePrismsUpgrade = new TwentyFivePrismsUpgrade(prismBuilding, "25 Prisms Upgrade", 1050000000000000000.0, upgrades[13][2].IsShownIcon, upgrades[13][2].IsBought);
                fiftyPrismsUpgrade = new FiftyPrismsUpgrade(prismBuilding, "50 Prisms Upgrade", 10500000000000000000.0, upgrades[13][3].IsShownIcon, upgrades[13][3].IsBought);
                seventyFivePrismsUpgrade = new SeventyFivePrismsUpgrade(prismBuilding, "75 Prisms Upgrade", 105000000000000000000.0, upgrades[13][4].IsShownIcon, upgrades[13][4].IsBought);
                oneHundredPrismsUpgrade = new OneHundredPrismsUpgrade(prismBuilding, "100 Prisms Upgrade", 1050000000000000000000.0, upgrades[13][5].IsShownIcon, upgrades[13][5].IsBought);
                oneHundredFiftyPrismsUpgrade = new OneHundredFiftyPrismsUpgrade(prismBuilding, "150 Prisms Upgrade", 10500000000000000000000.0, upgrades[13][6].IsShownIcon, upgrades[13][6].IsBought);
            }
        }

        public List<Upgrade> GetPrismUpgrades()
        {
            return allUpgrades;
        }
    }
}
