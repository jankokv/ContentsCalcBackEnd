using System.Linq;
using ContentsCalcBackEnd.Core.Models;

namespace ContentsCalcBackEnd.Core
{
    public class CalculatorDbInitializer
    {
        public void Seed(CalculatorDbContext ctx)
        {
            if (!ctx.ContentsCategoryTypes.Any())
            {
                ctx.ContentsCategoryTypes.Add(new ContentsCategoryType { Id = 1, Name = "Clothing"});
                ctx.ContentsCategoryTypes.Add(new ContentsCategoryType { Id = 2, Name = "Electronics" });
                ctx.ContentsCategoryTypes.Add(new ContentsCategoryType { Id = 3, Name = "Kitchen" });
                ctx.ContentsCategoryTypes.Add(new ContentsCategoryType { Id = 4, Name = "Misc" });
                ctx.SaveChanges();
            }
        }
    }
}
