using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MachineApp.Models
{
    public class Company
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Fältet för produktnamn krävs")]
        [Display(Name = "Företagsnamn")]
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

        [Required(ErrorMessage = "Fältet för telefonnummer krävs")]
        [Display(Name = "Telefonnummer")]
        [MaxLength(10)]
        public string PhoneNumber { get; set; }
        [Display(Name = "Är auktoriserat företag")]
        public bool IsAuthorizedCompany { get; set; }
    }
}
