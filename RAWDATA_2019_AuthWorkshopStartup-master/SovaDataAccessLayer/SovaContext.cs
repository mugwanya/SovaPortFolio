using Microsoft.EntityFrameworkCore;


namespace SovaDataAccessLayer
{
    // Context Class
    public class SovaContext : DbContext
    {
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Inverted_Index> Inverted_Indexes { get; set; }
        public DbSet<LinkPost> LinkPosts { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<StopWord> StopWords { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Word> Words { get; set; }
        public DbSet<Wi> Wis { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Remember To Provide Your Own Password and Username, To Connect To The Sova Database
            //
            optionsBuilder.UseNpgsql(
                "host=localhost;db=stackdatabase;uid=SOVAAPI;pwd=rawdata");
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        // Test To Check Connection Url Gets All Words From SovaDatabase
         // http://localhost:5001/api/wis //

            modelBuilder.Entity<Wi>().ToTable("wi");
            modelBuilder.Entity<Wi>().Property(m => m.Id).HasColumnName("id");
            modelBuilder.Entity<Wi>().Property(m => m.Word).HasColumnName("word");

            modelBuilder.Entity<Comment>().ToTable("comments");
            modelBuilder.Entity<Comment>().Property(m => m.Id).HasColumnName("id");
            modelBuilder.Entity<Comment>().Property(m => m.PostId).HasColumnName("postid");
            modelBuilder.Entity<Comment>().Property(m => m.Score).HasColumnName("score");
            modelBuilder.Entity<Comment>().Property(m => m.Text).HasColumnName("text");
            modelBuilder.Entity<Comment>().Property(m => m.CreateDate).HasColumnName("createdate");
            modelBuilder.Entity<Comment>().Property(m => m.UserId).HasColumnName("userid");




            modelBuilder.Entity<Post>().ToTable("posts");
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

            modelBuilder.Entity<User>().ToTable("users");
             modelBuilder.Entity<User>().Property(m => m.Id).HasColumnName("id");
             modelBuilder.Entity<User>().Property(m => m.DisplayName).HasColumnName("displayname");
             modelBuilder.Entity<User>().Property(m => m.CreationDate).HasColumnName("creationdate");
             modelBuilder.Entity<User>().Property(m => m.Location).HasColumnName("location");
             modelBuilder.Entity<User>().Property(m => m.Age).HasColumnName("age");

            modelBuilder.Entity<LinkPost>().ToTable("linkpost");
            modelBuilder.Entity<LinkPost>().Property(m => m.LinkPostId).HasColumnName("postid");
            modelBuilder.Entity<LinkPost>().Property(m => m.PostId).HasColumnName("linkpostid");
           






        }


    }
}
