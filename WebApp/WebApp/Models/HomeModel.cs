using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class HomeModel
    {
        [Key]
        public int PersonId { get; set; }
        [Required]
        public String PersonName { get; set; }
        [Required]
        public String PersonDesignation  { get; set; }
        [Required]
        public int PersonAge { get; set; }
    }
}
