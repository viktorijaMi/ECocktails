using ECocktails.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECocktails.Service.Interface
{
    public interface IBarmansService
    {
        List<Barman> GetAllBarman();
        Barman GetDetailsForBarman(int id);
        void CreateNewBarman(Barman barman);
        void UpdateExistingBarman(Barman barman);
        void DeleteBarman(int id);
    }
}
