using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
