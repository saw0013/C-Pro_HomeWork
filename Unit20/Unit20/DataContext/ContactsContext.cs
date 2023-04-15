using Microsoft.EntityFrameworkCore;

public class ContactsContext : DbContext
{
    public DbSet<Contact> Contacts { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;  
                 DataBase=_ContactDataBase;    Trusted_Connection=True;");
    }
}
