using SovaDataAccessLayer.FrameworkTables;
using SovaDataAccessLayer.QATables;
using System;
using System.Collections.Generic;
using System.Text;

namespace SovaDataAccessLayer.Interfaces
{
    public interface IMarkingsService
    {
        int numOfPages();
        List<Marking> GetAllMarkings(PagingAttributes pagingAttributes);
        void CreateMarking(Marking marking);
        List<Marking> GetMarkings(int userid, PagingAttributes pagingAttributes);
        List<Marking> Read(int userid, int postcommentsid);
        Marking GetMarking(int markingId);
        void UpdateMarking(Marking marking);
        bool DeleteMarking(int markingId);
        bool MarkingsExcist(int markingId);
    }
}
