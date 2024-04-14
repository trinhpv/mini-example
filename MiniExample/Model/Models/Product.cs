using System.ComponentModel.DataAnnotations;
using MiniExample.Data.Entities;

namespace MiniExample.Model.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        [MaxLength(250)]
        public string Description { get; set; } = null!;
        public float Price { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public int MakerId { get; set; }
        public Maker Maker { get; set; } = null!;
    }


    public class CreateProductDto
    {
        [Required]
        public string Name { get; set; } = null!;
        [Required,MaxLength(250)]
        public string Description { get; set; } = null!;
        public float Price { get; set; }

        public int MakerId { get; set; }
    }
}
