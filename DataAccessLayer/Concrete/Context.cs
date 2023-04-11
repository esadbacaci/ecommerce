using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
	public class Context : IdentityDbContext<AppUser,AppRole,int>
    {
        //chatgpt
        //public Context(DbContextOptions<Context> options) : base(options)
        //{
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseMySql("server=localhost;database=e_commerce;user=root;password=esad2074",
				new MySqlServerVersion(new Version(8, 0, 23)));

			}
		}
        public DbSet<Product> Products { get; set; }
        public DbSet<Blog> BLogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<NewsLetter> NewsLetters { get; set; }
        public DbSet<Order> Orders { get; set; }
        

        //coredemo
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //}
    }
}
