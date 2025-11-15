using OpenQA.Selenium;
using PageObjectModelFramework.pageobjects.CarBrandPages;
using PageObjectModelFramework.pageobjects.CarPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectModelFramework.pageobjects
{
    internal class NewCarPage : BasePage
    {
        public NewCarPage(IWebDriver driver) : base(driver)
        {
        }

        public CarBrandPage OpenCarBrandPage(string opencarbrand, NewCarPage carbrand)
        {
            if (opencarbrand == "BMW")
            {
                BMWCarBrandPage bmwbrand = carbrand.OpenBMWCarBrandPage();
            }
            else if (opencarbrand == "Kia")
            {
                OpenKiaCarBrandPage();
            }
            else if (opencarbrand == "Audi")
            {
                AudiCarBrandPage kiabrand = carbrand.OpenAudiCarBrandPage();
            }
            else if (opencarbrand == "Toyota")
            {
                ToyotaCarBrandPage toyotabrand = carbrand.OpenToyotaCarBrandPage();
            }

            return new CarBrandPage(driver);
        }

        public BMWCarBrandPage OpenBMWCarBrandPage()
        {
            keyword.Click("NewCarPage","bmwbrand","LINK");
            
            Thread.Sleep(10000);

            return new BMWCarBrandPage(driver);
        }

        public void OpenKiaCarBrandPage()
        {
            keyword.Click("NewCarPage", "kiabrand", "LINK");

            Thread.Sleep(10000);

            //return new KIACarBrandPage(driver);
        }

        public ToyotaCarBrandPage OpenToyotaCarBrandPage()
        {
            keyword.Click("NewCarPage", "toyotabrand", "LINK");

            Thread.Sleep(10000);

            return new ToyotaCarBrandPage(driver);
        }

        public AudiCarBrandPage OpenAudiCarBrandPage()
        {
            keyword.Click("NewCarPage", "audibrand", "LINK");
      
            Thread.Sleep(10000);

            return new AudiCarBrandPage(driver);
        }

        public void ViewBrand()
        {
            keyword.Click("NewCarPage", "viewbrand", "XPATH");
        }
    }
}
