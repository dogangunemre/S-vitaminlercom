using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace vitaminlercom.Models
{
    public class Products
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int BrandID { get; set; }
        public Brands Brand { get; set; }
        public Unit Unit { get; set; }
        public int UnitID { get; set; }
        public string Barcode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Description2 { get; set; }
                public string Description3 { get; set; }
                public string Description4 { get; set; }
                public string Description5 { get; set; }
                public string Code { get; set; }
        public int CategoryID { get; set; }
        public Categories Category { get; set; }
        public ICollection<Files> Files { get; set; }
        public string Address { get; set; }
        public int Source { get; set; }
        public decimal Price { get; set; }
        public decimal OldPrice { get; set; }



    }
}
