﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SovaWebAppicaltion.Model.FrameworkModels
{
    public class MarkingForCreation
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int PostCommentsId { get; set; }

    }
}

