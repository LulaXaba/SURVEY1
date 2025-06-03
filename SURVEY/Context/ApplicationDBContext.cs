using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SURVEY.Models;
using System.Text.Json;

namespace SURVEY.Context
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> contextOptions)
            : base(contextOptions)
        {
        }

        public DbSet<SurveyModel> Surveys { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var stringListComparer = new ValueComparer<List<string>>(
                (c1, c2) => c1.SequenceEqual(c2),
                c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                c => c.ToList());

            modelBuilder.Entity<SurveyModel>()
                .Property(s => s.FavouriteFoods)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                    v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null) ?? new List<string>())
                .Metadata.SetValueComparer(stringListComparer);

            modelBuilder.Entity<SurveyModel>()
                .Property(s => s.Name)
                .IsRequired();

            modelBuilder.Entity<SurveyModel>()
                .Property(s => s.Surname)
                .IsRequired();

            modelBuilder.Entity<SurveyModel>()
                .Property(s => s.Date)
                .IsRequired();
        }
    }
}
