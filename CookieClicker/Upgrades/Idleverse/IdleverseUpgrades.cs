using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookieClicker.Buildings;
using Newtonsoft.Json;
using System.IO;

namespace CookieClicker.Upgrades.Idleverse
{
    class IdleverseUpgrades
    {
        private bool isContinueClicker;
        private IdleverseBuilding idleverseBuilding;
        public List<Upgrade> allUpgrades;

        private FiveIdleversesUpgrade fiveIdleversesUpgrade;
        private FifteenIdleversesUpgrade fifteenIdleversesUpgrade;
        private TwentyFiveIdleversesUpgrade twentyFiveIdleversesUpgrade;
        private FiftyIdleversesUpgrade fiftyIdleversesUpgrade;
        private SeventyFiveIdleversesUpgrade seventyFiveIdleversesUpgrade;
        private OneHundredIdleversesUpgrade oneHundredIdleversesUpgrade;
        private OneHundredFiftyIdleversesUpgrade oneHundredFiftyIdleversesUpgrade;

        public IdleverseUpgrades(IdleverseBuilding idleverseBuilding, bool isContinueClicker)
        {
            this.isContinueClicker = isContinueClicker;
            this.idleverseBuilding = idleverseBuilding;

            InitializeUpgrades();

            allUpgrades = new List<Upgrade>();

            allUpgrades.Add(fiveIdleversesUpgrade);
            allUpgrades.Add(fifteenIdleversesUpgrade);
            allUpgrades.Add(twentyFiveIdleversesUpgrade);
            allUpgrades.Add(fiftyIdleversesUpgrade);
            allUpgrades.Add(seventyFiveIdleversesUpgrade);
            allUpgrades.Add(oneHundredIdleversesUpgrade);
            allUpgrades.Add(oneHundredFiftyIdleversesUpgrade);
        }

        private void InitializeUpgrades()
        {
            if (!isContinueClicker)
            {
                fiveIdleversesUpgrade = new FiveIdleversesUpgrade(idleverseBuilding, "5 Idleverses Upgrade", 12000000000000000000000.0, false, false);
                fifteenIdleversesUpgrade = new FifteenIdleversesUpgrade(idleverseBuilding, "15 Idleverses Upgrade", 60000000000000000000000.0, false, false);
                twentyFiveIdleversesUpgrade = new TwentyFiveIdleversesUpgrade(idleverseBuilding, "25 Idleverses Upgrade", 600000000000000000000000.0, false, false);
                fiftyIdleversesUpgrade = new FiftyIdleversesUpgrade(idleverseBuilding, "50 Idleverses Upgrade", 6000000000000000000000000.0, false, false);
                seventyFiveIdleversesUpgrade = new SeventyFiveIdleversesUpgrade(idleverseBuilding, "75 Idleverses Upgrade", 60000000000000000000000000.0, false, false);
                oneHundredIdleversesUpgrade = new OneHundredIdleversesUpgrade(idleverseBuilding, "100 Idleverses Upgrade", 600000000000000000000000000.0, false, false);
                oneHundredFiftyIdleversesUpgrade = new OneHundredFiftyIdleversesUpgrade(idleverseBuilding, "150 Idleverses Upgrade", 6000000000000000000000000000.0, false, false);
            }
            else
            {
                List<List<FiveIdleversesUpgrade>> upgrades = JsonConvert.DeserializeObject<List<List<FiveIdleversesUpgrade>>>(File.ReadAllText(@"upgrades.json"));
                fiveIdleversesUpgrade = new FiveIdleversesUpgrade(idleverseBuilding, "5 Idleverses Upgrade", 12000000000000000000000.0, upgrades[17][0].IsShownIcon, upgrades[17][0].IsBought);
                fifteenIdleversesUpgrade = new FifteenIdleversesUpgrade(idleverseBuilding, "15 Idleverses Upgrade", 60000000000000000000000.0, upgrades[17][1].IsShownIcon, upgrades[17][1].IsBought);
                twentyFiveIdleversesUpgrade = new TwentyFiveIdleversesUpgrade(idleverseBuilding, "25 Idleverses Upgrade", 600000000000000000000000.0, upgrades[17][2].IsShownIcon, upgrades[17][2].IsBought);
                fiftyIdleversesUpgrade = new FiftyIdleversesUpgrade(idleverseBuilding, "50 Idleverses Upgrade", 6000000000000000000000000.0, upgrades[17][3].IsShownIcon, upgrades[17][3].IsBought);
                seventyFiveIdleversesUpgrade = new SeventyFiveIdleversesUpgrade(idleverseBuilding, "75 Idleverses Upgrade", 60000000000000000000000000.0, upgrades[17][4].IsShownIcon, upgrades[17][4].IsBought);
                oneHundredIdleversesUpgrade = new OneHundredIdleversesUpgrade(idleverseBuilding, "100 Idleverses Upgrade", 600000000000000000000000000.0, upgrades[17][5].IsShownIcon, upgrades[17][5].IsBought);
                oneHundredFiftyIdleversesUpgrade = new OneHundredFiftyIdleversesUpgrade(idleverseBuilding, "150 Idleverses Upgrade", 6000000000000000000000000000.0, upgrades[17][6].IsShownIcon, upgrades[17][6].IsBought);
            }
        }
       
        public List<Upgrade> GetIdleverseUpgrades()
        {
            return allUpgrades;
        }
    }
}
