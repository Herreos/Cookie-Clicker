using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CookieClicker.Buildings;
using CookieClicker.CookieProduction;
using CookieClicker.Upgrades;
using Newtonsoft.Json;
using System.IO;

namespace CookieClicker
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainCookie mainCookie;
        private MenuWindow menuWindow;

        private CursorBuilding cursorBuilding;
        private GrandmaBuilding grandmaBuilding;
        private FarmBuilding farmBuilding;
        private MineBuilding mineBuilding;
        private FactoryBuilding factoryBuilding;
        private BankBuilding bankBuilding;
        private TempleBuilding templeBuilding;
        private WizardTowerBuilding wizardTowerBuilding;
        private ShipmentBuilding shipmentBuilding;
        private AlchemyLabBuilding alchemyLabBuilding;
        private PortalBuilding portalBuilding;
        private TimeMachineBuilding timeMachineBuilding;
        private AtomGeneratorBuilding atomGeneratorBuilding;
        private PrismBuilding prismBuilding;
        private ChancemakerBuilding chancemakerBuilding;
        private FractalEngineBuilding fractalEngineBuilding;
        private CSharpConsoleBuilding cSharpConsoleBuilding;
        private IdleverseBuilding idleverseBuilding;

        private List<Building> listOfAllBuildings;

        private bool isContinueClicker = false;
        public MainWindow(MenuWindow menuWindow, bool isContinueClicker)
        {
            this.isContinueClicker = isContinueClicker;
            this.menuWindow = menuWindow;
            InitializeComponent();

            InitializeMainCookie();
            InitializeMainCookieTimer();

            InitializeBuildings();
            InitializeUpgradesTimer();

            PrepareBuildingsQuantity();
            PrepareBuildingsPrice();
        }

        public void InitializeMainCookie()
        {
            if (!isContinueClicker)
            {
                mainCookie = new MainCookie(0, 0, 3.0);
            }
            else
            {
                MainCookie mainCookieJson = JsonConvert.DeserializeObject<MainCookie>(File.ReadAllText(@"cookie.json"));
                mainCookie = new MainCookie(mainCookieJson.TotalCookieValue, mainCookieJson.CookiePerSecond, mainCookieJson.ClickValue);
            }

            TotalCookies.Text = ChangeNumberFormat(mainCookie.TotalCookieValue, 3) + " cookies";
            CookiesPerSecond.Text = "per second: " + ChangeNumberFormat(mainCookie.CookiePerSecond, 3);
        }

        private void InitializeMainCookieTimer()
        {
            DispatcherTimer cookiesPerSecondTimer = new DispatcherTimer(DispatcherPriority.Normal);
            cookiesPerSecondTimer.Tick += AddCookiesPerSecondToTotalCookies;
            cookiesPerSecondTimer.Interval = TimeSpan.FromMilliseconds(1000 / 20);
            cookiesPerSecondTimer.Start();
        }

        private void AddCookiesPerSecondToTotalCookies(object sender, EventArgs e)
        {
            mainCookie.TotalCookieValue += mainCookie.CookiePerSecond / 20;
            TotalCookies.Text = ChangeNumberFormat(mainCookie.TotalCookieValue, 3) + " cookies";
        }

        public void InitializeBuildings()
        {
            listOfAllBuildings = new List<Building>();

            if (!isContinueClicker)
            {
                cursorBuilding = new CursorBuilding(0, "Cursor", 0, 0.1, 15.0, isContinueClicker);
                grandmaBuilding = new GrandmaBuilding(1, "Grandma", 0, 1.0, 100.0, isContinueClicker);
                farmBuilding = new FarmBuilding(2, "Farm", 0, 8.0, 1100.0, isContinueClicker);
                mineBuilding = new MineBuilding(3, "Mine", 0, 47.0, 12000.0, isContinueClicker);
                factoryBuilding = new FactoryBuilding(4, "Factory", 0, 260.0, 130000.0, isContinueClicker);
                bankBuilding = new BankBuilding(5, "Bank", 0, 1400.0, 1400000.0, isContinueClicker);
                templeBuilding = new TempleBuilding(6, "Temple", 0, 7800.0, 20000000.0, isContinueClicker);
                wizardTowerBuilding = new WizardTowerBuilding(7, "Wizard Tower", 0, 44000.0, 330000000.0, isContinueClicker);
                shipmentBuilding = new ShipmentBuilding(8, "Shipment", 0, 260000.0, 5100000000.0, isContinueClicker);
                alchemyLabBuilding = new AlchemyLabBuilding(9, "Alchemy Lab", 0, 1600000.0, 75000000000.0, isContinueClicker);
                portalBuilding = new PortalBuilding(10, "Portal", 0, 10000000.0, 1000000000000.0, isContinueClicker);
                timeMachineBuilding = new TimeMachineBuilding(11, "Time machine", 0, 65000000.0, 14000000000000.0, isContinueClicker);
                atomGeneratorBuilding = new AtomGeneratorBuilding(12, "Atom Generator", 0, 430000000.0, 170000000000000.0, isContinueClicker);
                prismBuilding = new PrismBuilding(13, "Prism", 0, 2900000000.0, 2000000000000000.0, isContinueClicker);
                chancemakerBuilding = new ChancemakerBuilding(14, "Chancemaker", 0, 21000000000.0, 26000000000000000.0, isContinueClicker);
                fractalEngineBuilding = new FractalEngineBuilding(15, "Fractal Engine", 0, 150000000000.0, 310000000000000000.0, isContinueClicker);
                cSharpConsoleBuilding = new CSharpConsoleBuilding(16, "C# Console", 0, 1100000000000.0, 71000000000000000000.0, isContinueClicker);
                idleverseBuilding = new IdleverseBuilding(17, "Idleverse", 0, 8300000000000.0, 12000000000000000000000.0, isContinueClicker);
            } 
            else
            {
                List<CursorBuilding> buildingsJson = JsonConvert.DeserializeObject<List<CursorBuilding>>(File.ReadAllText(@"buildings.json"));

                cursorBuilding = new CursorBuilding(buildingsJson[0].Id, buildingsJson[0].Name, buildingsJson[0].BuildingsQuantity, buildingsJson[0].BuildingValue, buildingsJson[0].Price, isContinueClicker);
                grandmaBuilding = new GrandmaBuilding(buildingsJson[1].Id, buildingsJson[1].Name, buildingsJson[1].BuildingsQuantity, buildingsJson[1].BuildingValue, buildingsJson[1].Price, isContinueClicker);
                farmBuilding = new FarmBuilding(buildingsJson[2].Id, buildingsJson[2].Name, buildingsJson[2].BuildingsQuantity, buildingsJson[2].BuildingValue, buildingsJson[2].Price, isContinueClicker);
                mineBuilding = new MineBuilding(buildingsJson[3].Id, buildingsJson[3].Name, buildingsJson[3].BuildingsQuantity, buildingsJson[3].BuildingValue, buildingsJson[3].Price, isContinueClicker);
                factoryBuilding = new FactoryBuilding(buildingsJson[4].Id, buildingsJson[4].Name, buildingsJson[4].BuildingsQuantity, buildingsJson[4].BuildingValue, buildingsJson[4].Price, isContinueClicker);
                bankBuilding = new BankBuilding(buildingsJson[5].Id, buildingsJson[5].Name, buildingsJson[5].BuildingsQuantity, buildingsJson[5].BuildingValue, buildingsJson[5].Price, isContinueClicker);
                templeBuilding = new TempleBuilding(buildingsJson[6].Id, buildingsJson[6].Name, buildingsJson[6].BuildingsQuantity, buildingsJson[6].BuildingValue, buildingsJson[6].Price, isContinueClicker);
                wizardTowerBuilding = new WizardTowerBuilding(buildingsJson[7].Id, buildingsJson[7].Name, buildingsJson[7].BuildingsQuantity, buildingsJson[7].BuildingValue, buildingsJson[7].Price, isContinueClicker);
                shipmentBuilding = new ShipmentBuilding(buildingsJson[8].Id, buildingsJson[8].Name, buildingsJson[8].BuildingsQuantity, buildingsJson[8].BuildingValue, buildingsJson[8].Price, isContinueClicker);
                alchemyLabBuilding = new AlchemyLabBuilding(buildingsJson[9].Id, buildingsJson[9].Name, buildingsJson[9].BuildingsQuantity, buildingsJson[9].BuildingValue, buildingsJson[9].Price, isContinueClicker);
                portalBuilding = new PortalBuilding(buildingsJson[10].Id, buildingsJson[10].Name, buildingsJson[10].BuildingsQuantity, buildingsJson[10].BuildingValue, buildingsJson[10].Price, isContinueClicker);
                timeMachineBuilding = new TimeMachineBuilding(buildingsJson[11].Id, buildingsJson[11].Name, buildingsJson[11].BuildingsQuantity, buildingsJson[11].BuildingValue, buildingsJson[11].Price, isContinueClicker);
                atomGeneratorBuilding = new AtomGeneratorBuilding(buildingsJson[12].Id, buildingsJson[12].Name, buildingsJson[12].BuildingsQuantity, buildingsJson[12].BuildingValue, buildingsJson[12].Price, isContinueClicker);
                prismBuilding = new PrismBuilding(buildingsJson[13].Id, buildingsJson[13].Name, buildingsJson[13].BuildingsQuantity, buildingsJson[13].BuildingValue, buildingsJson[13].Price, isContinueClicker);
                chancemakerBuilding = new ChancemakerBuilding(buildingsJson[14].Id, buildingsJson[14].Name, buildingsJson[14].BuildingsQuantity, buildingsJson[14].BuildingValue, buildingsJson[14].Price, isContinueClicker);
                fractalEngineBuilding = new FractalEngineBuilding(buildingsJson[15].Id, buildingsJson[15].Name, buildingsJson[15].BuildingsQuantity, buildingsJson[15].BuildingValue, buildingsJson[15].Price, isContinueClicker);
                cSharpConsoleBuilding = new CSharpConsoleBuilding(buildingsJson[16].Id, buildingsJson[16].Name, buildingsJson[16].BuildingsQuantity, buildingsJson[16].BuildingValue, buildingsJson[16].Price, buildingsJson[16].IsContinueClicker);
                idleverseBuilding = new IdleverseBuilding(buildingsJson[17].Id, buildingsJson[17].Name, buildingsJson[17].BuildingsQuantity, buildingsJson[17].BuildingValue, buildingsJson[17].Price, isContinueClicker);
            }

            listOfAllBuildings.Add(cursorBuilding);
            listOfAllBuildings.Add(grandmaBuilding);
            listOfAllBuildings.Add(farmBuilding);
            listOfAllBuildings.Add(mineBuilding);
            listOfAllBuildings.Add(factoryBuilding);
            listOfAllBuildings.Add(bankBuilding);
            listOfAllBuildings.Add(templeBuilding);
            listOfAllBuildings.Add(wizardTowerBuilding);
            listOfAllBuildings.Add(shipmentBuilding);
            listOfAllBuildings.Add(alchemyLabBuilding);
            listOfAllBuildings.Add(portalBuilding);
            listOfAllBuildings.Add(timeMachineBuilding);
            listOfAllBuildings.Add(atomGeneratorBuilding);
            listOfAllBuildings.Add(prismBuilding);
            listOfAllBuildings.Add(chancemakerBuilding);
            listOfAllBuildings.Add(fractalEngineBuilding);
            listOfAllBuildings.Add(cSharpConsoleBuilding);
            listOfAllBuildings.Add(idleverseBuilding);
        }

        private void InitializeUpgradesTimer()
        {
            DispatcherTimer upgradesTimer = new DispatcherTimer(DispatcherPriority.Normal);
            upgradesTimer.Tick += SearchForUpgradesAvailability;
            upgradesTimer.Interval = TimeSpan.FromMilliseconds(1000 / 60);
            upgradesTimer.Start();
        }

        private void SearchForUpgradesAvailability(object sender, EventArgs e)
        {
            foreach (Building building in listOfAllBuildings)
            {
                BuildingUpgrade(building);
            }
        }

        private void BuildingUpgrade(Building building)
        {
            foreach (Upgrade upgrade in building.GetUpgrades())
            {
                if (upgrade.IsAvaliable() && !upgrade.IsShownIcon && !upgrade.IsBought && !upgrade.IsUpgradeShown)
                {
                    CreateUpgradeIcon(upgrade);
                    upgrade.IsShownIcon = true;
                    upgrade.IsUpgradeShown = true;
                }
                else if(isContinueClicker && upgrade.IsShownIcon && !upgrade.IsBought && !upgrade.IsUpgradeShown)
                {
                    CreateUpgradeIcon(upgrade);
                    upgrade.IsUpgradeShown = true;
                }

                if (upgrade.Icon != null && upgrade.Icon.IsMouseOver)
                {
                    InformationImage.Source = upgrade.IconImage.Source;
                    InformationTopic.Text = upgrade.Name;
                    InformationContent.Text = upgrade.Description + "\n";
                    InformationContent.Text += "Price: " + ChangeNumberFormat(upgrade.Price, 3) + " cookies.";

                    upgrade.Icon.MouseLeave += UpgradeButton_MouseLeave;
                }
            }
        }

        private void UpgradeButton_MouseLeave(object sender, MouseEventArgs e)
        {
            InformationImage.Source = null;
            InformationTopic.Text = "Hold the mouse over a building or upgrade.";
            InformationContent.Text = "A description will appear here.";
        }

        private void CreateUpgradeIcon(Upgrade upgrade)
        {
            var button = upgrade.CreateUpgradeIcon();
            button.Click += SearchForBuildingUpgrade;

            UpgradesPanel.Children.Add(button);
        }

        private void SearchForBuildingUpgrade(object sender, EventArgs e)
        {
            foreach (Building building in listOfAllBuildings)
            {
                BuyUpgrade(building);
            }
        }

        private void BuyUpgrade(Building building)
        {
            foreach (Upgrade upgrade in building.GetUpgrades())
            {
                if (upgrade.Icon == null)
                    break;

                if (upgrade.Icon.IsMouseOver && mainCookie.TotalCookieValue >= upgrade.Price && !upgrade.IsBought)
                {
                    upgrade.IsBought = true;
                    upgrade.IsShownIcon = false;
                    mainCookie.TotalCookieValue -= upgrade.Price;
                    mainCookie.CookiePerSecond += (building.BuildingValue * building.BuildingsQuantity);
                    mainCookie.ClickValue += building.BuildingValue * 0.01;
                    building.BuildingValue *= 2;

                    CookiesPerSecond.Text = "per second: " + ChangeNumberFormat(mainCookie.CookiePerSecond, 3);

                    UpgradesPanel.Children.Remove(upgrade.Icon);
                }
            }
        }

        public void PrepareBuildingsQuantity()
        {
            CursorCounter.Content = cursorBuilding.BuildingsQuantity;
            GrandmaCounter.Content = grandmaBuilding.BuildingsQuantity;
            FarmCounter.Content = farmBuilding.BuildingsQuantity;
            MineCounter.Content = mineBuilding.BuildingsQuantity;
            FactoryCounter.Content = factoryBuilding.BuildingsQuantity;
            BankCounter.Content = bankBuilding.BuildingsQuantity;
            TempleCounter.Content = templeBuilding.BuildingsQuantity;
            WizardTowerCounter.Content = wizardTowerBuilding.BuildingsQuantity;
            ShipmentCounter.Content = shipmentBuilding.BuildingsQuantity;
            AlchemyLabCounter.Content = alchemyLabBuilding.BuildingsQuantity;
            PortalCounter.Content = portalBuilding.BuildingsQuantity;
            TimeMachineCounter.Content = timeMachineBuilding.BuildingsQuantity;
            AtomGeneratorCounter.Content = atomGeneratorBuilding.BuildingsQuantity;
            PrismCounter.Content = prismBuilding.BuildingsQuantity;
            ChancemakerCounter.Content = chancemakerBuilding.BuildingsQuantity;
            FractalEngineCounter.Content = fractalEngineBuilding.BuildingsQuantity;
            CSharpConsoleCounter.Content = cSharpConsoleBuilding.BuildingsQuantity;
            IdleverseCounter.Content = idleverseBuilding.BuildingsQuantity;
        }

        public void PrepareBuildingsPrice()
        {
            CursorPrice.Text = "Price: " + ChangeNumberFormat(cursorBuilding.Price, 3);
            GrandmaPrice.Text = "Price: " + ChangeNumberFormat(grandmaBuilding.Price, 3);
            FarmPrice.Text = "Price: " + ChangeNumberFormat(farmBuilding.Price, 3);
            MinePrice.Text = "Price: " + ChangeNumberFormat(mineBuilding.Price, 3);
            FactoryPrice.Text = "Price: " + ChangeNumberFormat(factoryBuilding.Price, 3);
            BankPrice.Text = "Price: " + ChangeNumberFormat(bankBuilding.Price, 3);
            TemplePrice.Text = "Price: " + ChangeNumberFormat(templeBuilding.Price, 3);
            WizardTowerPrice.Text = "Price: " + ChangeNumberFormat(wizardTowerBuilding.Price, 3);
            ShipmentPrice.Text = "Price: " + ChangeNumberFormat(shipmentBuilding.Price, 3);
            AlchemyLabPrice.Text = "Price: " + ChangeNumberFormat(alchemyLabBuilding.Price, 3);
            PortalPrice.Text = "Price: " + ChangeNumberFormat(portalBuilding.Price, 3);
            TimeMachinePrice.Text = "Price: " + ChangeNumberFormat(timeMachineBuilding.Price, 3);
            AtomGeneratorPrice.Text = "Price: " + ChangeNumberFormat(atomGeneratorBuilding.Price, 3);
            PrismPrice.Text = "Price: " + ChangeNumberFormat(prismBuilding.Price, 3);
            ChancemakerPrice.Text = "Price: " + ChangeNumberFormat(chancemakerBuilding.Price, 3);
            FractalEnginePrice.Text = "Price: " + ChangeNumberFormat(fractalEngineBuilding.Price, 3);
            CSharpConsolePrice.Text = "Price: " + ChangeNumberFormat(cSharpConsoleBuilding.Price, 3);
            IdleversePrice.Text = "Price: " + ChangeNumberFormat(idleverseBuilding.Price, 3);
        }

        private string ChangeNumberFormat(double currentNumber, int precision)
        {
            string parsedPrecision = precision.ToString();
            if (currentNumber >= 1000000000000000000000000000000000.0)
                return (currentNumber / 1000000000000000000000000000000000.0).ToString("F" + parsedPrecision) + " decillion";
            else if (currentNumber >= 1000000000000000000000000000000.0)
                return (currentNumber / 1000000000000000000000000000000.0).ToString("F" + parsedPrecision) + " nonillion";
            else if (currentNumber >= 1000000000000000000000000000.0)
                return (currentNumber / 1000000000000000000000000000.0).ToString("F" + parsedPrecision) + " octillion";
            else if (currentNumber >= 1000000000000000000000000.0)
                return (currentNumber / 1000000000000000000000000.0).ToString("F" + parsedPrecision) + " septillion";
            else if (currentNumber >= 1000000000000000000000.0)
                return (currentNumber / 1000000000000000000000.0).ToString("F" + parsedPrecision) + " sextillion";
            else if (currentNumber >= 1000000000000000000.0)
                return (currentNumber / 1000000000000000000.0).ToString("F" + parsedPrecision) + " quintillion";
            else if (currentNumber >= 1000000000000000.0)
                return (currentNumber / 1000000000000000.0).ToString("F" + parsedPrecision) + " quadrillion";
            else if (currentNumber >= 1000000000000.0)
                return (currentNumber / 1000000000000.0).ToString("F" + parsedPrecision) + " trillion";
            else if (currentNumber >= 1000000000.0)
                return (currentNumber / 1000000000.0).ToString("F" + parsedPrecision) + " billion";
            else if (currentNumber >= 1000000.0)
                return (currentNumber / 1000000.0).ToString("F" + parsedPrecision) + " million";
            else
            {
                return currentNumber.ToString("F1");
            }
        }

        private void CursorButton_Click(object sender, RoutedEventArgs e)
        {
            if (mainCookie.TotalCookieValue < cursorBuilding.Price)
                return;

            cursorBuilding.BuildingsQuantity += 1;
            CursorCounter.Content = cursorBuilding.BuildingsQuantity;

            mainCookie.TotalCookieValue -= cursorBuilding.Price;
            cursorBuilding.Price = cursorBuilding.Price * 1.3;
            CursorPrice.Text = "Price: " + ChangeNumberFormat(cursorBuilding.Price, 3);
            mainCookie.ClickValue += cursorBuilding.BuildingValue * 0.01;

            mainCookie.CookiePerSecond += cursorBuilding.BuildingValue;
            CookiesPerSecond.Text = "per second: " + ChangeNumberFormat(mainCookie.CookiePerSecond, 3);

            CursorButton_MouseEnter(sender, EventArgs.Empty);
        }

        private void CursorButton_MouseEnter(object sender, EventArgs e)
        {
            InformationImage.Source = cursorBuilding.IconImage.Source;
            InformationTopic.Text = cursorBuilding.Name + " Building";
            InformationContent.Text = "Each cursor produces " + ChangeNumberFormat(cursorBuilding.BuildingValue, 3) + " per second.\n";
            InformationContent.Text += ChangeNumberFormat(cursorBuilding.BuildingsQuantity, 3) + " cursors producing " + ChangeNumberFormat(cursorBuilding.BuildingValue * cursorBuilding.BuildingsQuantity, 3) + " per second.";
        }

        private void CursorButton_MouseLeave(object sender, MouseEventArgs e)
        {
            InformationImage.Source = null;
            InformationTopic.Text = "Hold the mouse over a building or upgrade.";
            InformationContent.Text = "A description will appear here.";
        }

        private void GrandmaButton_Click(object sender, RoutedEventArgs e)
        {
            if (mainCookie.TotalCookieValue < grandmaBuilding.Price)
                return;

            grandmaBuilding.BuildingsQuantity += 1;
            GrandmaCounter.Content = grandmaBuilding.BuildingsQuantity;

            mainCookie.TotalCookieValue -= grandmaBuilding.Price;
            grandmaBuilding.Price = grandmaBuilding.Price * 1.3;
            GrandmaPrice.Text = "Price: " + ChangeNumberFormat(grandmaBuilding.Price, 3);
            mainCookie.ClickValue += grandmaBuilding.BuildingValue * 0.01;

            mainCookie.CookiePerSecond += grandmaBuilding.BuildingValue;
            CookiesPerSecond.Text = "per second: " + ChangeNumberFormat(mainCookie.CookiePerSecond, 3);

            GrandmaButton_MouseEnter(sender, EventArgs.Empty);
        }

        private void GrandmaButton_MouseEnter(object sender, EventArgs e)
        {
            InformationImage.Source = grandmaBuilding.IconImage.Source;
            InformationTopic.Text = grandmaBuilding.Name + " Building";
            InformationContent.Text = "Each cursor produces " + ChangeNumberFormat(grandmaBuilding.BuildingValue, 3) + " per second.\n";
            InformationContent.Text += ChangeNumberFormat(grandmaBuilding.BuildingsQuantity, 3) + " cursors producing " + ChangeNumberFormat(grandmaBuilding.BuildingValue * grandmaBuilding.BuildingsQuantity, 3) + " per second.";
        }

        private void GrandmaButton_MouseLeave(object sender, MouseEventArgs e)
        {
            InformationImage.Source = null;
            InformationTopic.Text = "Hold the mouse over a building or upgrade.";
            InformationContent.Text = "A description will appear here.";
        }

        private void FarmButton_Click(object sender, RoutedEventArgs e)
        {
            if (mainCookie.TotalCookieValue < farmBuilding.Price)
                return;

            farmBuilding.BuildingsQuantity += 1;
            FarmCounter.Content = farmBuilding.BuildingsQuantity;

            mainCookie.TotalCookieValue -= farmBuilding.Price;
            farmBuilding.Price = farmBuilding.Price * 1.3;
            FarmPrice.Text = "Price: " + ChangeNumberFormat(farmBuilding.Price, 3);
            mainCookie.ClickValue += farmBuilding.BuildingValue * 0.01;

            mainCookie.CookiePerSecond += farmBuilding.BuildingValue;
            CookiesPerSecond.Text = "per second: " + ChangeNumberFormat(mainCookie.CookiePerSecond, 3);

            FarmButton_MouseEnter(sender, EventArgs.Empty);
        }

        private void FarmButton_MouseEnter(object sender, EventArgs e)
        {
            InformationImage.Source = farmBuilding.IconImage.Source;
            InformationTopic.Text = farmBuilding.Name + " Building";
            InformationContent.Text = "Each cursor produces " + ChangeNumberFormat(farmBuilding.BuildingValue, 3) + " per second.\n";
            InformationContent.Text += ChangeNumberFormat(farmBuilding.BuildingsQuantity, 3) + " cursors producing " + ChangeNumberFormat(farmBuilding.BuildingValue * farmBuilding.BuildingsQuantity, 3) + " per second.";
        }

        private void FarmButton_MouseLeave(object sender, MouseEventArgs e)
        {
            InformationImage.Source = null;
            InformationTopic.Text = "Hold the mouse over a building or upgrade.";
            InformationContent.Text = "A description will appear here.";
        }

        private void MineButton_Click(object sender, RoutedEventArgs e)
        {
            if (mainCookie.TotalCookieValue < mineBuilding.Price)
                return;

            mineBuilding.BuildingsQuantity += 1;
            MineCounter.Content = mineBuilding.BuildingsQuantity;

            mainCookie.TotalCookieValue -= mineBuilding.Price;
            mineBuilding.Price = mineBuilding.Price * 1.3;
            MinePrice.Text = "Price: " + ChangeNumberFormat(mineBuilding.Price, 3);
            mainCookie.ClickValue += mineBuilding.BuildingValue * 0.01;

            mainCookie.CookiePerSecond += mineBuilding.BuildingValue;
            CookiesPerSecond.Text = "per second: " + ChangeNumberFormat(mainCookie.CookiePerSecond, 3);

            MineButton_MouseEnter(sender, EventArgs.Empty);
        }

        private void MineButton_MouseEnter(object sender, EventArgs e)
        {
            InformationImage.Source = mineBuilding.IconImage.Source;
            InformationTopic.Text = mineBuilding.Name + " Building";
            InformationContent.Text = "Each cursor produces " + ChangeNumberFormat(mineBuilding.BuildingValue, 3) + " per second.\n";
            InformationContent.Text += ChangeNumberFormat(mineBuilding.BuildingsQuantity, 3) + " cursors producing " + ChangeNumberFormat(mineBuilding.BuildingValue * mineBuilding.BuildingsQuantity, 3) + " per second.";
        }

        private void MineButton_MouseLeave(object sender, MouseEventArgs e)
        {
            InformationImage.Source = null;
            InformationTopic.Text = "Hold the mouse over a building or upgrade.";
            InformationContent.Text = "A description will appear here.";
        }

        private void FactoryButton_Click(object sender, RoutedEventArgs e)
        {
            if (mainCookie.TotalCookieValue < factoryBuilding.Price)
                return;

            factoryBuilding.BuildingsQuantity += 1;
            FactoryCounter.Content = factoryBuilding.BuildingsQuantity;

            mainCookie.TotalCookieValue -= factoryBuilding.Price;
            factoryBuilding.Price = factoryBuilding.Price * 1.3;
            FactoryPrice.Text = "Price: " + ChangeNumberFormat(factoryBuilding.Price, 3);
            mainCookie.ClickValue += factoryBuilding.BuildingValue * 0.01;

            mainCookie.CookiePerSecond += factoryBuilding.BuildingValue;
            CookiesPerSecond.Text = "per second: " + ChangeNumberFormat(mainCookie.CookiePerSecond, 3);

            FactoryButton_MouseEnter(sender, EventArgs.Empty);
        }

        private void FactoryButton_MouseEnter(object sender, EventArgs e)
        {
            InformationImage.Source = factoryBuilding.IconImage.Source;
            InformationTopic.Text = factoryBuilding.Name + " Building";
            InformationContent.Text = "Each cursor produces " + ChangeNumberFormat(factoryBuilding.BuildingValue, 3) + " per second.\n";
            InformationContent.Text += ChangeNumberFormat(factoryBuilding.BuildingsQuantity, 3) + " cursors producing " + ChangeNumberFormat(factoryBuilding.BuildingValue * factoryBuilding.BuildingsQuantity, 3) + " per second.";
        }

        private void FactoryButton_MouseLeave(object sender, MouseEventArgs e)
        {
            InformationImage.Source = null;
            InformationTopic.Text = "Hold the mouse over a building or upgrade.";
            InformationContent.Text = "A description will appear here.";
        }

        private void BankButton_Click(object sender, RoutedEventArgs e)
        {
            if (mainCookie.TotalCookieValue < bankBuilding.Price)
                return;

            bankBuilding.BuildingsQuantity += 1;
            BankCounter.Content = bankBuilding.BuildingsQuantity;

            mainCookie.TotalCookieValue -= bankBuilding.Price;
            bankBuilding.Price = bankBuilding.Price * 1.3;
            BankPrice.Text = "Price: " + ChangeNumberFormat(bankBuilding.Price, 3);
            mainCookie.ClickValue += bankBuilding.BuildingValue * 0.01;

            mainCookie.CookiePerSecond += bankBuilding.BuildingValue;
            CookiesPerSecond.Text = "per second: " + ChangeNumberFormat(mainCookie.CookiePerSecond, 3);

            BankButton_MouseEnter(sender, EventArgs.Empty);
        }

        private void BankButton_MouseEnter(object sender, EventArgs e)
        {
            InformationImage.Source = bankBuilding.IconImage.Source;
            InformationTopic.Text = bankBuilding.Name + " Building";
            InformationContent.Text = "Each cursor produces " + ChangeNumberFormat(bankBuilding.BuildingValue, 3) + " per second.\n";
            InformationContent.Text += ChangeNumberFormat(bankBuilding.BuildingsQuantity, 3) + " cursors producing " + ChangeNumberFormat(bankBuilding.BuildingValue * bankBuilding.BuildingsQuantity, 3) + " per second.";
        }

        private void BankButton_MouseLeave(object sender, MouseEventArgs e)
        {
            InformationImage.Source = null;
            InformationTopic.Text = "Hold the mouse over a building or upgrade.";
            InformationContent.Text = "A description will appear here.";
        }

        private void TempleButton_Click(object sender, RoutedEventArgs e)
        {
            if (mainCookie.TotalCookieValue < templeBuilding.Price)
                return;

            templeBuilding.BuildingsQuantity += 1;
            TempleCounter.Content = templeBuilding.BuildingsQuantity;

            mainCookie.TotalCookieValue -= templeBuilding.Price;
            templeBuilding.Price = templeBuilding.Price * 1.3;
            TemplePrice.Text = "Price: " + ChangeNumberFormat(templeBuilding.Price, 3);
            mainCookie.ClickValue += templeBuilding.BuildingValue * 0.01;

            mainCookie.CookiePerSecond += templeBuilding.BuildingValue;
            CookiesPerSecond.Text = "per second: " + ChangeNumberFormat(mainCookie.CookiePerSecond, 3);

            TempleButton_MouseEnter(sender, EventArgs.Empty);
        }

        private void TempleButton_MouseEnter(object sender, EventArgs e)
        {
            InformationImage.Source = templeBuilding.IconImage.Source;
            InformationTopic.Text = templeBuilding.Name + " Building";
            InformationContent.Text = "Each cursor produces " + ChangeNumberFormat(templeBuilding.BuildingValue, 3) + " per second.\n";
            InformationContent.Text += ChangeNumberFormat(templeBuilding.BuildingsQuantity, 3) + " cursors producing " + ChangeNumberFormat(templeBuilding.BuildingValue * templeBuilding.BuildingsQuantity, 3) + " per second.";
        }

        private void TempleButton_MouseLeave(object sender, MouseEventArgs e)
        {
            InformationImage.Source = null;
            InformationTopic.Text = "Hold the mouse over a building or upgrade.";
            InformationContent.Text = "A description will appear here.";
        }

        private void WizardTowerButton_Click(object sender, RoutedEventArgs e)
        {
            if (mainCookie.TotalCookieValue < wizardTowerBuilding.Price)
                return;

            wizardTowerBuilding.BuildingsQuantity += 1;
            WizardTowerCounter.Content = wizardTowerBuilding.BuildingsQuantity;

            mainCookie.TotalCookieValue -= wizardTowerBuilding.Price;
            wizardTowerBuilding.Price = wizardTowerBuilding.Price * 1.3;
            WizardTowerPrice.Text = "Price: " + ChangeNumberFormat(wizardTowerBuilding.Price, 3);
            mainCookie.ClickValue += wizardTowerBuilding.BuildingValue * 0.01;

            mainCookie.CookiePerSecond += wizardTowerBuilding.BuildingValue;
            CookiesPerSecond.Text = "per second: " + ChangeNumberFormat(mainCookie.CookiePerSecond, 3);

            WizardTowerButton_MouseEnter(sender, EventArgs.Empty);
        }

        private void WizardTowerButton_MouseEnter(object sender, EventArgs e)
        {
            InformationImage.Source = wizardTowerBuilding.IconImage.Source;
            InformationTopic.Text = wizardTowerBuilding.Name + " Building";
            InformationContent.Text = "Each cursor produces " + ChangeNumberFormat(wizardTowerBuilding.BuildingValue, 3) + " per second.\n";
            InformationContent.Text += ChangeNumberFormat(wizardTowerBuilding.BuildingsQuantity, 3) + " cursors producing " + ChangeNumberFormat(wizardTowerBuilding.BuildingValue * wizardTowerBuilding.BuildingsQuantity, 3) + " per second.";
        }

        private void WizardTowerButton_MouseLeave(object sender, MouseEventArgs e)
        {
            InformationImage.Source = null;
            InformationTopic.Text = "Hold the mouse over a building or upgrade.";
            InformationContent.Text = "A description will appear here.";
        }

        private void ShipmentButton_Click(object sender, RoutedEventArgs e)
        {
            if (mainCookie.TotalCookieValue < shipmentBuilding.Price)
                return;

            shipmentBuilding.BuildingsQuantity += 1;
            ShipmentCounter.Content = shipmentBuilding.BuildingsQuantity;

            mainCookie.TotalCookieValue -= shipmentBuilding.Price;
            shipmentBuilding.Price = shipmentBuilding.Price * 1.3;
            ShipmentPrice.Text = "Price: " + ChangeNumberFormat(shipmentBuilding.Price, 3);
            mainCookie.ClickValue += shipmentBuilding.BuildingValue * 0.01;

            mainCookie.CookiePerSecond += shipmentBuilding.BuildingValue;
            CookiesPerSecond.Text = "per second: " + ChangeNumberFormat(mainCookie.CookiePerSecond, 3);

            ShipmentButton_MouseEnter(sender, EventArgs.Empty);
        }

        private void ShipmentButton_MouseEnter(object sender, EventArgs e)
        {
            InformationImage.Source = shipmentBuilding.IconImage.Source;
            InformationTopic.Text = shipmentBuilding.Name + " Building";
            InformationContent.Text = "Each cursor produces " + ChangeNumberFormat(shipmentBuilding.BuildingValue, 3) + " per second.\n";
            InformationContent.Text += ChangeNumberFormat(shipmentBuilding.BuildingsQuantity, 3) + " cursors producing " + ChangeNumberFormat(shipmentBuilding.BuildingValue * shipmentBuilding.BuildingsQuantity, 3) + " per second.";
        }

        private void ShipmentButton_MouseLeave(object sender, MouseEventArgs e)
        {
            InformationImage.Source = null;
            InformationTopic.Text = "Hold the mouse over a building or upgrade.";
            InformationContent.Text = "A description will appear here.";
        }

        private void AlchemyLabButton_Click(object sender, RoutedEventArgs e)
        {
            if (mainCookie.TotalCookieValue < alchemyLabBuilding.Price)
                return;

            alchemyLabBuilding.BuildingsQuantity += 1;
            AlchemyLabCounter.Content = alchemyLabBuilding.BuildingsQuantity;

            mainCookie.TotalCookieValue -= alchemyLabBuilding.Price;
            alchemyLabBuilding.Price = alchemyLabBuilding.Price * 1.3;
            AlchemyLabPrice.Text = "Price: " + ChangeNumberFormat(alchemyLabBuilding.Price, 3);
            mainCookie.ClickValue += alchemyLabBuilding.BuildingValue * 0.01;

            mainCookie.CookiePerSecond += alchemyLabBuilding.BuildingValue;
            CookiesPerSecond.Text = "per second: " + ChangeNumberFormat(mainCookie.CookiePerSecond, 3);

            AlchemyLabButton_MouseEnter(sender, EventArgs.Empty);
        }

        private void AlchemyLabButton_MouseEnter(object sender, EventArgs e)
        {
            InformationImage.Source = alchemyLabBuilding.IconImage.Source;
            InformationTopic.Text = alchemyLabBuilding.Name + " Building";
            InformationContent.Text = "Each cursor produces " + ChangeNumberFormat(alchemyLabBuilding.BuildingValue, 3) + " per second.\n";
            InformationContent.Text += ChangeNumberFormat(alchemyLabBuilding.BuildingsQuantity, 3) + " cursors producing " + ChangeNumberFormat(alchemyLabBuilding.BuildingValue * alchemyLabBuilding.BuildingsQuantity, 3) + " per second.";
        }

        private void AlchemyLabButton_MouseLeave(object sender, MouseEventArgs e)
        {
            InformationImage.Source = null;
            InformationTopic.Text = "Hold the mouse over a building or upgrade.";
            InformationContent.Text = "A description will appear here.";
        }

        private void PortalButton_Click(object sender, RoutedEventArgs e)
        {
            if (mainCookie.TotalCookieValue < portalBuilding.Price)
                return;

            portalBuilding.BuildingsQuantity += 1;
            PortalCounter.Content = portalBuilding.BuildingsQuantity;

            mainCookie.TotalCookieValue -= portalBuilding.Price;
            portalBuilding.Price = portalBuilding.Price * 1.3;
            PortalPrice.Text = "Price: " + ChangeNumberFormat(portalBuilding.Price, 3);
            mainCookie.ClickValue += portalBuilding.BuildingValue * 0.01;

            mainCookie.CookiePerSecond += portalBuilding.BuildingValue;
            CookiesPerSecond.Text = "per second: " + ChangeNumberFormat(mainCookie.CookiePerSecond, 3);

            PortalButton_MouseEnter(sender, EventArgs.Empty);
        }

        private void PortalButton_MouseEnter(object sender, EventArgs e)
        {
            InformationImage.Source = portalBuilding.IconImage.Source;
            InformationTopic.Text = portalBuilding.Name + " Building";
            InformationContent.Text = "Each cursor produces " + ChangeNumberFormat(portalBuilding.BuildingValue, 3) + " per second.\n";
            InformationContent.Text += ChangeNumberFormat(portalBuilding.BuildingsQuantity, 3) + " cursors producing " + ChangeNumberFormat(portalBuilding.BuildingValue * portalBuilding.BuildingsQuantity, 3) + " per second.";
        }

        private void PortalButton_MouseLeave(object sender, MouseEventArgs e)
        {
            InformationImage.Source = null;
            InformationTopic.Text = "Hold the mouse over a building or upgrade.";
            InformationContent.Text = "A description will appear here.";
        }

        private void TimeMachineButton_Click(object sender, RoutedEventArgs e)
        {
            if (mainCookie.TotalCookieValue < timeMachineBuilding.Price)
                return;

            timeMachineBuilding.BuildingsQuantity += 1;
            TimeMachineCounter.Content = timeMachineBuilding.BuildingsQuantity;

            mainCookie.TotalCookieValue -= timeMachineBuilding.Price;
            timeMachineBuilding.Price = timeMachineBuilding.Price * 1.3;
            TimeMachinePrice.Text = "Price: " + ChangeNumberFormat(timeMachineBuilding.Price, 3);
            mainCookie.ClickValue += timeMachineBuilding.BuildingValue * 0.01;

            mainCookie.CookiePerSecond += timeMachineBuilding.BuildingValue;
            CookiesPerSecond.Text = "per second: " + ChangeNumberFormat(mainCookie.CookiePerSecond, 3);

            TimeMachineButton_MouseEnter(sender, EventArgs.Empty);
        }

        private void TimeMachineButton_MouseEnter(object sender, EventArgs e)
        {
            InformationImage.Source = timeMachineBuilding.IconImage.Source;
            InformationTopic.Text = timeMachineBuilding.Name + " Building";
            InformationContent.Text = "Each cursor produces " + ChangeNumberFormat(timeMachineBuilding.BuildingValue, 3) + " per second.\n";
            InformationContent.Text += ChangeNumberFormat(timeMachineBuilding.BuildingsQuantity, 3) + " cursors producing " + ChangeNumberFormat(timeMachineBuilding.BuildingValue * timeMachineBuilding.BuildingsQuantity, 3) + " per second.";
        }

        private void TimeMachineButton_MouseLeave(object sender, MouseEventArgs e)
        {
            InformationImage.Source = null;
            InformationTopic.Text = "Hold the mouse over a building or upgrade.";
            InformationContent.Text = "A description will appear here.";
        }

        private void AtomGeneratorButton_Click(object sender, RoutedEventArgs e)
        {
            if (mainCookie.TotalCookieValue < atomGeneratorBuilding.Price)
                return;

            atomGeneratorBuilding.BuildingsQuantity += 1;
            AtomGeneratorCounter.Content = atomGeneratorBuilding.BuildingsQuantity;

            mainCookie.TotalCookieValue -= atomGeneratorBuilding.Price;
            atomGeneratorBuilding.Price = atomGeneratorBuilding.Price * 1.3;
            AtomGeneratorPrice.Text = "Price: " + ChangeNumberFormat(atomGeneratorBuilding.Price, 3);
            mainCookie.ClickValue += atomGeneratorBuilding.BuildingValue * 0.01;

            mainCookie.CookiePerSecond += atomGeneratorBuilding.BuildingValue;
            CookiesPerSecond.Text = "per second: " + ChangeNumberFormat(mainCookie.CookiePerSecond, 3);

            AtomGeneratorButton_MouseEnter(sender, EventArgs.Empty);
        }

        private void AtomGeneratorButton_MouseEnter(object sender, EventArgs e)
        {
            InformationImage.Source = atomGeneratorBuilding.IconImage.Source;
            InformationTopic.Text = atomGeneratorBuilding.Name + " Building";
            InformationContent.Text = "Each cursor produces " + ChangeNumberFormat(atomGeneratorBuilding.BuildingValue, 3) + " per second.\n";
            InformationContent.Text += ChangeNumberFormat(atomGeneratorBuilding.BuildingsQuantity, 3) + " cursors producing " + ChangeNumberFormat(atomGeneratorBuilding.BuildingValue * atomGeneratorBuilding.BuildingsQuantity, 3) + " per second.";
        }

        private void AtomGeneratorButton_MouseLeave(object sender, MouseEventArgs e)
        {
            InformationImage.Source = null;
            InformationTopic.Text = "Hold the mouse over a building or upgrade.";
            InformationContent.Text = "A description will appear here.";
        }

        private void PrismButton_Click(object sender, RoutedEventArgs e)
        {
            if (mainCookie.TotalCookieValue < prismBuilding.Price)
                return;

            prismBuilding.BuildingsQuantity += 1;
            PrismCounter.Content = prismBuilding.BuildingsQuantity;

            mainCookie.TotalCookieValue -= prismBuilding.Price;
            prismBuilding.Price = prismBuilding.Price * 1.3;
            PrismPrice.Text = "Price: " + ChangeNumberFormat(prismBuilding.Price, 3);
            mainCookie.ClickValue += prismBuilding.BuildingValue * 0.01;

            mainCookie.CookiePerSecond += prismBuilding.BuildingValue;
            CookiesPerSecond.Text = "per second: " + ChangeNumberFormat(mainCookie.CookiePerSecond, 3);

            PrismButton_MouseEnter(sender, EventArgs.Empty);
        }

        private void PrismButton_MouseEnter(object sender, EventArgs e)
        {
            InformationImage.Source = prismBuilding.IconImage.Source;
            InformationTopic.Text = prismBuilding.Name + " Building";
            InformationContent.Text = "Each cursor produces " + ChangeNumberFormat(prismBuilding.BuildingValue, 3) + " per second.\n";
            InformationContent.Text += ChangeNumberFormat(prismBuilding.BuildingsQuantity, 3) + " cursors producing " + ChangeNumberFormat(prismBuilding.BuildingValue * prismBuilding.BuildingsQuantity, 3) + " per second.";
        }

        private void PrismButton_MouseLeave(object sender, MouseEventArgs e)
        {
            InformationImage.Source = null;
            InformationTopic.Text = "Hold the mouse over a building or upgrade.";
            InformationContent.Text = "A description will appear here.";
        }

        private void ChancemakerButton_Click(object sender, RoutedEventArgs e)
        {
            if (mainCookie.TotalCookieValue < chancemakerBuilding.Price)
                return;

            chancemakerBuilding.BuildingsQuantity += 1;
            ChancemakerCounter.Content = chancemakerBuilding.BuildingsQuantity;

            mainCookie.TotalCookieValue -= chancemakerBuilding.Price;
            chancemakerBuilding.Price = chancemakerBuilding.Price * 1.3;
            ChancemakerPrice.Text = "Price: " + ChangeNumberFormat(chancemakerBuilding.Price, 3);
            mainCookie.ClickValue += chancemakerBuilding.BuildingValue * 0.01;

            mainCookie.CookiePerSecond += chancemakerBuilding.BuildingValue;
            CookiesPerSecond.Text = "per second: " + ChangeNumberFormat(mainCookie.CookiePerSecond, 3);

            ChancemakerButton_MouseEnter(sender, EventArgs.Empty);
        }

        private void ChancemakerButton_MouseEnter(object sender, EventArgs e)
        {
            InformationImage.Source = chancemakerBuilding.IconImage.Source;
            InformationTopic.Text = chancemakerBuilding.Name + " Building";
            InformationContent.Text = "Each cursor produces " + ChangeNumberFormat(chancemakerBuilding.BuildingValue, 3) + " per second.\n";
            InformationContent.Text += ChangeNumberFormat(chancemakerBuilding.BuildingsQuantity, 3) + " cursors producing " + ChangeNumberFormat(chancemakerBuilding.BuildingValue * chancemakerBuilding.BuildingsQuantity, 3) + " per second.";
        }

        private void ChancemakerButton_MouseLeave(object sender, MouseEventArgs e)
        {
            InformationImage.Source = null;
            InformationTopic.Text = "Hold the mouse over a building or upgrade.";
            InformationContent.Text = "A description will appear here.";
        }

        private void FractalEngineButton_Click(object sender, RoutedEventArgs e)
        {
            if (mainCookie.TotalCookieValue < fractalEngineBuilding.Price)
                return;

            fractalEngineBuilding.BuildingsQuantity += 1;
            FractalEngineCounter.Content = fractalEngineBuilding.BuildingsQuantity;

            mainCookie.TotalCookieValue -= fractalEngineBuilding.Price;
            fractalEngineBuilding.Price = fractalEngineBuilding.Price * 1.3;
            FractalEnginePrice.Text = "Price: " + ChangeNumberFormat(fractalEngineBuilding.Price, 3);
            mainCookie.ClickValue += fractalEngineBuilding.BuildingValue * 0.01;

            mainCookie.CookiePerSecond += fractalEngineBuilding.BuildingValue;
            CookiesPerSecond.Text = "per second: " + ChangeNumberFormat(mainCookie.CookiePerSecond, 3);

            FractalEngineButton_MouseEnter(sender, EventArgs.Empty);
        }

        private void FractalEngineButton_MouseEnter(object sender, EventArgs e)
        {
            InformationImage.Source = fractalEngineBuilding.IconImage.Source;
            InformationTopic.Text = fractalEngineBuilding.Name + " Building";
            InformationContent.Text = "Each cursor produces " + ChangeNumberFormat(fractalEngineBuilding.BuildingValue, 3) + " per second.\n";
            InformationContent.Text += ChangeNumberFormat(fractalEngineBuilding.BuildingsQuantity, 3) + " cursors producing " + ChangeNumberFormat(fractalEngineBuilding.BuildingValue * fractalEngineBuilding.BuildingsQuantity, 3) + " per second.";
        }

        private void FractalEngineButton_MouseLeave(object sender, MouseEventArgs e)
        {
            InformationImage.Source = null;
            InformationTopic.Text = "Hold the mouse over a building or upgrade.";
            InformationContent.Text = "A description will appear here.";
        }

        private void CSharpConsoleButton_Click(object sender, RoutedEventArgs e)
        {
            if (mainCookie.TotalCookieValue < cSharpConsoleBuilding.Price)
                return;

            cSharpConsoleBuilding.BuildingsQuantity += 1;
            CSharpConsoleCounter.Content = cSharpConsoleBuilding.BuildingsQuantity;

            mainCookie.TotalCookieValue -= cSharpConsoleBuilding.Price;
            cSharpConsoleBuilding.Price = cSharpConsoleBuilding.Price * 1.3;
            CSharpConsolePrice.Text = "Price: " + ChangeNumberFormat(cSharpConsoleBuilding.Price, 3);
            mainCookie.ClickValue += cSharpConsoleBuilding.BuildingValue * 0.01;

            mainCookie.CookiePerSecond += cSharpConsoleBuilding.BuildingValue;
            CookiesPerSecond.Text = "per second: " + ChangeNumberFormat(mainCookie.CookiePerSecond, 3);

            CSharpConsoleButton_MouseEnter(sender, EventArgs.Empty);
        }

        private void CSharpConsoleButton_MouseEnter(object sender, EventArgs e)
        {
            InformationImage.Source = cSharpConsoleBuilding.IconImage.Source;
            InformationTopic.Text = cSharpConsoleBuilding.Name + " Building";
            InformationContent.Text = "Each cursor produces " + ChangeNumberFormat(cSharpConsoleBuilding.BuildingValue, 3) + " per second.\n";
            InformationContent.Text += ChangeNumberFormat(cSharpConsoleBuilding.BuildingsQuantity, 3) + " cursors producing " + ChangeNumberFormat(cSharpConsoleBuilding.BuildingValue * cSharpConsoleBuilding.BuildingsQuantity, 3) + " per second.";
        }

        private void CSharpConsoleButton_MouseLeave(object sender, MouseEventArgs e)
        {
            InformationImage.Source = null;
            InformationTopic.Text = "Hold the mouse over a building or upgrade.";
            InformationContent.Text = "A description will appear here.";
        }

        private void IdleverseButton_Click(object sender, RoutedEventArgs e)
        {
            if (mainCookie.TotalCookieValue < idleverseBuilding.Price)
                return;

            idleverseBuilding.BuildingsQuantity += 1;
            IdleverseCounter.Content = idleverseBuilding.BuildingsQuantity;

            mainCookie.TotalCookieValue -= idleverseBuilding.Price;
            idleverseBuilding.Price = idleverseBuilding.Price * 1.3;
            IdleversePrice.Text = "Price: " + ChangeNumberFormat(idleverseBuilding.Price, 3);
            mainCookie.ClickValue += idleverseBuilding.BuildingValue * 0.01;

            mainCookie.CookiePerSecond += idleverseBuilding.BuildingValue;
            CookiesPerSecond.Text = "per second: " + ChangeNumberFormat(mainCookie.CookiePerSecond, 3);

            IdleverseButton_MouseEnter(sender, EventArgs.Empty);
        }

        private void IdleverseButton_MouseEnter(object sender, EventArgs e)
        {
            InformationImage.Source = idleverseBuilding.IconImage.Source;
            InformationTopic.Text = idleverseBuilding.Name + " Building";
            InformationContent.Text = "Each cursor produces " + ChangeNumberFormat(idleverseBuilding.BuildingValue, 3) + " per second.\n";
            InformationContent.Text += ChangeNumberFormat(idleverseBuilding.BuildingsQuantity, 3) + " cursors producing " + ChangeNumberFormat(idleverseBuilding.BuildingValue * idleverseBuilding.BuildingsQuantity, 3) + " per second.";
        }

        private void IdleverseButton_MouseLeave(object sender, MouseEventArgs e)
        {
            InformationImage.Source = null;
            InformationTopic.Text = "Hold the mouse over a building or upgrade.";
            InformationContent.Text = "A description will appear here.";
        }

        private void Cookie_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            mainCookie.TotalCookieValue += mainCookie.ClickValue;
            TotalCookies.Text = ChangeNumberFormat(mainCookie.TotalCookieValue, 3) + " cookies";
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            PrepareGameToSave();
        }

        private void PrepareGameToSave()
        {
            List<object> allBuildings = new List<object>();
            List<List<object>> allUpgrades = new List<List<object>>();
            foreach (Building building in listOfAllBuildings)
            {
                if (building != null)
                {
                    PrepareBuildingsToSave(allBuildings, building);
                    PrepareUpgradesToSave(allUpgrades, building);
                }
            }
            SaveGame(allBuildings, allUpgrades);
        }

        
        private void PrepareBuildingsToSave(List<object> allBuildings, Building building)
        {
            var myBuilding = new
            {
                building.Id,
                building.Name,
                building.BuildingsQuantity,
                building.Price,
                building.BuildingValue,
                building.IsContinueClicker
            };
            allBuildings.Add(myBuilding);
        }

        private void PrepareUpgradesToSave(List<List<object>> allUpgrades, Building building)
        {
            List<object> internaUpgradeList = new List<object>();
            foreach(Upgrade upgrade in building.GetUpgrades())
            {
                var tempUpgrade = new
                {
                    upgrade.Name,
                    upgrade.Price,
                    upgrade.IsShownIcon,
                    upgrade.IsBought,
                    upgrade.Description
                };
                internaUpgradeList.Add(tempUpgrade);
            }
            allUpgrades.Add(internaUpgradeList);
        }


        private void SaveGame(List<object> allBuildings, List<List<object>> allUpgrades)
        {
            //Clear last save
            File.WriteAllText("buildings.json", "");
            File.WriteAllText("upgrades.json", "");
            File.WriteAllText("cookie.json", "");

            //Save buildings
            string convertBuildingsToString = JsonConvert.SerializeObject(allBuildings);
            File.AppendAllText("buildings.json", convertBuildingsToString);

            //Save upgrades
            string convertUpgradesToString = JsonConvert.SerializeObject(allUpgrades);
            File.AppendAllText("upgrades.json", convertUpgradesToString);

            //Save main cookie
            string convertCookieToString = JsonConvert.SerializeObject(mainCookie);
            File.AppendAllText("cookie.json", convertCookieToString);
        }

        private void MainWindow_Closed(object sender, System.ComponentModel.CancelEventArgs e)
        {
            PrepareGameToSave();
            menuWindow.CheckContinuePossibility();
            menuWindow.Show();
        }
    }
}
