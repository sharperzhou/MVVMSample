using System.Collections.Generic;

namespace MVVM2.Services
{
    public interface IOrderService
    {
        void PlaceOrder(List<string> dishes);
    }
}