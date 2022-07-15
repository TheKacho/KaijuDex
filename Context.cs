using System.Text.Json;
using Microsoft.EntityFrameworkCore;

public class Context : DbContext
{
    private List<Monster> source;

    public Context() : base(){}
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to sqlite database
        options.UseSqlite(@"Data Source=KaijuDex.db");
    }
   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Monster> monsters = new List<Monster>();
        List<Movie> movies = new List<Movie>();
        

        using(StreamReader p = new StreamReader("Monster.json")
        {
            string json = p.ReadToEnd();
            source = JsonSerializer.Deserialize<List<Monster>>(json);
        }
        foreach (Monster p in source)
        {
            modelBuilder.Entity<Monster>().HasData(
                new Monster
                {
                    ID = p.ID,
                    Title = p.Title,
                    Creator = p.Creator,
                    BirthYear = p.BirthYear,
                    SpecialAttack = p.SpecialAttack,
                }
            );
            base.OnModelCreating(modelBuilder);
        }
        foreach (Movie p in source)
        {
            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    ID = p.ID,
                    Title = p.Title,
                    Director = p.Director,
                    YearReleased = p.YearReleased
                }
            );
        //     modelBuilder.Entity<Monster>().HasData(
        //     new Monster { ID = 1, Title = "Godzilla", Creator ="Tomoyuki Tanaka", BirthYear = 1954, SpecialAttack = "Atomic Breath"},
        //     new Monster { ID = 2, Title = "Mothra", Creator ="Shinichiro Nakamura", BirthYear = 1961, SpecialAttack = "SuperSonic Flight"},
        //     new Monster { ID = 3, Title = "King Ghidorah", Creator ="Tomoyuki Tanaka", BirthYear = 1964, SpecialAttack = "Triple Thunder Blast"},
        //     new Monster { ID = 4, Title = "Gamera", Creator ="Yonejiro Saito", BirthYear = 1965, SpecialAttack = "Firebreath"},
        //     new Monster { ID = 5, Title = "Mecha Godzilla", Creator ="Unknown", BirthYear = 1974, SpecialAttack = "Space Beam"},
        //     new Monster { ID = 6, Title = "King Kong", Creator ="Edgar Wallace", BirthYear = 1933, SpecialAttack = "Giant Punch"}
        // );

        // modelBuilder.Entity<Movie>().HasData(
        //     new Movie{Id = 1, Title = "Godzilla", Director = "Ishiro Honda", YearReleased = 1954},
        //     new Movie{Id = 2, Title = "Mothra", Director = "Ishiro Honda", YearReleased = 1961},
        //     new Movie{Id = 3, Title = "Ghidorah, the Three Headed Monster", Director = "Ishiro Honda", YearReleased = 1964},
        //     new Movie{Id = 4, Title = "Gamera, the Giant Monster", Director = "Noriaki Yuasa", YearReleased = 1965},
        //     new Movie{Id = 5, Title = "Godzilla vs. Mechagodzilla", Director = "Jun Fukuda", YearReleased = 1974},
        //     new Movie{Id = 6, Title = "King Kong", Director = "Merian C. Cooper", YearReleased = 1933}
        // );
            base.OnModelCreating(modelBuilder);
        }
    }
     
    
        
   
    
   public DbSet<Monster>? Monsters {get;set;}
   public DbSet<Movie>? Movies {get; set;}
}