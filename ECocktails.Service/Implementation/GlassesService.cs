using ECocktails.Domain.DomainModels;
using ECocktails.Repository.Interface;
using ECocktails.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECocktails.Service.Implementation
{
    public class GlassesService: IGlassesService
    {
        private readonly IRepository<Glass> _glassRepository;
        public GlassesService(IRepository<Glass> glassRepository)
        {
            this._glassRepository = glassRepository;
        }

        public void CreateNewGlass(Glass glass)
        {
            this._glassRepository.Insert(glass);
        }

        public void DeleteGlass(int id)
        {
            var glass = this.GetDetailsForGlass(id);
            this._glassRepository.Delete(glass);
        }

        public List<Glass> GetAllGlasses()
        {
            return this._glassRepository.GetAll().ToList();
        }

        public Glass GetDetailsForGlass(int id)
        {
            return this._glassRepository.Get(id);
        }

        public void UpdateExistingGlass(Glass glass)
        {
            this._glassRepository.Update(glass);
        }
    }
}
