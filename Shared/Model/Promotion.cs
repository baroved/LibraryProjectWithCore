using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Shared.Model
{
    public class Promotion
    {
        [Key]
        public int Id { get; set; }
        public int? PublisherDiscountId { get; set; }
        public PublisherDiscount PublisherDiscount { get; set; }
        public int? WriterDiscountId { get; set; }
        public WriterDiscount WriterDiscount { get; set; }
        public int? GenreDiscountId { get; set; }
        public GenreDiscount GenreDiscount { get; set; }
        [Required]
        public DateTime DateStart { get; set; }
        [Required]
        public DateTime DateEnd { get; set; }
        [Required]
        public string Type { get; set; }
    }
}
