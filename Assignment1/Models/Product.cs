using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment1.Models
{
    public class Product
    {
        [Key]
        [Required]
        public int Id { get; set; }
     
        [Required]
        public string ProductCode { get; set; }
        
        [Required]
        public string ProductName { get; set; }
        public string Description { get; set; }
        
        [Required]
        public decimal Price { get; set; }
        public string Type { get; set; }
        public DateTime ExpireDate { get; set; }

    }
}