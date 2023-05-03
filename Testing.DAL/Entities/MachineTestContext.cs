using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Testing.Models.DTO;

namespace Testing.DAL.Entities;

public partial class MachineTestContext : DbContext
{
    public MachineTestContext(DbContextOptions<MachineTestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=127.0.0.1;port=3306;user=root;password=Admin@123;database=MachineTest");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Courses", "MachineTest");

            entity.Property(e => e.Name).HasMaxLength(45);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
