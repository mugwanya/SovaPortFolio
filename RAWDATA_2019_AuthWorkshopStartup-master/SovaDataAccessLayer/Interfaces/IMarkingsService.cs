using SovaDataAccessLayer.FrameworkTables;
using System;
using System.Collections.Generic;
using System.Text;

namespace SovaDataAccessLayer.Interfaces
{
    public interface IMarkingsService
    {
        void CreateMarking(Marking marking);
        List<Marking> GetMarkins(int userid);
        List<Marking> Read(int userid, int postcommentsid);
        Marking GetMarking(int markingId);
        void UpdateMarking(int markingId);
        bool DeleteMarking(int markingId);
        bool MarkingsExcist(int markingId);
    }
}
