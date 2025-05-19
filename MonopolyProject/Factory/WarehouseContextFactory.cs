using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Monopoly.Data;

namespace Monopoly.Factory
{
    public class WarehouseContextFactory : IDesignTimeDbContextFactory<WarehouseContext>
    {
        public WarehouseContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<WarehouseContext>();

            optionsBuilder.UseSqlServer("<Подключение к БД>");

            return new WarehouseContext(optionsBuilder.Options);
        }
    }
}
