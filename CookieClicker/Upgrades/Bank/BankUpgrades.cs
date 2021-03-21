using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookieClicker.Buildings;
using Newtonsoft.Json;
using System.IO;

namespace CookieClicker.Upgrades.Bank
{
    class BankUpgrades
    {
        private bool isContinueClicker;
        private BankBuilding bankBuilding;
        public List<Upgrade> allUpgrades;

        private FiveBanksUpgrade fiveFarmsUpgrade;
        private FifteenBanksUpgrade fifteenFarmsUpgrade;
        private TwentyFiveBanksUpgrade twentyFiveFarmsUpgrade;
        private FiftyBanksUpgrade fiftyFarmsUpgrade;
        private SeventyFiveBanksUpgrade seventyFiveFarmsUpgrade;
        private OneHundredBanksUpgrade oneHundredFarmsUpgrade;
        private OneHundredFiftyBanksUpgrade oneHundredFiftyFarmsUpgrade;

        public BankUpgrades(BankBuilding bankBuilding, bool isContinueClicker)
        {
            this.isContinueClicker = isContinueClicker;
            this.bankBuilding = bankBuilding;

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
                fiveFarmsUpgrade = new FiveBanksUpgrade(bankBuilding, "5 Banks Upgrade", 14000000.0, false, false);
                fifteenFarmsUpgrade = new FifteenBanksUpgrade(bankBuilding, "15 Banks Upgrade", 70000000.0, false, false);
                twentyFiveFarmsUpgrade = new TwentyFiveBanksUpgrade(bankBuilding, "25 Banks Upgrade", 7000000000.0, false, false);
                fiftyFarmsUpgrade = new FiftyBanksUpgrade(bankBuilding, "50 Banks Upgrade", 700000000000.0, false, false);
                seventyFiveFarmsUpgrade = new SeventyFiveBanksUpgrade(bankBuilding, "75 Banks Upgrade", 70000000000000.0, false, false);
                oneHundredFarmsUpgrade = new OneHundredBanksUpgrade(bankBuilding, "100 Banks Upgrade", 7000000000000000.0, false, false);
                oneHundredFiftyFarmsUpgrade = new OneHundredFiftyBanksUpgrade(bankBuilding, "150 Banks Upgrade", 700000000000000000.0, false, false);
            }
            else
            {
                List<List<FiveBanksUpgrade>> upgrades = JsonConvert.DeserializeObject<List<List<FiveBanksUpgrade>>>(File.ReadAllText(@"upgrades.json"));
                fiveFarmsUpgrade = new FiveBanksUpgrade(bankBuilding, "5 Banks Upgrade", 14000000.0, upgrades[5][0].IsShownIcon, upgrades[5][0].IsBought);
                fifteenFarmsUpgrade = new FifteenBanksUpgrade(bankBuilding, "15 Banks Upgrade", 70000000.0, upgrades[5][1].IsShownIcon, upgrades[5][1].IsBought);
                twentyFiveFarmsUpgrade = new TwentyFiveBanksUpgrade(bankBuilding, "25 Banks Upgrade", 7000000000.0, upgrades[5][2].IsShownIcon, upgrades[5][2].IsBought);
                fiftyFarmsUpgrade = new FiftyBanksUpgrade(bankBuilding, "50 Banks Upgrade", 700000000000.0, upgrades[5][3].IsShownIcon, upgrades[5][3].IsBought);
                seventyFiveFarmsUpgrade = new SeventyFiveBanksUpgrade(bankBuilding, "75 Banks Upgrade", 70000000000000.0, upgrades[5][4].IsShownIcon, upgrades[5][4].IsBought);
                oneHundredFarmsUpgrade = new OneHundredBanksUpgrade(bankBuilding, "100 Banks Upgrade", 7000000000000000.0, upgrades[5][5].IsShownIcon, upgrades[5][5].IsBought);
                oneHundredFiftyFarmsUpgrade = new OneHundredFiftyBanksUpgrade(bankBuilding, "150 Banks Upgrade", 700000000000000000.0, upgrades[5][6].IsShownIcon, upgrades[5][6].IsBought);
            }
        }

        public List<Upgrade> GetBankUpgrades()
        {
            return allUpgrades;
        }
    }
}
