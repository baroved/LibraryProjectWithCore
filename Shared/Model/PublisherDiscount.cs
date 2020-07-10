using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shared.Model
{
    public class PublisherDiscount
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        [Required]
        public int Percent { get; set; }
    }
}
