using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using vitaminlercom.Context;
using vitaminlercom.Models;

namespace vitaminlercom.DataExtraction
{
   public class ProductsDataExtraction
    {
        public void product_added(String link,int BrandID)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(link);
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine("Siteye Gidildi!");
            Thread.Sleep(2000);
            var context = new ProductContext();

            Products products = new Products();

            //Name
            try
            {
                String ProductName = driver.FindElement(By.XPath("//h1[@itemprop='name']")).Text;
                products.Name = ProductName;
            }
            catch (Exception)
            {

                products.Name = " ";

            }

            //Unit
            try
            {
                String ProductUnit = driver.FindElement(By.XPath("//span[@class='attr-title']")).Text;

                Unit unit = context.Unit.FirstOrDefault(o => o.Name == ProductUnit);
                if (unit != null)
                {
                    products.UnitID = unit.ID;
                }
                else
                {
                    Unit unit1 = new Unit();
                    unit1.Name = ProductUnit;

                    context.Unit.AddRange(unit1);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {

                products.UnitID = 2;
            }

            //Category
            try
            {
                String categoryAddress = driver.FindElement(By.XPath("//ol[@class='catalog_path path']/li[3]/a")).GetAttribute("href");
                String categoryName = driver.FindElement(By.XPath("//ol[@class='catalog_path path']/li[3]/a")).GetAttribute("title");

                Categories category1 = context.Categories.FirstOrDefault(o => o.Address == categoryAddress);
                if (category1 != null)
                {
                    products.CategoryID = category1.ID;
                }
                else
                {
                    Categories categories2 = new Categories();
                    categories2.Address = categoryAddress;
                    categories2.Name = categoryName;

                    context.Categories.AddRange(categories2);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {

                products.CategoryID = 140;
            }

            //Price
            try
            {
                String price = driver.FindElement(By.XPath("//div[@class='product-price-content cfix ppc-fixer']/span[@class='product-price']")).GetAttribute("innerHTML");
                Decimal price1 = Convert.ToDecimal(price);

                products.Price = price1;

                String oldprice = driver.FindElement(By.XPath("//div[@class='product-price-content cfix ppc-fixer']/span[@class='product-old-price']")).GetAttribute("innerHTML");
                if (oldprice=="")
                {
                    products.OldPrice = 0;
                 }
                else
                {
                int pos = oldprice.IndexOf(" ");
                oldprice = oldprice.Substring(0, pos);
                Decimal oldprice2 = Convert.ToDecimal(oldprice);

                products.OldPrice = oldprice2;
                }
        

            }
            catch (Exception)
            {
                products.Price = 0;
                products.OldPrice = 0;

            }

            //Desciription
            try
            {
                String desc1 = driver.FindElement(By.XPath("//div[@class='ingredients-content equal1 cfix']")).GetAttribute("innerHTML");
                products.Description = desc1;

                String desc2 = driver.FindElement(By.XPath("//div[@class='product-panel-description cfix']")).GetAttribute("innerHTML");
                products.Description2 = desc2;

                String desc3 = driver.FindElement(By.XPath("//div[@class='doesnt-include']")).GetAttribute("innerHTML");
                products.Description3 = desc3;

                products.Description4 = "";
                products.Description5 = "";
            }
            catch (Exception)
            {

                products.Description = "";
                products.Description2 = "";
                products.Description3 = "";
                products.Description4 = "";
                products.Description5 = "";

            }

            //Address
            products.Address = link;

            //Barcode
            products.Barcode = "";

            //Brand
            products.BrandID = BrandID;

            //Code
            String code2=link.Substring(32);
            products.Code = code2;
            products.Source = 1;

            context.Products.AddRange(products);
            context.SaveChanges();

            //Files
            IReadOnlyCollection<IWebElement> listFiles = driver.FindElements(By.XPath("//a[@class='fancybox-thumb']/img"));
            foreach (IWebElement item in listFiles)
            {
                Random rastgele = new Random();
                int sayi = rastgele.Next(1, 10000);

                String src = item.GetAttribute("src");
                Files files = new Files();
                files.ProductID = products.ID;
                files.Path = src;
                files.RelativePath = products.Code + sayi.ToString();

                System.Net.WebClient wc = new System.Net.WebClient();
                wc.DownloadFile(src, String.Concat(@"C:\Users\EMRE\OneDrive\Masaüstü\vitaminlercom\vitaminlercom\vitaminlercom\Images\", files.RelativePath, ".jpeg"));

                    context.Files.Add(files);
                    context.SaveChanges();
                

            }

            driver.Close();
        }

    }
}
