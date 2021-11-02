using vitaminlercom.Context;
using vitaminlercom.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace vitaminlercom.DataExtraction
{
    public class BitkiselUrunlerCategories
    {
        public void BitkiselUrunlercategories_added(int PID)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.vitaminler.com/markalar");
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine("Siteye Gidildi!");
            Thread.Sleep(2000);

            var context = new ProductContext();

            IReadOnlyCollection<IWebElement> category = driver.FindElements(By.XPath("//div[@class='submenu-column submenu-column-normal']/ul/li/a"));


            foreach (IWebElement category2 in category)
            {
                IWebElement categoryB =category2;
                string category2Address = categoryB.GetAttribute("href");
                string category2Name = categoryB.GetAttribute("title");
                string category2Description = categoryB.GetAttribute("data-category");

                Console.WriteLine(category2Address);
                Console.WriteLine(category2Name);

                Models.Categories Categorya = new Models.Categories();
                Categorya.Address = category2Address;
                Categorya.Name = category2Name;
                Categorya.State = true;
                Categorya.Source = 1;//vitaminler
                Categorya.Description = category2Description;
                Categorya.ParentCategoryID = PID;

                    context.Categories.AddRange(Categorya);

                    context.SaveChanges();
 
                

            }
            driver.Close();
        }
}
}
