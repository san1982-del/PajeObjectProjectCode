using OpenQA.Selenium;
using PageObjectModelFramework.pageobjects.CarBrandPages;
using PageObjectModelFramework.pageobjects.CarPages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectModelFramework.pageobjects
{
    internal class CarBrandPage : BasePage
    {
        public CarBrandPage(IWebDriver driver) : base(driver)
        {
        }

        public CarNamePage OpenCarNamePage(string carName)
        {
            ReadOnlyCollection<IWebElement> carnamelist = BasePage.keyword.GetWebElements("CarBase", "carname", "XPATH");
            foreach (IWebElement car in carnamelist)
            {
                string name = car.Text.Trim();
                if (name.Equals(carName))
                {
                    car.Click();
                    Thread.Sleep(5000);
                    break;
                }

            }

            return new CarNamePage(driver);
        }


    }
}
