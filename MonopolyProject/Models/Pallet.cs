using System.ComponentModel.DataAnnotations.Schema;

namespace Monopoly.Models
{
    public class Pallet : StorageItem
    {
        public Guid Id { get; } = Guid.NewGuid();

        [NotMapped]
        public List<Box> Boxes { get; set; } = new();
        [NotMapped]
        public DateTime ExpiryDate => Boxes.Min(b => b.ExpiryDate);
        [NotMapped]
        public override double Weight => Boxes.Sum(b => b.Weight) + 30;
        [NotMapped]
        public override double Volume => Boxes.Sum(b => b.Volume) + base.Volume;
    }
}
