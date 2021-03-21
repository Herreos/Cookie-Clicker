using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookieClicker.Buildings;
using Newtonsoft.Json;
using System.IO;

namespace CookieClicker.Upgrades.Portal
{
    class PortalUpgrades
    {
        private bool isContinueClicker;
        private PortalBuilding portalBuilding;
        public List<Upgrade> allUpgrades;

        private FivePortalsUpgrade fivePortalsUpgrade;
        private FifteenPortalsUpgrade fifteenPortalsUpgrade;
        private TwentyFivePortalsUpgrade twentyFivePortalsUpgrade;
        private FiftyPortalsUpgrade fiftyPortalsUpgrade;
        private SeventyFivePortalsUpgrade seventyFivePortalsUpgrade;
        private OneHundredPortalsUpgrade oneHundredPortalsUpgrade;
        private OneHundredFiftyPortalsUpgrade oneHundredFiftyPortalsUpgrade;

        public PortalUpgrades(PortalBuilding portalBuilding, bool isContinueClicker)
        {
            this.isContinueClicker = isContinueClicker;
            this.portalBuilding = portalBuilding;

            InitializeUpgrades();

            allUpgrades = new List<Upgrade>();

            allUpgrades.Add(fivePortalsUpgrade);
            allUpgrades.Add(fifteenPortalsUpgrade);
            allUpgrades.Add(twentyFivePortalsUpgrade);
            allUpgrades.Add(fiftyPortalsUpgrade);
            allUpgrades.Add(seventyFivePortalsUpgrade);
            allUpgrades.Add(oneHundredPortalsUpgrade);
            allUpgrades.Add(oneHundredFiftyPortalsUpgrade);
        }

        private void InitializeUpgrades()
        {
            if (!isContinueClicker)
            {
                fivePortalsUpgrade = new FivePortalsUpgrade(portalBuilding, "5 Portals Upgrade", 10000000000000.0, false, false);
                fifteenPortalsUpgrade = new FifteenPortalsUpgrade(portalBuilding, "15 Portals Upgrade", 50000000000000.0, false, false);
                twentyFivePortalsUpgrade = new TwentyFivePortalsUpgrade(portalBuilding, "25 Portals Upgrade", 500000000000000.0, false, false);
                fiftyPortalsUpgrade = new FiftyPortalsUpgrade(portalBuilding, "50 Portals Upgrade", 5000000000000000.0, false, false);
                seventyFivePortalsUpgrade = new SeventyFivePortalsUpgrade(portalBuilding, "75 Portals Upgrade", 50000000000000000.0, false, false);
                oneHundredPortalsUpgrade = new OneHundredPortalsUpgrade(portalBuilding, "100 Portals Upgrade", 500000000000000000.0, false, false);
                oneHundredFiftyPortalsUpgrade = new OneHundredFiftyPortalsUpgrade(portalBuilding, "150 Portals Upgrade", 5000000000000000000.0, false, false);
            }
            else
            {
                List<List<FivePortalsUpgrade>> upgrades = JsonConvert.DeserializeObject<List<List<FivePortalsUpgrade>>>(File.ReadAllText(@"upgrades.json"));
                fivePortalsUpgrade = new FivePortalsUpgrade(portalBuilding, "5 Portals Upgrade", 10000000000000.0, upgrades[10][0].IsShownIcon, upgrades[10][0].IsBought);
                fifteenPortalsUpgrade = new FifteenPortalsUpgrade(portalBuilding, "15 Portals Upgrade", 50000000000000.0, upgrades[10][1].IsShownIcon, upgrades[10][1].IsBought);
                twentyFivePortalsUpgrade = new TwentyFivePortalsUpgrade(portalBuilding, "25 Portals Upgrade", 500000000000000.0, upgrades[10][2].IsShownIcon, upgrades[10][2].IsBought);
                fiftyPortalsUpgrade = new FiftyPortalsUpgrade(portalBuilding, "50 Portals Upgrade", 5000000000000000.0, upgrades[10][3].IsShownIcon, upgrades[10][3].IsBought);
                seventyFivePortalsUpgrade = new SeventyFivePortalsUpgrade(portalBuilding, "75 Portals Upgrade", 50000000000000000.0, upgrades[10][4].IsShownIcon, upgrades[10][4].IsBought);
                oneHundredPortalsUpgrade = new OneHundredPortalsUpgrade(portalBuilding, "100 Portals Upgrade", 500000000000000000.0, upgrades[10][5].IsShownIcon, upgrades[10][5].IsBought);
                oneHundredFiftyPortalsUpgrade = new OneHundredFiftyPortalsUpgrade(portalBuilding, "150 Portals Upgrade", 5000000000000000000.0, upgrades[10][6].IsShownIcon, upgrades[10][6].IsBought);
            }
        }

        public List<Upgrade> GetPortalUpgrades()
        {
            return allUpgrades;
        }
    }
}
