using SovaDataAccessLayer.FrameworkTables;
using System;
using System.Collections.Generic;
using System.Text;

namespace SovaDataAccessLayer.Interfaces
{
    public interface IMarkingsService
    {
        List<Marking> GetAllMarkings();
        void CreateMarking(Marking marking);
        List<Marking> GetMarkings(int userid);
        List<Marking> Read(int userid, int postcommentsid);
        Marking GetMarking(int markingId);
        void UpdateMarking(Marking marking);
        bool DeleteMarking(int markingId);
        bool MarkingsExcist(int markingId);
    }
}
