﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SovaDataAccessLayer
{
    public class User
    {
        public int Ïd { get; set; }

        public string DisplayName { get; set; }

        public DateTime CreationDate { get; set; }

        public string Location { get; set; }

        public int Age { get; set; }
    }
}
