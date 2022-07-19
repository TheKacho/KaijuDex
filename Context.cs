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
   
    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     List<Monster> monsters = new List<Monster>();
        

    //     using(StreamReader p = new StreamReader("Monster.json")
    //     {
    //         string json = p.ReadToEnd();
    //         source = JsonSerializer.Deserialize<List<Monster>>(json);
    //     }
    //     foreach (Monster p in source)
    //     {
    //         List<Monster> destination = source.Select(d =>new Monster())(
    //             new Monster
    //             {
    //                 ID = d.ID,
    //                 Title = d.Title,
    //                 Creator = d.Creator,
    //                 BirthYear = d.BirthYear,
    //                 SpecialAttack = d.SpecialAttack,
    //             }
    //         );
    //     }
    
    //         modelBuilder.Entity<Monster>().HasData(
    //         new Monster { ID = 7, Title = "Rodan", Creator ="Ishiro Honda", BirthYear = 1956, SpecialAttack = "Sonic Wind Breath"},
    //         new Monster { ID = 8, Title = "Anguirus", Creator ="Motoyoshi Oda", BirthYear = 1955, SpecialAttack = "Rolling Thunder Water"},
    //         new Monster { ID = 9, Title = "Biollante", Creator ="Koichi Kawakita", BirthYear = 1989, SpecialAttack = "Piercing Rose Vines"},
    //         new Monster { ID = 10, Title = "Destoroyah", Creator ="Takao Okawara", BirthYear = 1995, SpecialAttack = "Micro Oxygen Beam"},
    //         new Monster { ID = 11, Title = "Space Godzilla", Creator ="Unknown", BirthYear = 1994, SpecialAttack = "Corona Beam"},
    //         new Monster { ID = 12, Title = "Jet Jaguar", Creator ="Masaaki Sano", BirthYear = 1975, SpecialAttack = "Sword of Light"}
    //     );
    //         base.OnModelCreating(modelBuilder);
    //     }
    // }
     
    
        
   
    
   public DbSet<Monster>? Monsters {get;set;}
   public DbSet<Movie>? Movies {get; set;}
}