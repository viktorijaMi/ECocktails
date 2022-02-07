using ECocktails.Domain.DomainModels;
using ECocktails.Repository.Interface;
using ECocktails.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECocktails.Service.Implementation
{
    public class BarsService : IBarsService
    {
        private readonly IRepository<Bar> _barRepository;
        public BarsService(IRepository<Bar> barRepository)
        {
            this._barRepository = barRepository;
        }

        public void CreateNewBar(Bar bar)
        {
            this._barRepository.Insert(bar);
        }

        public void DeleteBar(int id)
        {
            var bar = this.GetDetailsForBar(id);
            this._barRepository.Delete(bar);
        }

        public List<Bar> GetAllBars()
        {
            return this._barRepository.GetAll().ToList();
        }

        public Bar GetDetailsForBar(int id)
        {
            return this._barRepository.Get(id);
        }

        public void UpdateExistingBar(Bar bar)
        {
            this._barRepository.Update(bar);
        }
    }
}
