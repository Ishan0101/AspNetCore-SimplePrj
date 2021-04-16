using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Views.Model
{
    public class ApplicationUser: IdentityUser
    {
        [DisplayName("Office Phone No.")]
        public string PhoneNumber2 { get; set; }

        [NotMapped]
        public bool Admin { get; set; }
    }
}
