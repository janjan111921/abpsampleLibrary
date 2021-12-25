using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace library.EntityFrameworkCore
{
    public static class libraryDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<libraryDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<libraryDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
