using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MachineApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required(ErrorMessage = "Fältet för namn krävs")]
        [Display(Name = "Namn")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Fältet för Gatuadress krävs")]
        [Display(Name = "Gatuadress")]
        [MaxLength(50)]
        public string StreetAddress { get; set; }

        [Required(ErrorMessage = "Fältet för Postnummer krävs")]
        [Display(Name = "Postnummer")]
        [MaxLength(50)]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Fältet för Stad krävs")]
        [Display(Name = "Stad")]
        [MaxLength(50)]
        public string City { get; set; }

        //public int? CompanyId { get; set; }

        //[ForeignKey("CompanyId")]
        //public Company Company { get; set; }

        [NotMapped]
        public string Role { get; set; }
    }
}
