using System.Collections.Generic;
using System.Linq;
using ContentsCalcBackEnd.Core;
using ContentsCalcBackEnd.Core.Models;
using ContentsCalcBackEnd.Logic.Interfaces;

namespace ContentsCalcBackEnd.Logic
{
    public class CalculatorService: ICalculatorService
    {
        public int? Create(string name, double value, string category)
        {
            using (var ctx = new CalculatorDbContext())
            {
                var categoryType = ctx.ContentsCategoryTypes.FirstOrDefault(x => x.Name == category);
                if (categoryType != null)
                {
                    var contentsCalculatorItem = new ContentsCalculatorItem
                        {Name = name, ContentsCategoryTypeId = categoryType.Id, Value = value};

                    ctx.ContentsCalculatorItems.Add(contentsCalculatorItem);
                    ctx.SaveChanges();

                    return contentsCalculatorItem.Id;
                }

                return null;
            }
        }

        public ICollection<ContentsCalculatorItem> Read()
        {
            using (var ctx = new CalculatorDbContext())
            {
                return ctx.ContentsCalculatorItems.ToList();
            }
        }

        public void Delete(int id)
        {
            using (var ctx = new CalculatorDbContext())
            {
                var calculatorItem = ctx.ContentsCalculatorItems.FirstOrDefault(x => x.Id == id);
                if (calculatorItem != null)
                {
                    ctx.ContentsCalculatorItems.Remove(calculatorItem);
                    ctx.SaveChanges();
                }
            }
        }

        public void Update(int id, string name, double value, string category)
        {
            using (var ctx = new CalculatorDbContext())
            {
                var categoryType = ctx.ContentsCategoryTypes.FirstOrDefault(x => x.Name == category);
                if (categoryType != null)
                {
                    var contentsCalculatorItem = ctx.ContentsCalculatorItems.FirstOrDefault(x => x.Id == id);

                    if (contentsCalculatorItem != null)
                    {
                        contentsCalculatorItem.Name = name;
                        contentsCalculatorItem.Value = value;
                        contentsCalculatorItem.ContentsCategoryTypeId = categoryType.Id;

                        ctx.SaveChanges();

                    }
                }
            }
        }
    }
}
