using Microsoft.EntityFrameworkCore;
using SovaDataAccessLayer.FrameworkTables;

namespace SovaDataAccessLayer
{
    // Context Class
    public class SovaContext : DbContext
    {
        //QA model
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Inverted_Index> Inverted_Indexes { get; set; }
        public DbSet<LinkPost> LinkPosts { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<StopWord> StopWords { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Word> Words { get; set; }
        public DbSet<Wi> Wis { get; set; }

        //Framework model
        public DbSet<History> Histories { get; set; }
        public DbSet<Marking> Markings { get; set; }
        public DbSet<Notes> Notes { get; set; }
        public DbSet<FrameworkTables.User> FrameworkUsers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
                "host=localhost;db=stackoverflow;uid=SOVAAPI;pwd=rawdata");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        // Test To Check Connection Url Gets All Words From SovaDatabase
         // http://localhost:5001/api/wis //

            modelBuilder.Entity<Wi>().ToTable("wi", "QA");
            modelBuilder.Entity<Wi>().Property(m => m.Id).HasColumnName("id");
            modelBuilder.Entity<Wi>().Property(m => m.Word).HasColumnName("word");

            modelBuilder.Entity<Comment>().ToTable("comments", "QA");
            modelBuilder.Entity<Comment>().Property(m => m.Id).HasColumnName("id");
            modelBuilder.Entity<Comment>().Property(m => m.PostId).HasColumnName("postid");
            modelBuilder.Entity<Comment>().Property(m => m.Score).HasColumnName("score");
            modelBuilder.Entity<Comment>().Property(m => m.Text).HasColumnName("text");
            modelBuilder.Entity<Comment>().Property(m => m.CreateDate).HasColumnName("createdate");
            modelBuilder.Entity<Comment>().Property(m => m.UserId).HasColumnName("userid");

            modelBuilder.Entity<Post>().ToTable("posts", "QA");
            modelBuilder.Entity<Post>().Property(m => m.Id).HasColumnName("id");
            modelBuilder.Entity<Post>().Property(m => m.PostTypeId).HasColumnName("posttypeid");
            modelBuilder.Entity<Post>().Property(m => m.ParentId).HasColumnName("parentid");
            modelBuilder.Entity<Post>().Property(m => m.AcceptedAnswersId).HasColumnName("acceptedanswerid");
            modelBuilder.Entity<Post>().Property(m => m.CreationDate).HasColumnName("creationdate");
            modelBuilder.Entity<Post>().Property(m => m.Score).HasColumnName("score");
            modelBuilder.Entity<Post>().Property(m => m.Body).HasColumnName("body");
            modelBuilder.Entity<Post>().Property(m => m.CloseDate).HasColumnName("closedate");
            modelBuilder.Entity<Post>().Property(m => m.Title).HasColumnName("title");
            modelBuilder.Entity<Post>().Property(m => m.Tags).HasColumnName("tags");    
            modelBuilder.Entity<Post>().Property(m => m.UserId).HasColumnName("userid");

            modelBuilder.Entity<User>().ToTable("users", "QA");
             modelBuilder.Entity<User>().Property(m => m.Id).HasColumnName("id");
             modelBuilder.Entity<User>().Property(m => m.DisplayName).HasColumnName("displayname");
             modelBuilder.Entity<User>().Property(m => m.CreationDate).HasColumnName("creationdate");
             modelBuilder.Entity<User>().Property(m => m.Location).HasColumnName("location");
             modelBuilder.Entity<User>().Property(m => m.Age).HasColumnName("age");

            modelBuilder.Entity<LinkPost>().ToTable("linkpost", "QA");
            modelBuilder.Entity<LinkPost>().Property(m => m.LinkPostId).HasColumnName("postid");
            modelBuilder.Entity<LinkPost>().Property(m => m.PostId).HasColumnName("linkpostid");

            modelBuilder.Entity<History>().ToTable("history", "Framework");
            modelBuilder.Entity<History>().Property(m => m.userid).HasColumnName("userid");
            modelBuilder.Entity<History>().Property(m => m.timestamped).HasColumnName("timestamped");
            modelBuilder.Entity<History>().Property(m => m.searchquery).HasColumnName("searchquery");
            modelBuilder.Entity<History>().HasKey(m => new { m.userid, m.timestamped});

            modelBuilder.Entity<FrameworkTables.User>().ToTable("users", "Framework");
            modelBuilder.Entity<FrameworkTables.User>().Property(m => m.Id).HasColumnName("id");
            modelBuilder.Entity<FrameworkTables.User>().Property(m => m.Username).HasColumnName("username");
            
            modelBuilder.Entity<Notes>().ToTable("notes", "Framework");
            modelBuilder.Entity<Notes>().Property(m => m.Id).HasColumnName("id");
            modelBuilder.Entity<Notes>().Property(m => m.Markingid).HasColumnName("markingid");
            modelBuilder.Entity<Notes>().Property(m => m.Userid).HasColumnName("userid");
            modelBuilder.Entity<Notes>().Property(m => m.Note).HasColumnName("note");

            modelBuilder.Entity<Marking>().ToTable("markings", "Framework");
            modelBuilder.Entity<Marking>().Property(m => m.Id).HasColumnName("id");
            modelBuilder.Entity<Marking>().Property(m => m.UserId).HasColumnName("userid");
            modelBuilder.Entity<Marking>().Property(m => m.PostCommentsId).HasColumnName("postscommentsid");
        }
    }
}
