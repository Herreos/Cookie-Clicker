using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookieClicker.Buildings;
using Newtonsoft.Json;
using System.IO;

namespace CookieClicker.Upgrades.FractalEngine
{
    class FractalEngineUpgrades
    {
        private bool isContinueClicker;
        private FractalEngineBuilding fractalEngineBuilding;
        public List<Upgrade> allUpgrades;

        private FiveFractalEnginesUpgrade fiveFractalEnginesUpgrade;
        private FifteenFractalEnginesUpgrade fifteenFractalEnginesUpgrade;
        private TwentyFiveFractalEnginesUpgrade twentyFiveFractalEnginesUpgrade;
        private FiftyFractalEnginesUpgrade fiftyFractalEnginesUpgrade;
        private SeventyFiveFractalEnginesUpgrade seventyFiveFractalEnginesUpgrade;
        private OneHundredFractalEnginesUpgrade oneHundredFractalEnginesUpgrade;
        private OneHundredFiftyFractalEnginesUpgrade oneHundredFiftyFractalEnginesUpgrade;

        public FractalEngineUpgrades(FractalEngineBuilding fractalEngineBuilding, bool isContinueClicker)
        {
            this.isContinueClicker = isContinueClicker;
            this.fractalEngineBuilding = fractalEngineBuilding;

            InitializeUpgrades();

            allUpgrades = new List<Upgrade>();

            allUpgrades.Add(fiveFractalEnginesUpgrade);
            allUpgrades.Add(fifteenFractalEnginesUpgrade);
            allUpgrades.Add(twentyFiveFractalEnginesUpgrade);
            allUpgrades.Add(fiftyFractalEnginesUpgrade);
            allUpgrades.Add(seventyFiveFractalEnginesUpgrade);
            allUpgrades.Add(oneHundredFractalEnginesUpgrade);
            allUpgrades.Add(oneHundredFiftyFractalEnginesUpgrade);
        }

        private void InitializeUpgrades()
        {
            if (!isContinueClicker)
            {
                fiveFractalEnginesUpgrade = new FiveFractalEnginesUpgrade(fractalEngineBuilding, "5 Fractal Engines Upgrade", 3100000000000000000.0, false, false);
                fifteenFractalEnginesUpgrade = new FifteenFractalEnginesUpgrade(fractalEngineBuilding, "15 Fractal Engines Upgrade", 15500000000000000000.0, false, false);
                twentyFiveFractalEnginesUpgrade = new TwentyFiveFractalEnginesUpgrade(fractalEngineBuilding, "25 Fractal Engines Upgrade", 155000000000000000000.0, false, false);
                fiftyFractalEnginesUpgrade = new FiftyFractalEnginesUpgrade(fractalEngineBuilding, "50 Fractal Engines Upgrade", 1550000000000000000000.0, false, false);
                seventyFiveFractalEnginesUpgrade = new SeventyFiveFractalEnginesUpgrade(fractalEngineBuilding, "75 Fractal Engines Upgrade", 15500000000000000000000.0, false, false);
                oneHundredFractalEnginesUpgrade = new OneHundredFractalEnginesUpgrade(fractalEngineBuilding, "100 Fractal Engines Upgrade", 155000000000000000000000.0, false, false);
                oneHundredFiftyFractalEnginesUpgrade = new OneHundredFiftyFractalEnginesUpgrade(fractalEngineBuilding, "150 Fractal Engines Upgrade", 1550000000000000000000000.0, false, false);
            }
            else
            {
                List<List<FiveFractalEnginesUpgrade>> upgrades = JsonConvert.DeserializeObject<List<List<FiveFractalEnginesUpgrade>>>(File.ReadAllText(@"upgrades.json"));
                fiveFractalEnginesUpgrade = new FiveFractalEnginesUpgrade(fractalEngineBuilding, "5 Fractal Engines Upgrade", 3100000000000000000.0, upgrades[15][0].IsShownIcon, upgrades[15][0].IsBought);
                fifteenFractalEnginesUpgrade = new FifteenFractalEnginesUpgrade(fractalEngineBuilding, "15 Fractal Engines Upgrade", 15500000000000000000.0, upgrades[15][1].IsShownIcon, upgrades[15][1].IsBought);
                twentyFiveFractalEnginesUpgrade = new TwentyFiveFractalEnginesUpgrade(fractalEngineBuilding, "25 Fractal Engines Upgrade", 155000000000000000000.0, upgrades[15][2].IsShownIcon, upgrades[15][2].IsBought);
                fiftyFractalEnginesUpgrade = new FiftyFractalEnginesUpgrade(fractalEngineBuilding, "50 Fractal Engines Upgrade", 1550000000000000000000.0, upgrades[15][3].IsShownIcon, upgrades[15][3].IsBought);
                seventyFiveFractalEnginesUpgrade = new SeventyFiveFractalEnginesUpgrade(fractalEngineBuilding, "75 Fractal Engines Upgrade", 15500000000000000000000.0, upgrades[15][4].IsShownIcon, upgrades[15][4].IsBought);
                oneHundredFractalEnginesUpgrade = new OneHundredFractalEnginesUpgrade(fractalEngineBuilding, "100 Fractal Engines Upgrade", 155000000000000000000000.0, upgrades[15][5].IsShownIcon, upgrades[15][5].IsBought);
                oneHundredFiftyFractalEnginesUpgrade = new OneHundredFiftyFractalEnginesUpgrade(fractalEngineBuilding, "150 Fractal Engines Upgrade", 1550000000000000000000000.0, upgrades[15][6].IsShownIcon, upgrades[15][6].IsBought);
            }
        }

        public List<Upgrade> GetFractalEngineUpgrades()
        {
            return allUpgrades;
        }
    }
}
