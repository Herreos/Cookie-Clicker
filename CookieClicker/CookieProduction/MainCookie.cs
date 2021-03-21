using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieClicker.CookieProduction
{
    public class MainCookie
    {
        public double TotalCookieValue { get; set; }
        public double CookiePerSecond { get; set; }
        public double ClickValue { get; set; }

        public MainCookie(double totalCookieValue, double cookiePerSecond, double clickValue)
        {
            this.TotalCookieValue = totalCookieValue;
            this.CookiePerSecond = cookiePerSecond;
            this.ClickValue = clickValue;
        }
    }
}
