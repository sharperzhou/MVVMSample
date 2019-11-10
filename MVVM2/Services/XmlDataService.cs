using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using MVVM2.Models;

namespace MVVM2.Services
{
    public class XmlDataService : IDataService
    {
        public List<Dish> GetAllDishes()
        {
            string xmlFileName = Path.Combine(Environment.CurrentDirectory, "Data/Data.xml");
            XDocument xDoc = XDocument.Load(xmlFileName);
            var dishes = xDoc.Descendants("Dish");
            List<Dish> dishList = dishes.Select(dish => new Dish()
            {
                Name = dish.Element("Name")?.Value,
                Catalog = dish.Element("Catalog")?.Value,
                Comment = dish.Element("Comment")?.Value,
                Score = double.TryParse(dish.Element("Score")?.Value, out var val) ? val : double.NaN
            }).ToList();

            return dishList;
        }
    }
}