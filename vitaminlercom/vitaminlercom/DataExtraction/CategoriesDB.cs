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
    public class CategoriesDB
    {
        public void categories_added()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.vitaminler.com/markalar");
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine("Siteye Gidildi!");
            Thread.Sleep(2000);

            var context = new ProductContext();

            IReadOnlyCollection<IWebElement> category = driver.FindElements(By.XPath("//li[@class='main-link-wrapper']"));


            foreach (IWebElement category2 in category)
            {
                IWebElement categoryB =category2.FindElement(By.XPath("a[@data-category='MainMenu']"));
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
 
                    context.Categories.AddRange(Categorya);

                    context.SaveChanges();
 
                IReadOnlyCollection<IWebElement> childcategory = category2.FindElements(By.XPath("div[@class='sub-wrapper']/ul[1]/li"));

                foreach (IWebElement childcategory2 in childcategory)
                {
                    IWebElement childcategory2B= childcategory2.FindElement(By.XPath("a"));
                    string childcategory2Address = childcategory2B.GetAttribute("href");
                    string childcategory2Name = childcategory2B.GetAttribute("title");
                    string childcategoryDescription = childcategory2B.GetAttribute("data-category");

                    Console.WriteLine(childcategory2Address);
                    Console.WriteLine(childcategory2Name);

                    Models.Categories ChildCategorya = new Models.Categories();
                    ChildCategorya.Address = childcategory2Address;
                    ChildCategorya.Name = childcategory2Name;
                    ChildCategorya.State = true;
                    ChildCategorya.Source = 1;//vitaminler
                    ChildCategorya.Description = childcategoryDescription;
                    ChildCategorya.ParentCategoryID = Categorya.ID;
                                      
                        context.Categories.AddRange(ChildCategorya);

                        context.SaveChanges();

                }

            }
            driver.Close();
        }
}
}
