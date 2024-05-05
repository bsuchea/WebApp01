using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp01.Models.Entites{

    public class Sale {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Customer { get; set; }
        
        public string CustomerPhone { get; set; }

        public required int Qty { get; set; }

        public int Amount { get; set; } = 0;

        public int ProductId { get; set; }

    }

}