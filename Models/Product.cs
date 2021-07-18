using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MachineApp.Models
{
    public class Product
    {
        //public Product()
        //{
        //    TempItem = 1;
        //}

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Fältet för produktnamn krävs")]
        [Display(Name = "Namn")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Display(Name = "Kort beskrivning")]
        [Required(ErrorMessage = "Fältet för kort Beskrivning krävs")]
        public string ShortDesc { get; set; }

        [Required(ErrorMessage = "Fältet för produktbeskrivning krävs")]
        [Display(Name = "Beskrivning")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Fältet för pris krävs")]
        [Display(Name = "Pris")]
        [Range(1, int.MaxValue)]
        public double Price { get; set; }

        public string ImageUrl { get; set; }


        [Required(ErrorMessage = "Fältet för Kategori krävs")]
        [Display(Name = "Kategori")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        [Required(ErrorMessage = "Fältet för typ krävs")]
        [Display(Name = "Typ")]
        public int ApplicationTypeId { get; set; }
        [ForeignKey("ApplicationTypeId")]
        public ApplicationType ApplicationType { get; set; }

        //[NotMapped]
        //[Range(1, 10000, ErrorMessage = "Item must be greater than 0.")]
        //public int TempItem { get; set; }
    }
}
