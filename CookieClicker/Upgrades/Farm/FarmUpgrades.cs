using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookieClicker.Buildings;
using Newtonsoft.Json;
using System.IO;

namespace CookieClicker.Upgrades.Farm
{
    class FarmUpgrades
    {
        private bool isContinueClicker;
        private FarmBuilding farmBuilding;
        public List<Upgrade> allUpgrades;

        private FiveFarmsUpgrade fiveFarmsUpgrade;
        private FifteenFarmsUpgrade fifteenFarmsUpgrade;
        private TwentyFiveFarmsUpgrade twentyFiveFarmsUpgrade;
        private FiftyFarmsUpgrade fiftyFarmsUpgrade;
        private SeventyFiveFarmsUpgrade seventyFiveFarmsUpgrade;
        private OneHundredFarmsUpgrade oneHundredFarmsUpgrade;
        private OneHundredFiftyFarmsUpgrade oneHundredFiftyFarmsUpgrade;

        public FarmUpgrades(FarmBuilding farmBuilding, bool isContinueClicker)
        {
            this.isContinueClicker = isContinueClicker;
            this.farmBuilding = farmBuilding;

            InitializeUpgrades();

            allUpgrades = new List<Upgrade>();

            allUpgrades.Add(fiveFarmsUpgrade);
            allUpgrades.Add(fifteenFarmsUpgrade);
            allUpgrades.Add(twentyFiveFarmsUpgrade);
            allUpgrades.Add(fiftyFarmsUpgrade);
            allUpgrades.Add(seventyFiveFarmsUpgrade);
            allUpgrades.Add(oneHundredFarmsUpgrade);
            allUpgrades.Add(oneHundredFiftyFarmsUpgrade);
        }

        private void InitializeUpgrades()
        {
            if (!isContinueClicker)
            {
                fiveFarmsUpgrade = new FiveFarmsUpgrade(farmBuilding, "5 Farms Upgrade", 11000.0, false, false);
                fifteenFarmsUpgrade = new FifteenFarmsUpgrade(farmBuilding, "15 Farms Upgrade", 55000.0, false, false);
                twentyFiveFarmsUpgrade = new TwentyFiveFarmsUpgrade(farmBuilding, "25 Farms Upgrade", 550000.0, false, false);
                fiftyFarmsUpgrade = new FiftyFarmsUpgrade(farmBuilding, "50 Farms Upgrade", 55000000.0, false, false);
                seventyFiveFarmsUpgrade = new SeventyFiveFarmsUpgrade(farmBuilding, "75 Farms Upgrade", 5500000000, false, false);
                oneHundredFarmsUpgrade = new OneHundredFarmsUpgrade(farmBuilding, "100 Farms Upgrade", 550000000000.0, false, false);
                oneHundredFiftyFarmsUpgrade = new OneHundredFiftyFarmsUpgrade(farmBuilding, "150 Farms Upgrade", 550000000000000.0, false, false);
            }
            else
            {
                List<List<FiveFarmsUpgrade>> upgrades = JsonConvert.DeserializeObject<List<List<FiveFarmsUpgrade>>>(File.ReadAllText(@"upgrades.json"));
                fiveFarmsUpgrade = new FiveFarmsUpgrade(farmBuilding, "5 Farms Upgrade", 11000.0, upgrades[2][0].IsShownIcon, upgrades[2][0].IsBought);
                fifteenFarmsUpgrade = new FifteenFarmsUpgrade(farmBuilding, "15 Farms Upgrade", 55000.0, upgrades[2][1].IsShownIcon, upgrades[2][1].IsBought);
                twentyFiveFarmsUpgrade = new TwentyFiveFarmsUpgrade(farmBuilding, "25 Farms Upgrade", 550000.0, upgrades[2][2].IsShownIcon, upgrades[2][2].IsBought);
                fiftyFarmsUpgrade = new FiftyFarmsUpgrade(farmBuilding, "50 Farms Upgrade", 55000000.0, upgrades[2][3].IsShownIcon, upgrades[2][3].IsBought);
                seventyFiveFarmsUpgrade = new SeventyFiveFarmsUpgrade(farmBuilding, "75 Farms Upgrade", 5500000000, upgrades[2][4].IsShownIcon, upgrades[2][4].IsBought);
                oneHundredFarmsUpgrade = new OneHundredFarmsUpgrade(farmBuilding, "100 Farms Upgrade", 550000000000.0, upgrades[2][5].IsShownIcon, upgrades[2][5].IsBought);
                oneHundredFiftyFarmsUpgrade = new OneHundredFiftyFarmsUpgrade(farmBuilding, "150 Farms Upgrade", 550000000000000.0, upgrades[2][6].IsShownIcon, upgrades[2][6].IsBought);
            }
        }

        public List<Upgrade> GetFarmUpgrades()
        {
            return allUpgrades;
        }
    }
}
