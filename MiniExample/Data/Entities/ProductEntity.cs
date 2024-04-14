using System.ComponentModel.DataAnnotations;

namespace MiniExample.Data.Entities
{
    public class ProductEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        [MaxLength(250)]
        public string Description { get; set; } = null!;
        public float Price { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public int MakerId { get; set; }
        public MakerEntity Maker { get; set; } = null!;
    }
}
