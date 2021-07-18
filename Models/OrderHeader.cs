using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MachineApp.Models
{
    public class OrderHeader
    {
        [Key]
        public int Id { get; set; }

        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }

        [Required(ErrorMessage = "Fältet för Orderdatum krävs")]
        [Display(Name = "Orderdatum")]
        public DateTime OrderDate { get; set; }


        [Required(ErrorMessage = "Fältet för Fraktdatum krävs")]
        [Display(Name = "Fraktdatum")]
        public DateTime ShippingDate { get; set; }


        [Required(ErrorMessage = "Fältet för Ordersumma krävs")]
        [Display(Name = "Ordersumma")]
        public Double OrderTotal { get; set; }

        //[Required(ErrorMessage = "Fältet för Spårningsnummer krävs")]
        [Display(Name = "Spårningsnummer")]
        public string TrackingNumber { get; set; }

        
        [Display(Name = "Transportföretag")]
        public string Carrier { get; set; }

        [Display(Name = "Orderstatus")]
        public string OrderStatus { get; set; }

        [Display(Name = "Betalningsstatus")]
        public string PaymentStatus { get; set; }

        [Display(Name = "Betalningsdatum")]
        public DateTime PaymentDate { get; set; }

        [Display(Name = "Förfallodag")]
        public DateTime PaymentDueDate { get; set; }

        [Display(Name = "Transaktions ID")]
        public string TransactionId { get; set; }

        [Required(ErrorMessage = "Fältet för telefonnummer krävs")]
        [Display(Name = "Telefonnummer")]
        [MaxLength(10)]
        public string PhoneNumber { get; set; }


        [Required(ErrorMessage = "Fältet för Gatuadress krävs")]
        [Display(Name = "Gatuadress")]
        [MaxLength(50)]
        public string StreetAddress { get; set; }


        [Required(ErrorMessage = "Fältet för Stad krävs")]
        [Display(Name = "Stad")]
        [MaxLength(50)]
        public string City { get; set; }

        [Required(ErrorMessage = "Fältet för Postnummer krävs")]
        [Display(Name = "Postnummer")]
        [MaxLength(50)]
        public string PostalCode { get; set; }


        [Required(ErrorMessage = "Fältet för kund namn krävs")]
        [Display(Name = "namn")]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
