using ECocktails.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECocktails.Service.Interface
{
    public interface IBarsService
    {
        List<Bar> GetAllBars();
        Bar GetDetailsForBar(int id);
        void CreateNewBar(Bar bar);
        void UpdateExistingBar(Bar bar);
        void DeleteBar(int id);
    }
}
