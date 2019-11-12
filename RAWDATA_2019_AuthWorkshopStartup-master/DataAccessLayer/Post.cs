using NpgsqlTypes;

namespace DataAccessLayer
{
    //Github Test Comment
    public class Post
    {
        public int ID { get; set; }
        public int postTypeID { get; set; }
        public int parentID { get; set; }
        public int acceptedAnswerID { get; set; }
        public NpgsqlDateTime creationDate { get; set; }
        public int score { get; set; }
        public string body { get; set; }
        public NpgsqlDateTime closeDate { get; set; }
        public string title { get; set; }
        public string tags { get; set; }
        public int userID { get; set; }

    }
}
