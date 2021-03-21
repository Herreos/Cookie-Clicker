using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookieClicker.Buildings;
using Newtonsoft.Json;
using System.IO;

namespace CookieClicker.Upgrades.Shipment
{
    class ShipmentUpgrades
    {
        private bool isContinueClicker;
        private ShipmentBuilding shipmentBuilding;
        public List<Upgrade> allUpgrades;

        private FiveShipmentsUpgrade fiveShipmentsUpgrade;
        private FifteenShipmentsUpgrade fifteenShipmentsUpgrade;
        private TwentyFiveShipmentsUpgrade twentyFiveShipmentsUpgrade;
        private FiftyShipmentsUpgrade fiftyShipmentsUpgrade;
        private SeventyFiveShipmentsUpgrade seventyFiveShipmentsUpgrade;
        private OneHundredShipmentsUpgrade oneHundredShipmentsUpgrade;
        private OneHundredFiftyShipmentsUpgrade oneHundredFiftyShipmentsUpgrade;

        public ShipmentUpgrades(ShipmentBuilding shipmentBuilding, bool isContinueClicker)
        {
            this.isContinueClicker = isContinueClicker;
            this.shipmentBuilding = shipmentBuilding;

            InitializeUpgrades();

            allUpgrades = new List<Upgrade>();

            allUpgrades.Add(fiveShipmentsUpgrade);
            allUpgrades.Add(fifteenShipmentsUpgrade);
            allUpgrades.Add(twentyFiveShipmentsUpgrade);
            allUpgrades.Add(fiftyShipmentsUpgrade);
            allUpgrades.Add(seventyFiveShipmentsUpgrade);
            allUpgrades.Add(oneHundredShipmentsUpgrade);
            allUpgrades.Add(oneHundredFiftyShipmentsUpgrade);
        }

        private void InitializeUpgrades()
        {
            if (!isContinueClicker)
            {
                fiveShipmentsUpgrade = new FiveShipmentsUpgrade(shipmentBuilding, "5 Shipments Upgrade", 51000000000.0, false, false);
                fifteenShipmentsUpgrade = new FifteenShipmentsUpgrade(shipmentBuilding, "15 Shipments Upgrade", 255000000000.0, false, false);
                twentyFiveShipmentsUpgrade = new TwentyFiveShipmentsUpgrade(shipmentBuilding, "25 Shipments Upgrade", 2550000000000.0, false, false);
                fiftyShipmentsUpgrade = new FiftyShipmentsUpgrade(shipmentBuilding, "50 Shipments Upgrade", 25500000000000.0, false, false);
                seventyFiveShipmentsUpgrade = new SeventyFiveShipmentsUpgrade(shipmentBuilding, "75 Shipments Upgrade", 255000000000000.0, false, false);
                oneHundredShipmentsUpgrade = new OneHundredShipmentsUpgrade(shipmentBuilding, "100 Shipments Upgrade", 2550000000000000.0, false, false);
                oneHundredFiftyShipmentsUpgrade = new OneHundredFiftyShipmentsUpgrade(shipmentBuilding, "150 Shipments Upgrade", 25500000000000000.0, false, false);
            }
            else
            {
                List<List<FiveShipmentsUpgrade>> upgrades = JsonConvert.DeserializeObject<List<List<FiveShipmentsUpgrade>>>(File.ReadAllText(@"upgrades.json"));
                fiveShipmentsUpgrade = new FiveShipmentsUpgrade(shipmentBuilding, "5 Shipments Upgrade", 51000000000.0, upgrades[8][0].IsShownIcon, upgrades[8][0].IsBought);
                fifteenShipmentsUpgrade = new FifteenShipmentsUpgrade(shipmentBuilding, "15 Shipments Upgrade", 255000000000.0, upgrades[8][1].IsShownIcon, upgrades[8][1].IsBought);
                twentyFiveShipmentsUpgrade = new TwentyFiveShipmentsUpgrade(shipmentBuilding, "25 Shipments Upgrade", 2550000000000.0, upgrades[8][2].IsShownIcon, upgrades[8][2].IsBought);
                fiftyShipmentsUpgrade = new FiftyShipmentsUpgrade(shipmentBuilding, "50 Shipments Upgrade", 25500000000000.0, upgrades[8][3].IsShownIcon, upgrades[8][3].IsBought);
                seventyFiveShipmentsUpgrade = new SeventyFiveShipmentsUpgrade(shipmentBuilding, "75 Shipments Upgrade", 255000000000000.0, upgrades[8][4].IsShownIcon, upgrades[8][4].IsBought);
                oneHundredShipmentsUpgrade = new OneHundredShipmentsUpgrade(shipmentBuilding, "100 Shipments Upgrade", 2550000000000000.0, upgrades[8][5].IsShownIcon, upgrades[8][5].IsBought);
                oneHundredFiftyShipmentsUpgrade = new OneHundredFiftyShipmentsUpgrade(shipmentBuilding, "150 Shipments Upgrade", 25500000000000000.0, upgrades[8][6].IsShownIcon, upgrades[8][6].IsBought);
            }
        }

        public List<Upgrade> GetShipmentUpgrades()
        {
            return allUpgrades;
        }
    }
}
