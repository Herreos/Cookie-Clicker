using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookieClicker.Buildings;
using Newtonsoft.Json;
using System.IO;

namespace CookieClicker.Upgrades.AlchemyLab
{
    class AlchemyLabUpgrades
    {
        private bool isContinueClicker;
        private AlchemyLabBuilding alchemyLabBuilding;
        public List<Upgrade> allUpgrades;

        private FiveAlchemyLabsUpgrade fiveAlchemyLabsUpgrade;
        private FifteenAlchemyLabsUpgrade fifteenAlchemyLabsUpgrade;
        private TwentyFiveAlchemyLabsUpgrade twentyFiveAlchemyLabsUpgrade;
        private FiftyAlchemyLabsUpgrade fiftyAlchemyLabsUpgrade;
        private SeventyFiveAlchemyLabsUpgrade seventyFiveAlchemyLabsUpgrade;
        private OneHundredAlchemyLabsUpgrade oneHundredAlchemyLabsUpgrade;
        private OneHundredFiftyAlchemyLabsUpgrade oneHundredFiftyAlchemyLabsUpgrade;

        public AlchemyLabUpgrades(AlchemyLabBuilding alchemyLabBuilding, bool isContinueClicker)
        {
            this.alchemyLabBuilding = alchemyLabBuilding;
            this.isContinueClicker = isContinueClicker;

            InitializeUpgrades();

            allUpgrades = new List<Upgrade>();
            allUpgrades.Add(fiveAlchemyLabsUpgrade);
            allUpgrades.Add(fifteenAlchemyLabsUpgrade);
            allUpgrades.Add(twentyFiveAlchemyLabsUpgrade);
            allUpgrades.Add(fiftyAlchemyLabsUpgrade);
            allUpgrades.Add(seventyFiveAlchemyLabsUpgrade);
            allUpgrades.Add(oneHundredAlchemyLabsUpgrade);
            allUpgrades.Add(oneHundredFiftyAlchemyLabsUpgrade);
        }

        private void InitializeUpgrades()
        {
            if (!isContinueClicker)
            {
                fiveAlchemyLabsUpgrade = new FiveAlchemyLabsUpgrade(alchemyLabBuilding, "5 Alchemy Labs Upgrade", 750000000000.0, false, false);
                fifteenAlchemyLabsUpgrade = new FifteenAlchemyLabsUpgrade(alchemyLabBuilding, "15 Alchemy Labs Upgrade", 37500000000000.0, false, false);
                twentyFiveAlchemyLabsUpgrade = new TwentyFiveAlchemyLabsUpgrade(alchemyLabBuilding, "25 Alchemy Labs Upgrade", 375000000000000.0, false, false);
                fiftyAlchemyLabsUpgrade = new FiftyAlchemyLabsUpgrade(alchemyLabBuilding, "50 Alchemy Labs Upgrade", 3750000000000000.0, false, false);
                seventyFiveAlchemyLabsUpgrade = new SeventyFiveAlchemyLabsUpgrade(alchemyLabBuilding, "75 Alchemy Labs Upgrade", 37500000000000000.0, false, false);
                oneHundredAlchemyLabsUpgrade = new OneHundredAlchemyLabsUpgrade(alchemyLabBuilding, "100 Alchemy Labs Upgrade", 375000000000000000.0, false, false);
                oneHundredFiftyAlchemyLabsUpgrade = new OneHundredFiftyAlchemyLabsUpgrade(alchemyLabBuilding, "150 Alchemy Labs Upgrade", 3750000000000000000.0, false, false);
            }
            else
            {
                List<List<FiveAlchemyLabsUpgrade>> upgrades = JsonConvert.DeserializeObject<List<List<FiveAlchemyLabsUpgrade>>>(File.ReadAllText(@"upgrades.json"));
                fiveAlchemyLabsUpgrade = new FiveAlchemyLabsUpgrade(alchemyLabBuilding, "5 Alchemy Labs Upgrade", 750000000000.0, upgrades[9][0].IsShownIcon, upgrades[9][0].IsBought);
                fifteenAlchemyLabsUpgrade = new FifteenAlchemyLabsUpgrade(alchemyLabBuilding, "15 Alchemy Labs Upgrade", 37500000000000.0, upgrades[9][1].IsShownIcon, upgrades[9][1].IsBought);
                twentyFiveAlchemyLabsUpgrade = new TwentyFiveAlchemyLabsUpgrade(alchemyLabBuilding, "25 Alchemy Labs Upgrade", 375000000000000.0, upgrades[9][2].IsShownIcon, upgrades[9][2].IsBought);
                fiftyAlchemyLabsUpgrade = new FiftyAlchemyLabsUpgrade(alchemyLabBuilding, "50 Alchemy Labs Upgrade", 3750000000000000.0, upgrades[9][3].IsShownIcon, upgrades[9][3].IsBought);
                seventyFiveAlchemyLabsUpgrade = new SeventyFiveAlchemyLabsUpgrade(alchemyLabBuilding, "75 Alchemy Labs Upgrade", 37500000000000000.0, upgrades[9][4].IsShownIcon, upgrades[9][4].IsBought);
                oneHundredAlchemyLabsUpgrade = new OneHundredAlchemyLabsUpgrade(alchemyLabBuilding, "100 Alchemy Labs Upgrade", 375000000000000000.0, upgrades[9][5].IsShownIcon, upgrades[9][5].IsBought);
                oneHundredFiftyAlchemyLabsUpgrade = new OneHundredFiftyAlchemyLabsUpgrade(alchemyLabBuilding, "150 Alchemy Labs Upgrade", 3750000000000000000.0, upgrades[9][6].IsShownIcon, upgrades[9][6].IsBought);
            }
        }

        public List<Upgrade> GetAlchemyLabUpgrades()
        {
            return allUpgrades;
        }
    }
}
