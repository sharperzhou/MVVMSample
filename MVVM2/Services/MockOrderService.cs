using System.Collections.Generic;
using System.IO;

namespace MVVM2.Services
{
    public class MockOrderService : IOrderService
    {
        public void PlaceOrder(List<string> dishes)
        {
            File.WriteAllLines("order.txt", dishes);
        }
    }
}