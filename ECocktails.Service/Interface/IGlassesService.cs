using ECocktails.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECocktails.Service.Interface
{
    public interface IGlassesService
    {
        List<Glass> GetAllGlasses();
        Glass GetDetailsForGlass(int id);
        void CreateNewGlass(Glass glass);
        void UpdateExistingGlass(Glass glass);
        void DeleteGlass(int id);
    }
}
