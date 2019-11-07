using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SovaDataAccessLayer
{
    public class StopWord
    {
        [Key]
        [StringLength(18)]
        public string Word { get; set; }
    }
}
