using System.Collections.Generic;
using ContentsCalcBackEnd.Core.Models;

namespace ContentsCalcBackEnd.Logic.Interfaces
{
    public interface ICalculatorService
    {
        int? Create(string name, double value, string category);
        ICollection<ContentsCalculatorItem> Read();
        void Delete(int id);
        void Update(int id, string name, double value, string category);
    }
}
