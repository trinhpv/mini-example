using System.ComponentModel.DataAnnotations;
using MiniExample.Data.Entities;

namespace MiniExample.Model.Models
{
    public class Maker
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Location { get; set; } = null!;
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public virtual ICollection<Product> Products { get; } = new List<Product>();
    }

    public class CreateMakerDto
    {
        [Required]
        public string Name { get; set; } = null!;
        [Required, Length(2, 250)]
        public string Description { get; set; } = null!;
        [Required, Length(2, 250)]
        public string Location { get; set; } = null!;
    }

    public class MakerInfo
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Location { get; set; } = null!;

    }
}
