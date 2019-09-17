using System.Collections.Generic;
using System.Linq;
using ContentsCalcBackEnd.Core.Models;

namespace ContentsCalcBackEnd.Web.Models
{
    public class Calculator
    {
        public double TotalValue { get; set; }
        public List<CalculatorItem> CalculatorItems { get; set; }
    }

    public static class CalculatorModelExtensions
    {
        public static Calculator ToCalculatorModel(this ICollection<ContentsCalculatorItem> source)
        {
            if (source == null)
            {
                return null;
            }

            var criteria = new Calculator {TotalValue = source.Sum(x => x.Value), CalculatorItems = new List<CalculatorItem>()};

            if (source.Any())
            {
                criteria.CalculatorItems.AddRange(source.Select(item => item.ToCalculatorItemModel()));
            }

            return criteria;
        }
    }
}
