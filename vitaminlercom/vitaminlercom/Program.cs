using System;
using System.Collections.Generic;
using System.Linq;
using vitaminlercom.Context;
using vitaminlercom.DataExtraction;
using vitaminlercom.Models;

namespace vitaminlercom
{
    class Program
    {
        static void Main(string[] args)
        {
            //BrandsDB brands = new BrandsDB();
            //brands.brand_added();

            //CategoriesDB categories = new CategoriesDB();
            //categories.categories_added();

            //BitkiselUrunlerCategories bitkiselUrunlerCategories = new BitkiselUrunlerCategories();
            //bitkiselUrunlerCategories.BitkiselUrunlercategories_added(31);

            #region
            //CollectingProductLinks collectingProductLinks = new CollectingProductLinks();
            //try
            //{
            //    using (var contex2 = new ProductContext())
            //    {
            //        List<Brands> GetAllKategoriAddresses2 = contex2.Brands.Where(i => i.State == true).ToList();
            //        foreach (var item in GetAllKategoriAddresses2)
            //        {

            //            collectingProductLinks.CollectingProductLinks_added(item.Address, item.ID);
            //            item.State = false;
            //            contex2.SaveChanges();

            //        }
            //    }
            //}
            //catch (Exception ex)
            //{

            //    throw ex;
            //}
            #endregion
            #region
            ProductsDataExtraction productsDataExtraction = new ProductsDataExtraction();
            try
            {
                using (var contex2 = new ProductContext())
                {
                    List<ProductAddresses> productAddresses = contex2.ProductAddresses.Where(i => i.State == true).ToList();
                    foreach (var item in productAddresses)
                    {

                        productsDataExtraction.product_added(item.Path, item.Source);
                        item.State = false;
                        contex2.SaveChanges();

                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            #endregion


        }
    }
}
