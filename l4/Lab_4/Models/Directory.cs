using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab_4.Models
{
    public class Directory
    {
        [Key]
        public string last_name { get; set; }
        
        public string phone_number { get; set; }
    }
}