using KariyerPortali.Data.Infrastructure;
using KariyerPortali.Data.Repositories;
using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Service
{
    public interface ICityService
    {
        IEnumerable<City> GetCities();
        City GetCity(int id);
        void CreateCity(City city);
        void SaveCity();
    }
    public class CityService : ICityService
    {
        private readonly ICityRepository cityRepository;
        private readonly IUnitOfWork unitOfWork;
        public CityService(ICityRepository cityRepository, IUnitOfWork unitOfWork)
        {
            this.cityRepository = cityRepository;
            this.unitOfWork = unitOfWork;
        }
        #region ICityService Members
        public IEnumerable<City> GetCities()
        {
            var cities = cityRepository.GetAll();
            return cities;
        }
        public City GetCity(int id)
        {
            var city = cityRepository.GetById(id);
            return city;
        }
        public void CreateCity(City city)
        {
            cityRepository.Add(city);
        }
        public void SaveCity()
        {
            unitOfWork.Commit();
        }
        #endregion
    }
}
