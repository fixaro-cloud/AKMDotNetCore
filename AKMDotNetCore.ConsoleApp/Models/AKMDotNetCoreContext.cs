﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AKMDotNetCore.ConsoleApp.Models;

public partial class AKMDotNetCoreContext : DbContext
{
    public AKMDotNetCoreContext()
    {
    }

    public AKMDotNetCoreContext(DbContextOptions<AKMDotNetCoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblBlog> TblBlogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-HA19D87N;Database=AKMDotNetCore;User ID=sa;Password=sa@123;TrustServerCertificate=True;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblBlog>(entity =>
        {
            entity.HasKey(e => e.BlogId);

            entity.ToTable("Tbl_Blogs");

            entity.Property(e => e.BlogId).HasColumnName("BlogID");
            entity.Property(e => e.BlogArthur)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.BlogContent)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.BlogTitle)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}