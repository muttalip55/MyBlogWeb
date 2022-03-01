using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MyBlog.Models.Classes
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string Head { get; set; }
        public string Explanation { get; set; }
        public string AddressInfo { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Location { get; set; }
    }
}