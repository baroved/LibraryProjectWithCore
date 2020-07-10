using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shared.Model
{
    public class Sale
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ItemId { get; set; }
        public AbstractItem Item { get; set; }
        [Required]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public double FinalPrice { get; set; }

    }
}
