using ECocktails.Domain.DomainModels;
using ECocktails.Repository.Interface;
using ECocktails.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECocktails.Service.Implementation
{
    public class BarmansService : IBarmansService
    {
        private readonly IRepository<Barman> _barmanRepository;

        public BarmansService(IRepository<Barman> barmanRepository)
        {
            _barmanRepository = barmanRepository;
        }
        public void CreateNewBarman(Barman barman)
        {
            this._barmanRepository.Insert(barman);
        }

        public void DeleteBarman(int id)
        {
            var barman = this.GetDetailsForBarman(id);
            this._barmanRepository.Delete(barman);
        }

        public List<Barman> GetAllBarman()
        {
            return this._barmanRepository.GetAll().ToList();
        }

        public Barman GetDetailsForBarman(int id)
        {
            return this._barmanRepository.Get(id);
        }

        public void UpdateExistingBarman(Barman barman)
        {
            this._barmanRepository.Update(barman);
        }
    }
}
