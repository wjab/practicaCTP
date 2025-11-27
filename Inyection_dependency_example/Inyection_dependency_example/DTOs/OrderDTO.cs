namespace Inyection_dependency_example.DTOs
{
    public class OrderDTO
    {
        public List<OrderItemDTO> Items { get; set; } = new List<OrderItemDTO>();
        public string CustomerEmail { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; } = DateTime.Now;
    }
}
//recibe toda la orden