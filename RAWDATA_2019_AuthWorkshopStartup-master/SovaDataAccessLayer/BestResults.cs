using System;
using System.Collections.Generic;
using System.Text;

namespace SovaDataAccessLayer
{
    public class BestResults
    {
        public BestResults(int pId, int Score)
        {
            postId = pId;
            score = Score;
        }

        public int postId { get; set; }
        public int score { get; set; }
    }
}
