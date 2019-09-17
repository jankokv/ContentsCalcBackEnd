using ContentsCalcBackEnd.Core.Models;

namespace ContentsCalcBackEnd.Web.Models
{
    public class CalculatorItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContentsCategoryType { get; set; }
        public double Value { get; set; }
    }
    public static class CalculatorItemModelExtensions
    {
        public static CalculatorItem ToCalculatorItemModel(this ContentsCalculatorItem source)
        {
            if (source == null)
            {
                return null;
            }

            var criteria = new CalculatorItem
            {
                Id = source.Id,
                Name = source.Name,
                Value = source.Value,
                ContentsCategoryType = source.ContentsCategoryType?.Name
            };

            return criteria;
        }
    }
}
