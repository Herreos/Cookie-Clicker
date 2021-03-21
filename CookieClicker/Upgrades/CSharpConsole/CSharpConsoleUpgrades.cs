using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookieClicker.Buildings;
using Newtonsoft.Json;
using System.IO;

namespace CookieClicker.Upgrades.CSharpConsole
{
    class CSharpConsoleUpgrades
    {
        private bool isContinueClicker;
        private CSharpConsoleBuilding cSharpConsoleBuilding;
        public List<Upgrade> allUpgrades;

        private FiveCSharpConsolesUpgrade fiveCSharpConsolesUpgrade;
        private FifteenCSharpConsolesUpgrade fifteenCSharpConsolesUpgrade;
        private TwentyFiveCSharpConsolesUpgrade twentyFiveCSharpConsolesUpgrade;
        private FiftyCSharpConsolesUpgrade fiftyCSharpConsolesUpgrade;
        private SeventyFiveCSharpConsolesUpgrade seventyFiveCSharpConsolesUpgrade;
        private OneHundredCSharpConsolesUpgrade oneHundredCSharpConsolesUpgrade;
        private OneHundredFiftyCSharpConsolesUpgrade oneHundredFiftyCSharpConsolesUpgrade;

        public CSharpConsoleUpgrades(CSharpConsoleBuilding cSharpConsoleBuilding, bool isContinueClicker)
        {
            this.isContinueClicker = isContinueClicker;
            this.cSharpConsoleBuilding = cSharpConsoleBuilding;

            InitializeUpgrades();

            allUpgrades = new List<Upgrade>();

            allUpgrades.Add(fiveCSharpConsolesUpgrade);
            allUpgrades.Add(fifteenCSharpConsolesUpgrade);
            allUpgrades.Add(twentyFiveCSharpConsolesUpgrade);
            allUpgrades.Add(fiftyCSharpConsolesUpgrade);
            allUpgrades.Add(seventyFiveCSharpConsolesUpgrade);
            allUpgrades.Add(oneHundredCSharpConsolesUpgrade);
            allUpgrades.Add(oneHundredFiftyCSharpConsolesUpgrade);
        }

        private void InitializeUpgrades()
        {
            if (!isContinueClicker)
            {
                fiveCSharpConsolesUpgrade = new FiveCSharpConsolesUpgrade(cSharpConsoleBuilding, "5 C# Consoles Upgrade", 750000000000000000000.0, false, false);
                fifteenCSharpConsolesUpgrade = new FifteenCSharpConsolesUpgrade(cSharpConsoleBuilding, "15 C# Consoles Upgrade", 3600000000000000000000.0, false, false);
                twentyFiveCSharpConsolesUpgrade = new TwentyFiveCSharpConsolesUpgrade(cSharpConsoleBuilding, "25 C# Consoles Upgrade", 36000000000000000000000.0, false, false);
                fiftyCSharpConsolesUpgrade = new FiftyCSharpConsolesUpgrade(cSharpConsoleBuilding, "50 C# Consoles Upgrade", 360000000000000000000000.0, false, false);
                seventyFiveCSharpConsolesUpgrade = new SeventyFiveCSharpConsolesUpgrade(cSharpConsoleBuilding, "75 C# Consoles Upgrade", 3600000000000000000000000.0, false, false);
                oneHundredCSharpConsolesUpgrade = new OneHundredCSharpConsolesUpgrade(cSharpConsoleBuilding, "100 C# Consoles Upgrade", 36000000000000000000000000.0, false, false);
                oneHundredFiftyCSharpConsolesUpgrade = new OneHundredFiftyCSharpConsolesUpgrade(cSharpConsoleBuilding, "150 C# Consoles Upgrade", 360000000000000000000000000.0, false, false);
            }
            else
            {
                List<List<FiveCSharpConsolesUpgrade>> upgrades = JsonConvert.DeserializeObject<List<List<FiveCSharpConsolesUpgrade>>>(File.ReadAllText(@"upgrades.json"));
                fiveCSharpConsolesUpgrade = new FiveCSharpConsolesUpgrade(cSharpConsoleBuilding, "5 C# Consoles Upgrade", 750000000000000000000.0, upgrades[16][0].IsShownIcon, upgrades[16][0].IsBought);
                fifteenCSharpConsolesUpgrade = new FifteenCSharpConsolesUpgrade(cSharpConsoleBuilding, "15 C# Consoles Upgrade", 3600000000000000000000.0, upgrades[16][1].IsShownIcon, upgrades[16][1].IsBought);
                twentyFiveCSharpConsolesUpgrade = new TwentyFiveCSharpConsolesUpgrade(cSharpConsoleBuilding, "25 C# Consoles Upgrade", 36000000000000000000000.0, upgrades[16][2].IsShownIcon, upgrades[16][2].IsBought);
                fiftyCSharpConsolesUpgrade = new FiftyCSharpConsolesUpgrade(cSharpConsoleBuilding, "50 C# Consoles Upgrade", 360000000000000000000000.0, upgrades[16][3].IsShownIcon, upgrades[16][3].IsBought);
                seventyFiveCSharpConsolesUpgrade = new SeventyFiveCSharpConsolesUpgrade(cSharpConsoleBuilding, "75 C# Consoles Upgrade", 3600000000000000000000000.0, upgrades[16][4].IsShownIcon, upgrades[16][4].IsBought);
                oneHundredCSharpConsolesUpgrade = new OneHundredCSharpConsolesUpgrade(cSharpConsoleBuilding, "100 C# Consoles Upgrade", 36000000000000000000000000.0, upgrades[16][5].IsShownIcon, upgrades[16][5].IsBought);
                oneHundredFiftyCSharpConsolesUpgrade = new OneHundredFiftyCSharpConsolesUpgrade(cSharpConsoleBuilding, "150 C# Consoles Upgrade", 360000000000000000000000000.0, upgrades[16][6].IsShownIcon, upgrades[16][6].IsBought);
            }
        }

        public List<Upgrade> GetCSharpConsoleUpgrades()
        {
            return allUpgrades;
        }
    }
}
