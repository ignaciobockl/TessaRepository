using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ECommerceTessa.Domain
{
    public class EntityBase
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public bool ErasedState { get; set; }
    }
}
