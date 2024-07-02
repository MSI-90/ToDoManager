﻿using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Configurations;

namespace Persistence;

public class RepositoryContext : DbContext
{
    public DbSet<TaskItem> TaskItems { get; set; }
    public DbSet<Category> Categories { get; set; }
    public RepositoryContext (DbContextOptions options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new TaskItemConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
    }
}