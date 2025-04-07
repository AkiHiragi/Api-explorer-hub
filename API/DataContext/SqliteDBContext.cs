using Microsoft.EntityFrameworkCore;

public class SqliteDBContext : DbContext {
    public DbSet<Contact> Contacts { get; set; }

    public SqliteDBContext(DbContextOptions<SqliteDBContext> options)
        : base(options) { }
}