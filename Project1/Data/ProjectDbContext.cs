using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Project1.Models;

namespace Project1.Data;

public class ProjectDbContext : DbContext
{
    public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options) { }

    public DbSet<Employee> Employees { get; set; }
}
