using Microsoft.EntityFrameworkCore;

public class Context : DbContext
{
   public Context() : base(){}
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to sqlite database
        options.UseSqlite(@"Data Source=KaijuDex.db");
    }
   
   public DbSet<Monster>? Monsters {get;set;}
}