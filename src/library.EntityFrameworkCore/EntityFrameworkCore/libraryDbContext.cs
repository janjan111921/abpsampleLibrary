using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using library.Authorization.Roles;
using library.Authorization.Users;
using library.Books;
using library.MultiTenancy;

namespace library.EntityFrameworkCore
{
    public class libraryDbContext : AbpZeroDbContext<Tenant, Role, User, libraryDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public virtual DbSet<Book> Books { get; set; }
        public libraryDbContext(DbContextOptions<libraryDbContext> options)
            : base(options)
        {
        }
    }
}
