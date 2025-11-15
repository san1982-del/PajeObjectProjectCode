using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using PageObjectModelFramework.basetest;
using PageObjectModelFramework.pageobjects;
using PageObjectModelFramework.utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectModelFramework.testcases
{
    [TestFixture]
   // [Parallelizable]
    internal class FindNewCarsTest :BaseTest
    {

        // [Parallelizable(ParallelScope.Children)]
        [Test, TestCaseSource(nameof(GetTestData)), Category("bvt"), Retry(1)]
        public void TestFindNewCar(string browser, string runmode, string carbrand,string cartitle, string carname)
        {   
            SetUp(browser);
            BaseTest.log.Info(browser+" Browser is launched");
            HomePage homePage = new HomePage(driver.Value);
            BaseTest.log.Info("Homepage is launched");
            NewCarPage newcarbrand = homePage.FindNewCar();
            newcarbrand.ViewBrand();
            CarBrandPage Brandpage = newcarbrand.OpenCarBrandPage(carbrand, newcarbrand);
            Console.WriteLine(BasePage.carBase.ValidatePageTitle());
            Assert.That(cartitle.Equals(BasePage.carBase.ValidatePageTitle()), "Car Brand title not matching for : "+cartitle);
            CarNamePage carpage = Brandpage.OpenCarNamePage(carname);
            Console.WriteLine(BasePage.carBase.ValidatePageTitle());
            Assert.That(carname.Equals(BasePage.carBase.ValidatePageTitle()), "Car Name title not matching for : "+carname);
            carpage.GetCarPrice();
            BaseTest.GetExtentTest().Info("Price of " + carname+" is "  +carpage.GetCarPrice());
           string webtabledta = carpage.GetCarVariantWebTable();
            BaseTest.GetExtentTest().Info(webtabledta);
        }

        public static IEnumerable<TestCaseData> GetTestData()
        {

            var columns = new List<string> { "browser", "runmode","carbrand","cartitle","carname"};

            return DataUtil.GetTestDataFromExcel(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\resources\\testdata.xlsx", "FindNewCar", columns);

        }

    }
}
