using Microsoft.EntityFrameworkCore;
using Npgsql;
using SovaDataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SovaDataAccessLayer.DataServices.QAServices
{
    public class SearchDataService : ISearchDataService
    {
        public List<BestResults> BestSearch(int userId, string[] query)
        {
            List<BestResults> results = new List<BestResults>();
            using (NpgsqlConnection connect = new NpgsqlConnection(DatabaseConnection.ConnectionString))
            {
                using (NpgsqlCommand search = new NpgsqlCommand("stackoverflow.qa.best_match_search", connect))
                {
                    search.CommandType = CommandType.StoredProcedure;
                    search.Parameters.AddWithValue("user_id", userId);
                    search.Parameters.AddWithValue("keywords", query);
                    connect.Open();
                    using (var reader = search.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            results.Add(new BestResults(reader.GetInt32(0), reader.GetInt32(1)));
                        }
                    }
                }
            }
            return results;
        }

        public List<Post> ExactSearch(string query)
        {
            throw new NotImplementedException();
        }

        public List<int> SimpleSearch(int userId, string query)
        {        
            List<int> results = new List<int>();
            using (NpgsqlConnection connect = new NpgsqlConnection(DatabaseConnection.ConnectionString))
            {
                using (NpgsqlCommand search = new NpgsqlCommand("stackoverflow.qa.search", connect))
                {
                    search.CommandType = CommandType.StoredProcedure;
                    search.Parameters.AddWithValue("user_id", userId);
                    search.Parameters.AddWithValue("search_query", query);
                    connect.Open();
                    using (var reader = search.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            results.Add(reader.GetInt32(0));
                        }
                    }
                }
            }
            return results;
        }
    }
}
