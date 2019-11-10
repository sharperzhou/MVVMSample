using System.Collections.Generic;
using MVVM2.Models;

namespace MVVM2.Services
{
    public interface IDataService
    {
        List<Dish> GetAllDishes();
    }
}