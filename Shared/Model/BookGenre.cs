using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shared.Model
{
    public class BookGenre
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int BookId { get; set; }
        public Book Book { get; set; }
        [Required]
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
