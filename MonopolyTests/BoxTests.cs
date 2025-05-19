using Monopoly.Models;

namespace Monopoly
{
    public class BoxTests
    {
        // Проверка вычисления срока годности при указании только даты производства
        [Fact]
        public void Should_Calculate_ExpiryDate_When_ProductionDate_Is_Set()
        {
            var productionDate = new DateTime(2025, 1, 1);
            var box = new Box
            {
                Width = 10,
                Height = 10,
                Depth = 10,
                Weight = 5,
                ProductionDate = productionDate
            };

            var expiryDate = box.ExpiryDate;
            Assert.Equal(productionDate.AddDays(100), expiryDate);
        }

        // Проверка выдача ошибки, если не заполнены срок годности и дата производства
        [Fact]
        public void Should_Throw_When_No_Production_And_Expiry_Date()
        {
            var ex = Assert.Throws<InvalidOperationException>(() =>
            {
                var box = new Box
                {
                    Width = 10,
                    Height = 10,
                    Depth = 10,
                    Weight = 5
                };

                var expiry = box.ExpiryDate;
            });

            Assert.Equal("Box must have either ExpiryDate or ProductionDate defined.", ex.Message);
        }

        // Проверка вычисления объема коробки
        [Fact]
        public void Should_Calculate_Volume_Correctly()
        {
            var box = new Box
            {
                Width = 2,
                Height = 3,
                Depth = 4
            };

            Assert.Equal(24, box.Volume);
        }
    }
}
