﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Web.Data;

public class MoviesContext : DbContext
{
    public DbSet<Nationality> Nationalities { get; set; } = null!;
    public DbSet<Person> People { get; set; } = null!;
    public DbSet<Movie> Movies { get; set; } = null!;
    public DbSet<ActorRole> ActorRoles { get; set; } = null!;

    public MoviesContext(DbContextOptions<MoviesContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        base.OnConfiguring(options);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Nationality>(x =>
        {
            x.Property(n => n.Id)
             .ValueGeneratedNever();
        });

        builder.Entity<Person>(x =>
        {
            x.Property(p => p.Id)
             .ValueGeneratedNever();
        });

        builder.Entity<Movie>(x =>
        {
            x.Property(m => m.Id)
             .ValueGeneratedNever();

            x.HasOne(m => m.Director)
             .WithMany()
             .HasForeignKey(m => m.DirectorId)
             .OnDelete(DeleteBehavior.SetNull);
        });

        builder.Entity<ActorRole>(x =>
        {
            x.HasKey(a => new { a.PersonId, a.MovieId });

            x.HasOne(a => a.Movie)
             .WithMany(m => m.Actors)
             .HasForeignKey(a => a.MovieId);

            x.HasOne(a => a.Person)
             .WithMany()
             .HasForeignKey(a => a.PersonId);
        });
    }
}
