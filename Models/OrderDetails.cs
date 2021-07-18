using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MachineApp.Models
{
    public class OrderDetails
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public OrderHeader OrderHeader { get; set; }


        [Required]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        [Range(1, 1000, ErrorMessage = "Ange ett värde mellan 1 och 1000")]
        [Display(Name = "Antal")]
        public int Count { get; set; }

        [Required(ErrorMessage = "Fältet för pris krävs")]
        [Display(Name = "Pris")]
        [Range(1, int.MaxValue)]
        public double Price { get; set; }
    }
}
