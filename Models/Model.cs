using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Models
{
    public class Model
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public Company Company { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
    }
}
