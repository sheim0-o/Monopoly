using System.ComponentModel.DataAnnotations.Schema;

namespace Monopoly.Models
{
    public class Box : StorageItem
    {
        public Guid Id { get; } = Guid.NewGuid();
        public DateTime? ProductionDate { get; set; }
        [NotMapped]
        private DateTime? ExpiryDateRaw;
        public DateTime ExpiryDate
        {
            get
            {

                if (ProductionDate.HasValue)
                    return ProductionDate.Value.AddDays(100);
                else if (ExpiryDateRaw.HasValue)
                    return ExpiryDateRaw.Value;
                else
                    throw new InvalidOperationException("Box must have either ExpiryDate or ProductionDate defined.");
            }
            set
            {
                ExpiryDateRaw = value;
            }
        }
    }
}
