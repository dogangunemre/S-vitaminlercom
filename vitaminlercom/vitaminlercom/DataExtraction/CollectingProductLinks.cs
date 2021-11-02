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
    public class CollectingProductLinks
    {
        public void CollectingProductLinks_added(String link,int BrandID)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(link);
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine("Siteye Gidildi!");
            Thread.Sleep(2000);

            IReadOnlyCollection<IWebElement> productAddressesLink = driver.FindElements(By.XPath("//div[@class='product-image']/a"));

            foreach (IWebElement productAddressesLink2 in productAddressesLink)
            {

                string productAddressesLink2Adress = productAddressesLink2.GetAttribute("href");

                ProductAddresses productAddresses = new ProductAddresses();
                productAddresses.Path = productAddressesLink2Adress;
                productAddresses.State = true;
                productAddresses.Source = BrandID;//vitaminler

                using (var context = new ProductContext())
                {
                    context.ProductAddresses.AddRange(productAddresses);

                    context.SaveChanges();
                }

            }
            try
            {
                String nextPage = driver.FindElement(By.XPath("//div[@class='pager pager-top cfix']/a[@class='pager-next']")).GetAttribute("href");
                CollectingProductLinks_added(nextPage, BrandID);
            }
            catch (Exception ex)
            {

                Console.WriteLine("biitti");
            }
            driver.Close();
        }
    }
}
