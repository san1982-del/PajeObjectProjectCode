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
        internal class CarNameandPrice : BaseTest
        {

            // [Parallelizable(ParallelScope.Children)]
            [Test, TestCaseSource(nameof(GetTestData)), Category("bvt"), Retry(2)]
            public void CarNamePrice(string browser, string runmode, string carbrand, string cartitle, string carname)
            {
                SetUp(browser);
                BaseTest.log.Info(browser + " Browser is launched");
                HomePage homePage = new HomePage(driver.Value);
                BaseTest.log.Info("Homepage is launched");
                NewCarPage newcarbrand = homePage.FindNewCar();
                newcarbrand.ViewBrand();
                CarBrandPage Brandpage = newcarbrand.OpenCarBrandPage(carbrand, newcarbrand);
                Console.WriteLine(BasePage.carBase.ValidatePageTitle());
                Assert.That(cartitle.Equals(BasePage.carBase.ValidatePageTitle()), "Car Brand title not matching for : " + cartitle);
                CarNamePage carpage = Brandpage.OpenCarNamePage(carname);

        }

            public static IEnumerable<TestCaseData> GetTestData()
            {

                var columns = new List<string> { "browser", "runmode", "carbrand", "cartitle", "carname" };

                return DataUtil.GetTestDataFromExcel(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\resources\\testdata.xlsx", "FindNewCar", columns);

            }

        }
    
}
