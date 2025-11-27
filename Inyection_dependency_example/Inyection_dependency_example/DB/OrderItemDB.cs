using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inyection_dependency_example.DB
{
    public class OrderItemDB
    {
        [Key]
        public int IdOrderItem { get; set; }

        [ForeignKey("OrderDB")]
        public int IdOrder { get; set; }
        public OrderDB? OrderDB { get; set; }

        [ForeignKey("ProductDB")]
        public int IdProduct { get; set; }
        public ProductDB? ProductDB { get; set; }

        public int Quantity { get; set; }
    }
}