using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Calculator.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Expression> Expressions { get; set; }
    }
}