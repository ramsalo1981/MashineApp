using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MachineApp.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Fältet för kategorinamn krävs")]
        [Display(Name = "Kategori namn")]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
