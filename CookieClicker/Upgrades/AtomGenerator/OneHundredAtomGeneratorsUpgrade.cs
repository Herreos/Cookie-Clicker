using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using CookieClicker.Buildings;

namespace CookieClicker.Upgrades.AtomGenerator
{
    class OneHundredAtomGeneratorsUpgrade : Upgrade
    {
        private AtomGeneratorBuilding atomGeneratorBuilding;

        public OneHundredAtomGeneratorsUpgrade(AtomGeneratorBuilding atomGeneratorBuilding, string name, double price, bool isShownIcon, bool isBought) : base(name, price, isShownIcon, isBought)
        {
            this.atomGeneratorBuilding = atomGeneratorBuilding;

            Description = "Atom Generators are twice as efficient.";
            PrepareImage();
        }

        private void PrepareImage()
        {
            IconImage = new Image();
            IconImage.Margin = new System.Windows.Thickness(10);
            IconImage.Source = new BitmapImage(new Uri("/Images/Upgrades/AtomGeneratorImage.png", UriKind.Relative));
        }

        public override bool IsAvaliable()
        {
            if (atomGeneratorBuilding.BuildingsQuantity == 100)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override Button CreateUpgradeIcon()
        {
            Icon = new Button()
            {
                Width = 70,
                Height = 70,
                Content = IconImage,
                Background = new SolidColorBrush(Color.FromRgb(48, 48, 48))
            };

            return Icon;
        }
    }
}
