using SovaDataAccessLayer.FrameworkTables;
using System;
using System.Collections.Generic;
using System.Text;

namespace SovaDataAccessLayer.Interfaces
{
    interface IMarkingsService
    {
        Marking Create(Marking marking);
        List<Marking> ReadAll(int userid);
        List<Marking> Read(int userid, int postcommentsid);
        List<Marking> Read(int id);
        Marking Update(int id);
        bool Delete(int id);
    }
}
