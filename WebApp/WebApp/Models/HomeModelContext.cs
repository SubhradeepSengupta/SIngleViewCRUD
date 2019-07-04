using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class HomeModelContext : DbContext
    {
        public HomeModelContext(DbContextOptions<HomeModelContext> options) : base(options)
        {

        }

        public DbSet<HomeModel> TestData { get; set; }
    }
}
