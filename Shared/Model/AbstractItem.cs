using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Shared.Model
{
    public abstract class AbstractItem
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime PrintDate { get; set; }
        [Required]
        public int CopiesInStock { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string ImgUrl { get; set; }
        public string Type { get; set; }
        [Required]
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        [NotMapped]
        public int Discount { get; set; }
    }
}
