using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookieClicker.Buildings;
using Newtonsoft.Json;
using System.IO;

namespace CookieClicker.Upgrades.TimeMachine
{
    class TimeMachineUpgrades
    {
        private bool isContinueClicker;
        private TimeMachineBuilding timeMachineBuilding;
        public List<Upgrade> allUpgrades;

        private FiveTimeMachinesUpgrade fiveTimeMachinesUpgrade;
        private FifteenTimeMachinesUpgrade fifteenTimeMachinesUpgrade;
        private TwentyFiveTimeMachinesUpgrade twentyFiveTimeMachinesUpgrade;
        private FiftyTimeMachinesUpgrade fiftyTimeMachinesUpgrade;
        private SeventyFiveTimeMachinesUpgrade seventyFiveTimeMachinesUpgrade;
        private OneHundredTimeMachinesUpgrade oneHundredTimeMachinesUpgrade;
        private OneHundredFiftyTimeMachinesUpgrade oneHundredFiftyTimeMachinesUpgrade;

        public TimeMachineUpgrades(TimeMachineBuilding timeMachineBuilding, bool isContinueClicker)
        {
            this.isContinueClicker = isContinueClicker;
            this.timeMachineBuilding = timeMachineBuilding;

            InitializeUpgrades();

            allUpgrades = new List<Upgrade>();

            allUpgrades.Add(fiveTimeMachinesUpgrade);
            allUpgrades.Add(fifteenTimeMachinesUpgrade);
            allUpgrades.Add(twentyFiveTimeMachinesUpgrade);
            allUpgrades.Add(fiftyTimeMachinesUpgrade);
            allUpgrades.Add(seventyFiveTimeMachinesUpgrade);
            allUpgrades.Add(oneHundredTimeMachinesUpgrade);
            allUpgrades.Add(oneHundredFiftyTimeMachinesUpgrade);
        }

        private void InitializeUpgrades()
        {
            if (!isContinueClicker)
            {
                fiveTimeMachinesUpgrade = new FiveTimeMachinesUpgrade(timeMachineBuilding, "5 Time Machines Upgrade", 140000000000000.0, false, false);
                fifteenTimeMachinesUpgrade = new FifteenTimeMachinesUpgrade(timeMachineBuilding, "15 Time Machines Upgrade", 700000000000000.0, false, false);
                twentyFiveTimeMachinesUpgrade = new TwentyFiveTimeMachinesUpgrade(timeMachineBuilding, "25 Time Machines Upgrade", 7000000000000000.0, false, false);
                fiftyTimeMachinesUpgrade = new FiftyTimeMachinesUpgrade(timeMachineBuilding, "50 Time Machines Upgrade", 70000000000000000.0, false, false);
                seventyFiveTimeMachinesUpgrade = new SeventyFiveTimeMachinesUpgrade(timeMachineBuilding, "75 Time Machines Upgrade", 700000000000000000.0, false, false);
                oneHundredTimeMachinesUpgrade = new OneHundredTimeMachinesUpgrade(timeMachineBuilding, "100 Time Machines Upgrade", 7000000000000000000.0, false, false);
                oneHundredFiftyTimeMachinesUpgrade = new OneHundredFiftyTimeMachinesUpgrade(timeMachineBuilding, "150 Time Machines Upgrade", 70000000000000000000.0, false, false);
            }
            else
            {
                List<List<FiveTimeMachinesUpgrade>> upgrades = JsonConvert.DeserializeObject<List<List<FiveTimeMachinesUpgrade>>>(File.ReadAllText(@"upgrades.json"));
                fiveTimeMachinesUpgrade = new FiveTimeMachinesUpgrade(timeMachineBuilding, "5 Time Machines Upgrade", 140000000000000.0, upgrades[11][0].IsShownIcon, upgrades[11][0].IsBought);
                fifteenTimeMachinesUpgrade = new FifteenTimeMachinesUpgrade(timeMachineBuilding, "15 Time Machines Upgrade", 700000000000000.0, upgrades[11][1].IsShownIcon, upgrades[11][1].IsBought);
                twentyFiveTimeMachinesUpgrade = new TwentyFiveTimeMachinesUpgrade(timeMachineBuilding, "25 Time Machines Upgrade", 7000000000000000.0, upgrades[11][2].IsShownIcon, upgrades[11][2].IsBought);
                fiftyTimeMachinesUpgrade = new FiftyTimeMachinesUpgrade(timeMachineBuilding, "50 Time Machines Upgrade", 70000000000000000.0, upgrades[11][3].IsShownIcon, upgrades[11][3].IsBought);
                seventyFiveTimeMachinesUpgrade = new SeventyFiveTimeMachinesUpgrade(timeMachineBuilding, "75 Time Machines Upgrade", 700000000000000000.0, upgrades[11][4].IsShownIcon, upgrades[11][4].IsBought);
                oneHundredTimeMachinesUpgrade = new OneHundredTimeMachinesUpgrade(timeMachineBuilding, "100 Time Machines Upgrade", 7000000000000000000.0, upgrades[11][5].IsShownIcon, upgrades[11][5].IsBought);
                oneHundredFiftyTimeMachinesUpgrade = new OneHundredFiftyTimeMachinesUpgrade(timeMachineBuilding, "150 Time Machines Upgrade", 70000000000000000000.0, upgrades[11][6].IsShownIcon, upgrades[11][6].IsBought);
            }
        }

        public List<Upgrade> GetTimeMachineUpgrades()
        {
            return allUpgrades;
        }
    }
}
