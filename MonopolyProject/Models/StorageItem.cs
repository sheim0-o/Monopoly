using System.ComponentModel.DataAnnotations.Schema;

namespace Monopoly.Models
{
    public abstract class StorageItem
    {
        public Guid Id { get; } = Guid.NewGuid();
        public double Width { get; set; }
        public double Height { get; set; }
        public double Depth { get; set; }
        public virtual double Weight { get; set; }

        [NotMapped]
        public virtual double Volume => Width * Height * Depth;
    }
}
