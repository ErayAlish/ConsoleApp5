using ConsoleApp5.Model.Ernährung;
using ConsoleApp5.Model.WorkoutPlan;
using Fitnessapp.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5.Daten
{
    internal class FitnessDbContext
    {
        // DbContext-Klasse für die Datenbankverbindung
        public class FitnessContext : DbContext
        {
            public DbSet<User> Users { get; set; }
            public DbSet<DietPlan> DietPlans { get; set; }

            public DbSet<Meal> Meals { get; set; }

            public DbSet<Aktivitäten> Aktivitäts { get; set; }

            public DbSet<TrainingsPlan> TrainingsPlans { get; set; } 


            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                // Definieren von Primärschlüsseln füfr jede Entität
                modelBuilder.Entity<User>().HasKey(u => u.Id);
                modelBuilder.Entity<DietPlan>().HasKey(d => d.Id);
                modelBuilder.Entity<Meal>().HasKey(m => m.Id);
                modelBuilder.Entity<Aktivitäten>().HasKey(a => a.Id);
                modelBuilder.Entity<TrainingsPlan>().HasKey(t => t.Id);


                // Immer die Basis-Methode aufrufen, um das Basisverhalten einzuschließen
                base.OnModelCreating(modelBuilder);
            }

            // OnConfiguring-Methode wird verwendet, um die Datenbankverbindung und andere Konfigurationen einzustellen
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                // Überprüfen, ob der optionsBuilder bereits konfiguriert ist, wenn nicht, konfigurieren
                if (!optionsBuilder.IsConfigured)
                {
                    // Konfigurieren der Verwendung der SQLite-Datenbank mit dem angegebenen Verbindungsstring
                    optionsBuilder.UseSqlite(@"Data Source=C:\Users\eraya\source\repos\ConsoleApp5\ConsoleApp5\fitness.db");
                }

                // Immer die Basis-Methode aufrufen, um das Basisverhalten einzuschließen
                base.OnConfiguring(optionsBuilder);
            }

        }
    }
}
