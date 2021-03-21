using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookieClicker.Buildings;
using Newtonsoft.Json;
using System.IO;

namespace CookieClicker.Upgrades.WizardTower
{
    class WizardTowerUpgrades
    {
        private bool isContinueClicker;
        private WizardTowerBuilding wizardTowerBuilding;
        public List<Upgrade> allUpgrades;

        private FiveWizardTowersUpgrade fiveWizardTowersUpgrade;
        private FifteenWizardTowersUpgrade fifteenWizardTowersUpgrade;
        private TwentyFiveWizardTowersUpgrade twentyFiveWizardTowersUpgrade;
        private FiftyWizardTowersUpgrade fiftyWizardTowersUpgrade;
        private SeventyFiveWizardTowersUpgrade seventyFiveWizardTowersUpgrade;
        private OneHundredWizardTowersUpgrade oneHundredWizardTowersUpgrade;
        private OneHundredFiftyWizardTowersUpgrade oneHundredFiftyWizardTowersUpgrade;

        public WizardTowerUpgrades(WizardTowerBuilding wizardTowerBuilding, bool isContinueClicker)
        {
            this.isContinueClicker = isContinueClicker;
            this.wizardTowerBuilding = wizardTowerBuilding;

            InitializeUpgrades();

            allUpgrades = new List<Upgrade>();

            allUpgrades.Add(fiveWizardTowersUpgrade);
            allUpgrades.Add(fifteenWizardTowersUpgrade);
            allUpgrades.Add(twentyFiveWizardTowersUpgrade);
            allUpgrades.Add(fiftyWizardTowersUpgrade);
            allUpgrades.Add(seventyFiveWizardTowersUpgrade);
            allUpgrades.Add(oneHundredWizardTowersUpgrade);
            allUpgrades.Add(oneHundredFiftyWizardTowersUpgrade);
        }

        private void InitializeUpgrades()
        {
            if (!isContinueClicker)
            {
                fiveWizardTowersUpgrade = new FiveWizardTowersUpgrade(wizardTowerBuilding, "5 Wizard Towers Upgrade", 3300000000.0, false, false);
                fifteenWizardTowersUpgrade = new FifteenWizardTowersUpgrade(wizardTowerBuilding, "15 Wizard Towers Upgrade", 16500000000.0, false, false);
                twentyFiveWizardTowersUpgrade = new TwentyFiveWizardTowersUpgrade(wizardTowerBuilding, "25 Wizard Towers Upgrade", 165000000000.0, false, false);
                fiftyWizardTowersUpgrade = new FiftyWizardTowersUpgrade(wizardTowerBuilding, "50 Wizard Towers Upgrade", 1650000000000.0, false, false);
                seventyFiveWizardTowersUpgrade = new SeventyFiveWizardTowersUpgrade(wizardTowerBuilding, "75 Wizard Towers Upgrade", 16500000000000.0, false, false);
                oneHundredWizardTowersUpgrade = new OneHundredWizardTowersUpgrade(wizardTowerBuilding, "100 Wizard Towers Upgrade", 165000000000000.0, false, false);
                oneHundredFiftyWizardTowersUpgrade = new OneHundredFiftyWizardTowersUpgrade(wizardTowerBuilding, "150 Wizard Towers Upgrade", 1650000000000000.0, false, false);
            }
            else
            {
                List<List<FiveWizardTowersUpgrade>> upgrades = JsonConvert.DeserializeObject<List<List<FiveWizardTowersUpgrade>>>(File.ReadAllText(@"upgrades.json"));
                fiveWizardTowersUpgrade = new FiveWizardTowersUpgrade(wizardTowerBuilding, "5 Wizard Towers Upgrade", 3300000000.0, upgrades[7][0].IsShownIcon, upgrades[7][0].IsBought);
                fifteenWizardTowersUpgrade = new FifteenWizardTowersUpgrade(wizardTowerBuilding, "15 Wizard Towers Upgrade", 16500000000.0, upgrades[7][1].IsShownIcon, upgrades[7][1].IsBought);
                twentyFiveWizardTowersUpgrade = new TwentyFiveWizardTowersUpgrade(wizardTowerBuilding, "25 Wizard Towers Upgrade", 165000000000.0, upgrades[7][2].IsShownIcon, upgrades[7][2].IsBought);
                fiftyWizardTowersUpgrade = new FiftyWizardTowersUpgrade(wizardTowerBuilding, "50 Wizard Towers Upgrade", 1650000000000.0, upgrades[7][3].IsShownIcon, upgrades[7][3].IsBought);
                seventyFiveWizardTowersUpgrade = new SeventyFiveWizardTowersUpgrade(wizardTowerBuilding, "75 Wizard Towers Upgrade", 16500000000000.0, upgrades[7][4].IsShownIcon, upgrades[7][4].IsBought);
                oneHundredWizardTowersUpgrade = new OneHundredWizardTowersUpgrade(wizardTowerBuilding, "100 Wizard Towers Upgrade", 165000000000000.0, upgrades[7][5].IsShownIcon, upgrades[7][5].IsBought);
                oneHundredFiftyWizardTowersUpgrade = new OneHundredFiftyWizardTowersUpgrade(wizardTowerBuilding, "150 Wizard Towers Upgrade", 1650000000000000.0, upgrades[7][6].IsShownIcon, upgrades[7][6].IsBought);
            }
        }

        public List<Upgrade> GetWizardTowerUpgrades()
        {
            return allUpgrades;
        }
    }
}
