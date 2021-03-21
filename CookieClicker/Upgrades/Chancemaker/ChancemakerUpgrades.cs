using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookieClicker.Buildings;
using Newtonsoft.Json;
using System.IO;

namespace CookieClicker.Upgrades.Chancemaker
{
    class ChancemakerUpgrades
    {
        private bool isContinueClicker;
        private ChancemakerBuilding chancemakerBuilding;
        public List<Upgrade> allUpgrades;

        private FiveChancemakersUpgrade fiveChancemakersUpgrade;
        private FifteenChancemakersUpgrade fifteenChancemakersUpgrade;
        private TwentyFiveChancemakersUpgrade twentyFiveChancemakersUpgrade;
        private FiftyChancemakersUpgrade fiftyChancemakersUpgrade;
        private SeventyFiveChancemakersUpgrade seventyFiveChancemakersUpgrade;
        private OneHundredChancemakersUpgrade oneHundredChancemakersUpgrade;
        private OneHundredFiftyChancemakersUpgrade oneHundredFiftyChancemakersUpgrade;

        public ChancemakerUpgrades(ChancemakerBuilding chancemakerBuilding, bool isContinueClicker)
        {
            this.isContinueClicker = isContinueClicker;
            this.chancemakerBuilding = chancemakerBuilding;

            InitializeUpgrades();

            allUpgrades = new List<Upgrade>();

            allUpgrades.Add(fiveChancemakersUpgrade);
            allUpgrades.Add(fifteenChancemakersUpgrade);
            allUpgrades.Add(twentyFiveChancemakersUpgrade);
            allUpgrades.Add(fiftyChancemakersUpgrade);
            allUpgrades.Add(seventyFiveChancemakersUpgrade);
            allUpgrades.Add(oneHundredChancemakersUpgrade);
            allUpgrades.Add(oneHundredFiftyChancemakersUpgrade);
        }

        private void InitializeUpgrades()
        {
            if (!isContinueClicker)
            {
                fiveChancemakersUpgrade = new FiveChancemakersUpgrade(chancemakerBuilding, "5 Chancemakers Upgrade", 260000000000000000.0, false, false);
                fifteenChancemakersUpgrade = new FifteenChancemakersUpgrade(chancemakerBuilding, "15 Chancemakers Upgrade", 1300000000000000000.0, false, false);
                twentyFiveChancemakersUpgrade = new TwentyFiveChancemakersUpgrade(chancemakerBuilding, "25 Chancemakers Upgrade", 13000000000000000000.0, false, false);
                fiftyChancemakersUpgrade = new FiftyChancemakersUpgrade(chancemakerBuilding, "50 Chancemakers Upgrade", 130000000000000000000.0, false, false);
                seventyFiveChancemakersUpgrade = new SeventyFiveChancemakersUpgrade(chancemakerBuilding, "75 Chancemakers Upgrade", 1300000000000000000000.0, false, false);
                oneHundredChancemakersUpgrade = new OneHundredChancemakersUpgrade(chancemakerBuilding, "100 Chancemakers Upgrade", 13000000000000000000000.0, false, false);
                oneHundredFiftyChancemakersUpgrade = new OneHundredFiftyChancemakersUpgrade(chancemakerBuilding, "150 Chancemakers Upgrade", 130000000000000000000000.0, false, false);
            }
            else
            {
                List<List<FiveChancemakersUpgrade>> upgrades = JsonConvert.DeserializeObject<List<List<FiveChancemakersUpgrade>>>(File.ReadAllText(@"upgrades.json"));
                fiveChancemakersUpgrade = new FiveChancemakersUpgrade(chancemakerBuilding, "5 Chancemakers Upgrade", 260000000000000000.0, upgrades[14][0].IsShownIcon, upgrades[14][0].IsBought);
                fifteenChancemakersUpgrade = new FifteenChancemakersUpgrade(chancemakerBuilding, "15 Chancemakers Upgrade", 1300000000000000000.0, upgrades[14][1].IsShownIcon, upgrades[14][1].IsBought);
                twentyFiveChancemakersUpgrade = new TwentyFiveChancemakersUpgrade(chancemakerBuilding, "25 Chancemakers Upgrade", 13000000000000000000.0, upgrades[14][2].IsShownIcon, upgrades[14][2].IsBought);
                fiftyChancemakersUpgrade = new FiftyChancemakersUpgrade(chancemakerBuilding, "50 Chancemakers Upgrade", 130000000000000000000.0, upgrades[14][3].IsShownIcon, upgrades[14][3].IsBought);
                seventyFiveChancemakersUpgrade = new SeventyFiveChancemakersUpgrade(chancemakerBuilding, "75 Chancemakers Upgrade", 1300000000000000000000.0, upgrades[14][4].IsShownIcon, upgrades[14][4].IsBought);
                oneHundredChancemakersUpgrade = new OneHundredChancemakersUpgrade(chancemakerBuilding, "100 Chancemakers Upgrade", 13000000000000000000000.0, upgrades[14][5].IsShownIcon, upgrades[14][5].IsBought);
                oneHundredFiftyChancemakersUpgrade = new OneHundredFiftyChancemakersUpgrade(chancemakerBuilding, "150 Chancemakers Upgrade", 130000000000000000000000.0, upgrades[14][6].IsShownIcon, upgrades[14][6].IsBought);
            }
        }

        public List<Upgrade> GetChancemakerUpgrades()
        {
            return allUpgrades;
        }
    }
}
