using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SovaWebAppicaltion.Model
{
    public class NoteForCreation
    {
        [Required]
        public int MarkingId { get; set; }
        
        //[Required]
        //public int UserId { get; set; }
        
        [MaxLength(300)]
        public string Note { get; set; }
    }
}
