using Microsoft.EntityFrameworkCore;
using SocialAppApi.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialAppApi.Database.SocialAppContext
{
    public class SocialAppContext:DbContext
    {
        public SocialAppContext(DbContextOptions<SocialAppContext> options) : base(options)
        {
        }
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //}

        //Add Db set Class Here
        public DbSet<User> Users { get; set; }
        public DbSet<GroupFollower> GroupFollowers { get; set; }
        public DbSet<GroupMember> GroupMembers { get; set; }
        public DbSet<GroupPost> GroupPosts { get; set; }
        public DbSet<UserFollower> UserFollowers { get; set; }
        public DbSet<UserFriend> UserFriends { get; set; }
        public DbSet<UserMessage> UserMessages { get; set; }

        public DbSet<UserPost> UserPosts { get; set; }

    }
}
