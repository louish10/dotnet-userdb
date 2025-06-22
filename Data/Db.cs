using Microsoft.EntityFrameworkCore;
public class UserContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public string DbPath { get; }
    public UserContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "blogging.db");
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    => options.UseSqlite($"Data Source={DbPath}");
}