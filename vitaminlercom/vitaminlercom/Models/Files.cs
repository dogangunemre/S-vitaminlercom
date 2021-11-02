using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace vitaminlercom.Models
{
    public class Files
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Path { get; set; }
        public string RelativePath { get; set; }
        public bool State { get; set; }
        public int ProductID { get; set; }
        public Products Product { get; set; }
        public int Source { get; set; }

      
    }
}
