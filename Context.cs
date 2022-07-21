using System.Text.Json;
using Microsoft.EntityFrameworkCore;
public class Context : DbContext
{
    public Context() : base(){}
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to sqlite database
        options.UseSqlite(@"Data Source=KaijuDex.db");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Monster> source = new List<Monster>();
        using (StreamReader m = new StreamReader("Monster.json"))
        {
            string json = m.ReadToEnd();
        }
        foreach (Monster m in source)
        {
            modelBuilder.Entity<Monster>().HasData(
            new Monster
            {
                ID = m.ID,
                Title = m.Title,
                Creator = m.Creator,
                BirthYear = m.BirthYear,
                SpecialAttack = m.SpecialAttack,
            }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
   public DbSet<Monster>? Monsters {get;set;}
   public DbSet<Movie>? Movies {get; set;}
}