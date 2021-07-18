using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MachineApp.Models
{
    public class ApplicationType
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Fältet för typ krävs")]
        [Display(Name = "Typ namn")]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
