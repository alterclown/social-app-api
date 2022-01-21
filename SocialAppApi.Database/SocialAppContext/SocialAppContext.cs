using Microsoft.EntityFrameworkCore;
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
        //public DbSet<User> User { get; set; }
        
    }
}
