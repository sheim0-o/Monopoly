using Monopoly.Models;

namespace Monopoly
{
    public class PalletTests
    {
        // Провека вычисления веса паллета
        [Fact]
        public void Should_Calculate_Weight_Correctly()
        {
            var pallet = new Pallet
            {
                Boxes = new List<Box>
                {
                    new Box { Weight = 10, ProductionDate = new DateTime(2025, 1, 1) },
                    new Box { Weight = 20, ExpiryDate = new DateTime(2025, 6, 1) }
                }
            };

            Assert.Equal(60, pallet.Weight);
        }

        // Проверка вычисления срока годности паллета (в зависимости от наличия даты производства)
        [Fact]
        public void Should_Calculate_Pallet_ExpiryDate_As_Min_Of_Boxes()
        {
            var pallet = new Pallet
            {
                Boxes = new List<Box>
                {
                    new Box { ProductionDate = new DateTime(2025, 1, 1) },
                    new Box { ExpiryDate = new DateTime(2025, 7, 1) },
                    new Box { ExpiryDate = new DateTime(2025, 6, 10) }
                }
            };

            // 01.01.2025 + 100 дней
            var expected = new DateTime(2025, 1, 1).AddDays(100);

            Assert.Equal(expected, pallet.ExpiryDate);
        }

        // Проверка вычисления объема паллета
        [Fact]
        public void Should_Calculate_Total_Volume_Correctly()
        {
            var pallet = new Pallet
            {
                Width = 100,
                Height = 50,
                Depth = 100,
                Boxes = new List<Box>
                {
                    new Box { Width = 10, Height = 10, Depth = 10 },
                    new Box { Width = 5, Height = 5, Depth = 5 }
                }
            };

            var expectedBoxVolume = 1000 + 125;
            var palletVolume = 100 * 50 * 100;

            Assert.Equal(palletVolume + expectedBoxVolume, pallet.Volume);
        }
    }
}
