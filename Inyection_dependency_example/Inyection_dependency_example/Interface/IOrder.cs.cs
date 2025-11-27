using Inyection_dependency_example.DTOs;

namespace Inyection_dependency_example.Interface
{
    public interface IOrder
    {
        Task<int> CreateOrder(OrderDTO orderDto);
    }
}
//*****