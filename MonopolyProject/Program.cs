using Microsoft.EntityFrameworkCore;
using Monopoly.Data;

namespace WarehouseApp
{
    class Program
    {
        static void Main()
        {
            var options = new DbContextOptionsBuilder<WarehouseContext>()
                .UseSqlServer("<Подключение к БД>")
                .Options;
            using var context = new WarehouseContext(options);
            context.Database.Migrate();

            var pallets = context.Pallets.Include(p => p.Boxes).ToList();

            // Группировка по срокам годности и сортировка внутри
            var grouped = pallets
                .GroupBy(p => p.ExpiryDate.Date)
                .OrderBy(g => g.Key)
                .Select(g => new
                {
                    ExpiryDate = g.Key,
                    Pallets = g.OrderBy(p => p.Weight).ToList()
                });

            Console.WriteLine("Группировка и сортировка по сроку годности паллетов (и сортировка в группах по весу):");
            foreach (var group in grouped)
            {
                Console.WriteLine($"\nСрок годности: {group.ExpiryDate.Date:d}");
                foreach (var p in group.Pallets)
                    Console.WriteLine($"  - Id: {p.Id}, Вес: {p.Weight:N2} кг, Объем: {p.Volume:N2}");
            }

            // Паллеты с максимальным сроком годности, отсортированные по объему
            var top3 = pallets
                .OrderByDescending(p => p.Boxes.Max(b => b.ExpiryDate.Date))
                .Take(3)
                .OrderBy(p => p.Volume)
                .ToList();

            Console.WriteLine("\n\n\nПаллеты с максимальным сроком годности:");
            foreach (var p in top3)
            {
                var maxBoxDate = p.Boxes.Max(b => b.ExpiryDate.Date);
                Console.WriteLine($"  - Id: {p.Id}, Срок: {maxBoxDate.Date:d}, Объем: {p.Volume:n}");
            }
        }
    }
}
