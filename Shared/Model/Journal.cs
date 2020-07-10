using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shared.Model
{
    public class Journal : AbstractItem
    {
        [Required]
        public int EditionId { get; set; }
        public Edition Edition { get; set; }
        
    }
}
