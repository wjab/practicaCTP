using Inyection_dependency_example.DB;
using Inyection_dependency_example.DTOs;
using Inyection_dependency_example.Interface;

namespace Inyection_dependency_example.Implementation
{
    public class OrderAPI : IOrder
    {
        private readonly ApplicationDbContext context;

        public OrderAPI(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<int> CreateOrder(OrderDTO orderDto)
        {
            var newOrder = new OrderDB
            {
                CustomerEmail = orderDto.CustomerEmail,
                OrderDate = orderDto.OrderDate
            };

            context.Orders.Add(newOrder);
            await context.SaveChangesAsync();

            foreach (var item in orderDto.Items)
            {
                var orderItem = new OrderItemDB
                {
                    IdOrder = newOrder.IdOrder,
                    IdProduct = item.IdProduct,
                    Quantity = item.Quantity
                };

                context.OrderItems.Add(orderItem);
            }

            await context.SaveChangesAsync();

            return newOrder.IdOrder;
        }
    }
}