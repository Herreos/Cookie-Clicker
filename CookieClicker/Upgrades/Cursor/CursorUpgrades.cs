using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookieClicker.Buildings;
using Newtonsoft.Json;
using System.IO;

namespace CookieClicker.Upgrades.Cursor
{
    class CursorUpgrades
    {
        private bool isContinueClicker;
        private CursorBuilding cursorBuilding;
        public List<Upgrade> allUpgrades;

        private FiveCursorsUpgrade fiveCursorsUpgrade;
        private FifteenCursorsUpgrade fifteenCursorsUpgrade;
        private TwentyFiveCursorsUpgrade twentyFiveCursorsUpgrade;
        private FiftyCursorsUpgrade fiftyCursorsUpgrade;
        private SeventyFiveCursorsUpgrade seventyFiveCursorsUpgrade;
        private OneHundredCursorsUpgrade oneHundredCursorsUpgrade;
        private OneHundredFiftyCursorsUpgrade oneHundredFiftyCursorsUpgrade;

        public CursorUpgrades(CursorBuilding cursorBuilding, bool isContinueClicker)
        {
            this.cursorBuilding = cursorBuilding;
            this.isContinueClicker = isContinueClicker;

            InitializeUpgrades();

            allUpgrades = new List<Upgrade>();

            allUpgrades.Add(fiveCursorsUpgrade);
            allUpgrades.Add(fifteenCursorsUpgrade);
            allUpgrades.Add(twentyFiveCursorsUpgrade);
            allUpgrades.Add(fiftyCursorsUpgrade);
            allUpgrades.Add(seventyFiveCursorsUpgrade);
            allUpgrades.Add(oneHundredCursorsUpgrade);
            allUpgrades.Add(oneHundredFiftyCursorsUpgrade);
        }
    
        private void InitializeUpgrades()
        {
            if (!isContinueClicker)
            {
                fiveCursorsUpgrade = new FiveCursorsUpgrade(cursorBuilding, "5 Cursors Upgrade", 100.0, false, false);
                fifteenCursorsUpgrade = new FifteenCursorsUpgrade(cursorBuilding, "15 Cursors Upgrade", 500.0, false, false);
                twentyFiveCursorsUpgrade = new TwentyFiveCursorsUpgrade(cursorBuilding, "25 Cursors Upgrade", 10000.0, false, false);
                fiftyCursorsUpgrade = new FiftyCursorsUpgrade(cursorBuilding, "50 Cursors Upgrade", 100000.0, false, false);
                seventyFiveCursorsUpgrade = new SeventyFiveCursorsUpgrade(cursorBuilding, "75 Cursors Upgrade", 10000000.0, false, false);
                oneHundredCursorsUpgrade = new OneHundredCursorsUpgrade(cursorBuilding, "100 Cursors Upgrade", 100000000.0, false, false);
                oneHundredFiftyCursorsUpgrade = new OneHundredFiftyCursorsUpgrade(cursorBuilding, "150 Cursors Upgrade", 1000000000.0, false, false);
            }
            else
            {
                List<List<FiveCursorsUpgrade>> upgrades = JsonConvert.DeserializeObject<List<List<FiveCursorsUpgrade>>>(File.ReadAllText(@"upgrades.json"));

                fiveCursorsUpgrade = new FiveCursorsUpgrade(cursorBuilding, "5 Cursors Upgrade", 100.0, upgrades[0][0].IsShownIcon, upgrades[0][0].IsBought);
                fifteenCursorsUpgrade = new FifteenCursorsUpgrade(cursorBuilding, "15 Cursors Upgrade", 500.0, upgrades[0][1].IsShownIcon, upgrades[0][1].IsBought);
                twentyFiveCursorsUpgrade = new TwentyFiveCursorsUpgrade(cursorBuilding, "25 Cursors Upgrade", 10000.0, upgrades[0][2].IsShownIcon, upgrades[0][2].IsBought);
                fiftyCursorsUpgrade = new FiftyCursorsUpgrade(cursorBuilding, "50 Cursors Upgrade", 100000.0, upgrades[0][3].IsShownIcon, upgrades[0][3].IsBought);
                seventyFiveCursorsUpgrade = new SeventyFiveCursorsUpgrade(cursorBuilding, "75 Cursors Upgrade", 10000000.0, upgrades[0][4].IsShownIcon, upgrades[0][4].IsBought);
                oneHundredCursorsUpgrade = new OneHundredCursorsUpgrade(cursorBuilding, "100 Cursors Upgrade", 100000000.0, upgrades[0][5].IsShownIcon, upgrades[0][5].IsBought);
                oneHundredFiftyCursorsUpgrade = new OneHundredFiftyCursorsUpgrade(cursorBuilding, "150 Cursors Upgrade", 1000000000.0, upgrades[0][6].IsShownIcon, upgrades[0][6].IsBought);
            }
        }

        public List<Upgrade> GetCursorUpgrades()
        {
            return allUpgrades;
        }
    }
}
