using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace XYZ_shops.Models
{
    [MetadataType(typeof(usermetadata))]
    public partial class user
    {
        public string confirm_password { get; set; }
    }
    public class usermetadata
    {
        [Display(Name = "User Id")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "User id is required for unique identification")]
        public string user_id { get; set; }

        [Display(Name = "Password")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Minimum 6 characteres are required")]
        public string password { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage = "Password doesnot match with confirm passowrd")]
        public string confirm_password { get; set; }

        [Display(Name = "Mobile No")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Mobile No  is required")]
        public string mobile_no { get; set; }

        [Display(Name = "Email id")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email id is required")]
        [DataType(DataType.EmailAddress)]
        public string email_id { get; set; }
    }
}