using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookieClicker.Buildings;
using Newtonsoft.Json;
using System.IO;

namespace CookieClicker.Upgrades.Mine
{
    class MineUpgrades
    {
        private bool isContinueClicker;
        private MineBuilding mineBuilding;
        public List<Upgrade> allUpgrades;

        private FiveMinesUpgrade fiveMinesUpgrade;
        private FifteenMinesUpgrade fifteenMinesUpgrade;
        private TwentyFiveMinesUpgrade twentyFiveMinesUpgrade;
        private FiftyMinesUpgrade fiftyMinesUpgrade;
        private SeventyFiveMinesUpgrade seventyFiveMinesUpgrade;
        private OneHundredMinesUpgrade oneHundredMinesUpgrade;
        private OneHundredFiftyMinesUpgrade oneHundredFiftyMinesUpgrade;

        public MineUpgrades(MineBuilding mineBuilding, bool isContinueClicker)
        {
            this.isContinueClicker = isContinueClicker;
            this.mineBuilding = mineBuilding;

            InitializeUpgrades();

            allUpgrades = new List<Upgrade>();

            allUpgrades.Add(fiveMinesUpgrade);
            allUpgrades.Add(fifteenMinesUpgrade);
            allUpgrades.Add(twentyFiveMinesUpgrade);
            allUpgrades.Add(fiftyMinesUpgrade);
            allUpgrades.Add(seventyFiveMinesUpgrade);
            allUpgrades.Add(oneHundredMinesUpgrade);
            allUpgrades.Add(oneHundredFiftyMinesUpgrade);
        }

        private void InitializeUpgrades()
        {
            if (!isContinueClicker)
            {
                fiveMinesUpgrade = new FiveMinesUpgrade(mineBuilding, "5 Mines Upgrade", 120000.0, false, false);
                fifteenMinesUpgrade = new FifteenMinesUpgrade(mineBuilding, "15 Mines Upgrade", 600000.0, false, false);
                twentyFiveMinesUpgrade = new TwentyFiveMinesUpgrade(mineBuilding, "25 Mines Upgrade", 6000000.0, false, false);
                fiftyMinesUpgrade = new FiftyMinesUpgrade(mineBuilding, "50 Mines Upgrade", 600000000.0, false, false);
                seventyFiveMinesUpgrade = new SeventyFiveMinesUpgrade(mineBuilding, "75 Mines Upgrade", 60000000000.0, false, false);
                oneHundredMinesUpgrade = new OneHundredMinesUpgrade(mineBuilding, "100 Mines Upgrade", 6000000000000.0, false, false);
                oneHundredFiftyMinesUpgrade = new OneHundredFiftyMinesUpgrade(mineBuilding, "150 Mines Upgrade", 600000000000000.0, false, false);
            }
            else
            {
                List<List<FiveMinesUpgrade>> upgrades = JsonConvert.DeserializeObject<List<List<FiveMinesUpgrade>>>(File.ReadAllText(@"upgrades.json"));
                fiveMinesUpgrade = new FiveMinesUpgrade(mineBuilding, "5 Mines Upgrade", 120000.0, upgrades[3][0].IsShownIcon, upgrades[3][0].IsBought);
                fifteenMinesUpgrade = new FifteenMinesUpgrade(mineBuilding, "15 Mines Upgrade", 600000.0, upgrades[3][1].IsShownIcon, upgrades[3][1].IsBought);
                twentyFiveMinesUpgrade = new TwentyFiveMinesUpgrade(mineBuilding, "25 Mines Upgrade", 6000000.0, upgrades[3][2].IsShownIcon, upgrades[3][2].IsBought);
                fiftyMinesUpgrade = new FiftyMinesUpgrade(mineBuilding, "50 Mines Upgrade", 600000000.0, upgrades[3][3].IsShownIcon, upgrades[3][3].IsBought);
                seventyFiveMinesUpgrade = new SeventyFiveMinesUpgrade(mineBuilding, "75 Mines Upgrade", 60000000000.0, upgrades[3][4].IsShownIcon, upgrades[3][4].IsBought);
                oneHundredMinesUpgrade = new OneHundredMinesUpgrade(mineBuilding, "100 Mines Upgrade", 6000000000000.0, upgrades[3][5].IsShownIcon, upgrades[3][5].IsBought);
                oneHundredFiftyMinesUpgrade = new OneHundredFiftyMinesUpgrade(mineBuilding, "150 Mines Upgrade", 600000000000000.0, upgrades[3][6].IsShownIcon, upgrades[3][6].IsBought);
            }
        }

        public List<Upgrade> GetMineUpgrades()
        {
            return allUpgrades;
        }
    }
}
