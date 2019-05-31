using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Function.Models
{
    public class Chart
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual UserData UserData { get; set; }
    }
}