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
    public class BrandsDB
    {
        public void brand_added()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.vitaminler.com/markalar");
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine("Siteye Gidildi!");
            Thread.Sleep(2000);

            IReadOnlyCollection<IWebElement> Brandis = driver.FindElements(By.XPath("//li[@class='brand-links']/a"));

            foreach (IWebElement Brandi2 in Brandis)
            {

                string brandAddress = Brandi2.GetAttribute("href");
                string brandName = Brandi2.GetAttribute("text");

                Console.WriteLine(brandAddress);
                Console.WriteLine(brandName);

                Brands branda = new Brands();
                branda.Address = brandAddress;
                branda.Name = brandName;
                branda.State = true;
                branda.Source = 1;//vitaminler
                

                using (var context = new ProductContext())
                {
                    context.Brands.AddRange(branda);

                    context.SaveChanges();
                }

            }
            driver.Close();
        }
}
}
