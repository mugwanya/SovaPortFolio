using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SovaDataAccessLayer
{
    // Word Class
    public class Word
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Tablename { get; set; }

        [StringLength(100)]
        public string What { get; set; }

        public int Sen { get; set; }

        public int Idx { get; set; }

        [StringLength(100)]
        public string Words { get; set; }

        [StringLength(100)]
        public string Pos { get; set; }

        [StringLength(100)]
        public string Lemma { get; set; }
    }
}
