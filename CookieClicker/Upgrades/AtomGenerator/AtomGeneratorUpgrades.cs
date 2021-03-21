using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookieClicker.Buildings;
using Newtonsoft.Json;
using System.IO;

namespace CookieClicker.Upgrades.AtomGenerator
{
    class AtomGeneratorUpgrades
    {
        private bool isContinueClicker;
        private AtomGeneratorBuilding atomGeneratorBuilding;
        public List<Upgrade> allUpgrades;

        private FiveAtomGeneratorsUpgrade fiveAtomGeneratorsUpgrade;
        private FifteenAtomGeneratorsUpgrade fifteenAtomGeneratorsUpgrade;
        private TwentyFiveAtomGeneratorsUpgrade twentyFiveAtomGeneratorsUpgrade;
        private FiftyAtomGeneratorsUpgrade fiftyAtomGeneratorsUpgrade;
        private SeventyFiveAtomGeneratorsUpgrade seventyFiveAtomGeneratorsUpgrade;
        private OneHundredAtomGeneratorsUpgrade oneHundredAtomGeneratorsUpgrade;
        private OneHundredFiftyAtomGeneratorsUpgrade oneHundredFiftyAtomGeneratorsUpgrade;

        public AtomGeneratorUpgrades(AtomGeneratorBuilding atomGeneratorBuilding, bool isContinueClicker)
        {
            this.isContinueClicker = isContinueClicker;
            this.atomGeneratorBuilding = atomGeneratorBuilding;

            InitializeUpgrades();

            allUpgrades = new List<Upgrade>();

            allUpgrades.Add(fiveAtomGeneratorsUpgrade);
            allUpgrades.Add(fifteenAtomGeneratorsUpgrade);
            allUpgrades.Add(twentyFiveAtomGeneratorsUpgrade);
            allUpgrades.Add(fiftyAtomGeneratorsUpgrade);
            allUpgrades.Add(seventyFiveAtomGeneratorsUpgrade);
            allUpgrades.Add(oneHundredAtomGeneratorsUpgrade);
            allUpgrades.Add(oneHundredFiftyAtomGeneratorsUpgrade);
        }

        private void InitializeUpgrades()
        {
            if (!isContinueClicker)
            {
                fiveAtomGeneratorsUpgrade = new FiveAtomGeneratorsUpgrade(atomGeneratorBuilding, "5 Atom Generators Upgrade", 1700000000000000.0, false, false);
                fifteenAtomGeneratorsUpgrade = new FifteenAtomGeneratorsUpgrade(atomGeneratorBuilding, "15 Atom Generators Upgrade", 8500000000000000.0, false, false);
                twentyFiveAtomGeneratorsUpgrade = new TwentyFiveAtomGeneratorsUpgrade(atomGeneratorBuilding, "25 Atom Generators Upgrade", 85000000000000000.0, false, false);
                fiftyAtomGeneratorsUpgrade = new FiftyAtomGeneratorsUpgrade(atomGeneratorBuilding, "50 Atom Generators Upgrade", 850000000000000000.0, false, false);
                seventyFiveAtomGeneratorsUpgrade = new SeventyFiveAtomGeneratorsUpgrade(atomGeneratorBuilding, "75 Atom Generators Upgrade", 8500000000000000000.0, false, false);
                oneHundredAtomGeneratorsUpgrade = new OneHundredAtomGeneratorsUpgrade(atomGeneratorBuilding, "100 Atom Generators Upgrade", 85000000000000000000.0, false, false);
                oneHundredFiftyAtomGeneratorsUpgrade = new OneHundredFiftyAtomGeneratorsUpgrade(atomGeneratorBuilding, "150 Atom Generators Upgrade", 850000000000000000000.0, false, false);
            }
            else
            {
                List<List<FiveAtomGeneratorsUpgrade>> upgrades = JsonConvert.DeserializeObject<List<List<FiveAtomGeneratorsUpgrade>>>(File.ReadAllText(@"upgrades.json"));
                fiveAtomGeneratorsUpgrade = new FiveAtomGeneratorsUpgrade(atomGeneratorBuilding, "5 Atom Generators Upgrade", 1700000000000000.0, upgrades[12][0].IsShownIcon, upgrades[12][0].IsBought);
                fifteenAtomGeneratorsUpgrade = new FifteenAtomGeneratorsUpgrade(atomGeneratorBuilding, "15 Atom Generators Upgrade", 8500000000000000.0, upgrades[12][1].IsShownIcon, upgrades[12][1].IsBought);
                twentyFiveAtomGeneratorsUpgrade = new TwentyFiveAtomGeneratorsUpgrade(atomGeneratorBuilding, "25 Atom Generators Upgrade", 85000000000000000.0, upgrades[12][2].IsShownIcon, upgrades[12][2].IsBought);
                fiftyAtomGeneratorsUpgrade = new FiftyAtomGeneratorsUpgrade(atomGeneratorBuilding, "50 Atom Generators Upgrade", 850000000000000000.0, upgrades[12][3].IsShownIcon, upgrades[12][3].IsBought);
                seventyFiveAtomGeneratorsUpgrade = new SeventyFiveAtomGeneratorsUpgrade(atomGeneratorBuilding, "75 Atom Generators Upgrade", 8500000000000000000.0, upgrades[12][4].IsShownIcon, upgrades[12][4].IsBought);
                oneHundredAtomGeneratorsUpgrade = new OneHundredAtomGeneratorsUpgrade(atomGeneratorBuilding, "100 Atom Generators Upgrade", 85000000000000000000.0, upgrades[12][5].IsShownIcon, upgrades[12][5].IsBought);
                oneHundredFiftyAtomGeneratorsUpgrade = new OneHundredFiftyAtomGeneratorsUpgrade(atomGeneratorBuilding, "150 Atom Generators Upgrade", 850000000000000000000.0, upgrades[12][6].IsShownIcon, upgrades[12][6].IsBought);
            }
        }

        public List<Upgrade> GetAtomGeneratorUpgrades()
        {
            return allUpgrades;
        }
    }
}
