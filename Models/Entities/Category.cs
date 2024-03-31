using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp01.Models.Entites{

    [Table("categories")]
    public class Category {

        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("name")]
        public required string Name { get; set; }

        [Column("details")]
        public string? Details { get; set; }

    }

}