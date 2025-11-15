using OpenQA.Selenium;
using PageObjectModelFramework.basetest;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectModelFramework.pageobjects
{
    internal class CarNamePage : BasePage
    {
        
        public CarNamePage(IWebDriver driver) : base(driver)
        {

        }

        public string GetCarPrice()
        {
            string price = BasePage.keyword.GetText("CarPage", "carprice", "XPATH");
            return price;
        }

        public string GetCarVariantWebTable()
        {
            string tabledata = "";
            BasePage.keyword.Click("CarPage", "carvariant", "XPATH");
            IWebElement carvariantwebtable = BasePage.keyword.FindWebElement("CarPage", "webtable", "XPATH");
            System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> rows = BasePage.keyword.GetWebElementsFromVariable("CarPage", "webtablerow", "XPATH", carvariantwebtable);
            System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> cols = BasePage.keyword.GetWebElementsFromVariable("CarPage", "webtablecolumn", "XPATH", carvariantwebtable);
        
            int total_rows = rows.Count;
            int total_cols = cols.Count;
            string start_xpath = "//section/div/div[2]/table/tbody/tr[";
            string middle_xpath = "]/td[";
            string end_xpath = "]";

            foreach (int i in Enumerable.Range(1, total_rows))
            {
                foreach (int j in Enumerable.Range(1, total_cols))
                {
                     string tabledatainfo = driver.FindElement(By.XPath(start_xpath + i + middle_xpath + j + end_xpath)).Text + " ";
                    //Console.Write(tabledata);
                    tabledata += tabledatainfo + "\t"; // use tab between columns

                }
                tabledata += Environment.NewLine; // new line after each row
            }

            return tabledata.Trim();
        }

    }
}
