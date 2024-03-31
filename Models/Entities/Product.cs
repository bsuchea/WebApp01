using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp01.Models.Entites{

    [Table("products")]
    public class Product {

        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("name")]
        public required string Name { get; set; }

        [Column("qty")]
        public required int Qty { get; set; }

        [Column("unit_price")]
        public required int UnitPrice { get; set; }

        [Column("details")]
        public string? Details { get; set; }

    }

}