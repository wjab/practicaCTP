
using System.ComponentModel.DataAnnotations;

namespace Inyection_dependency_example.DB
{
    public class OrderDB
    {
        [Key]
        public int IdOrder { get; set; }

        public string CustomerEmail { get; set; } = string.Empty;

        public DateTime OrderDate { get; set; }

        public List<OrderItemDB> Items { get; set; } = new List<OrderItemDB>();
    }
}