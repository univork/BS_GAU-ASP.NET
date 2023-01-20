using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Homework2.Models
{
    public class Product
    {
        [Range(0, int.MaxValue, ErrorMessage = "Id must be a positive number")]
        [Required(ErrorMessage = "Id Is Requred and must not be more than 10 characters"), MaxLength(10)]
        public int Id { get; set; }

        [DisplayName("Product Name ")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Name Is Requred and must not be more than 50 characters"), MaxLength(50)]
        public String Name { get; set; }

        [Required]
        [DisplayName("Product Is Available ")]
        [Range(typeof(bool), "true", "false", ErrorMessage = "The field must be true or false")]
        public bool IsAvailable { get; set; }

        [Range(0, int.MaxValue)]
        [Required(ErrorMessage = "Product Total Amount is Required")]
        [DisplayName("Product Total Amount ")]
        public int TotalAmount { get; set; }

        [Range(0, double.MaxValue)]
        [DisplayName("Product Each Price ")]
        public double EachPrice { get; set; }

    }
}