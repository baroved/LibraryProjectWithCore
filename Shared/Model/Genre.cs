using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shared.Model
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
     
    }

}
