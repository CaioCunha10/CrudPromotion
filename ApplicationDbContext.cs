using System;
using System.Collections.Generic;
using CrudSundayTst.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudSundayTst;

public partial class ApplicationDbContext : DbContext
{
   

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Student> Students {get;  set;} = default!;
    public DbSet<Premium> Premiums {get;  set;} = default!;
        
      
  

}
