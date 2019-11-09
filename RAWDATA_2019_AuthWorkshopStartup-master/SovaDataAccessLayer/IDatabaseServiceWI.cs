using System;
using System.Collections.Generic;
using System.Text;

namespace SovaDataAccessLayer
{
   public interface IDatabaseServiceWI
    {
        List<Wi> GetWords();
    }
}
