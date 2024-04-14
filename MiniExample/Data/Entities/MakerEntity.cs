using System.ComponentModel.DataAnnotations;

namespace MiniExample.Data.Entities
{
    public class MakerEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        [MaxLength(250)]
        public string Description { get; set; } = null!;
        public string Location { get; set; } = null!;
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public virtual ICollection<ProductEntity> Products { get; } = new List<ProductEntity>();
    }
}
