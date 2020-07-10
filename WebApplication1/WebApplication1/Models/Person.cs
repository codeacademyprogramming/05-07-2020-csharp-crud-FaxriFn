using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Person
    {
        public int Id { get; set; }
        [MaxLength(20)]
        [Required]
        public string Name { get; set; }
        [MaxLength(20)]
      
        public string Surname { get; set; }

    }
}