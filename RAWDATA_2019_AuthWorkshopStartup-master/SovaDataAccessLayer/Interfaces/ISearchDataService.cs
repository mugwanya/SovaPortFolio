using System;
using System.Collections.Generic;
using System.Text;

namespace SovaDataAccessLayer.Interfaces
{
    public interface ISearchDataService
    {
        List<int> SimpleSearch(int userId, string query);
        List<Post> ExactSearch(string query);
        List<BestResults> BestSearch(int userId, string[] query);
    }
}
