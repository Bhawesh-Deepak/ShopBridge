using ShopBridge.Core.Entity.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShopBridge.Core.Entity.Inventory
{
    /// <summary>
    /// Create the model and use all the validation for model entity
    /// This class must be inherited by Base class, which contains common property for
    /// all the class.
    /// </summary>
    public class Product : Base<int>
    {
        [Required(ErrorMessage = "Product name is required.")]
        [MaxLength(200, ErrorMessage = "Invalid product name.")]
        [MinLength(2, ErrorMessage = "Invalid product name.")]
        public string ProductName { get; set; }

        [MaxLength(450, ErrorMessage = "Invalid product Description.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Product name is required.")]
        [MaxLength(90, ErrorMessage = "Invalid product SKUCode.")]
        [MinLength(2, ErrorMessage = "Invalid product SKUCode.")]
        public string SKUCode { get; set; }

        [Required(ErrorMessage = "Product price is required.")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
    }
}
