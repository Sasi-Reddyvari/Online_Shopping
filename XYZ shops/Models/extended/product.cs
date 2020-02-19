using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace XYZ_shops.Models
{
    [MetadataType(typeof(productmetadata))]
    public partial class product
    {

    }
    public class productmetadata
    {
 
        [Display(Name = "Product Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Product Name is required for unique identification")]
        public string product_name { get; set; }

        [Display(Name = "Product Category")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Product Category is required for unique identification")]
        public string product_category { get; set; }

        [Display(Name = "Product Price")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Product Price is required for unique identification")]
        public decimal product_price { get; set; }

        [Display(Name = "Product Description")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Product Description is required for unique identification")]
        public string product_description { get; set; }

        [Display(Name = "Product Image")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Product Image path is required.Ex:~/Folder/img.png")]
        public string product_image { get; set; }
    }


}