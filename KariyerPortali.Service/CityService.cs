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
        IList<City> Search(string search);
        IEnumerable<City> GetCities();
        City GetCity(int id);
        void CreateCity(City city);
        void UpdateCity(City city);
        void DeleteCity(City city);
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
        public IList<City> Search(string search)
        {
            search = search.ToLower().Trim();
            var searchWords = search.Split(' ');


            var query = GetCities();
                foreach (string sSearch in searchWords)
                {
                    if (sSearch != null && sSearch != "")
                    {
                        query = query.Where(c => c.CityId.ToString().Contains(sSearch) || c.CityName.Contains(sSearch) || c.Country.CountryName.Contains(sSearch) );
                    }
                }
                return query.ToList();
            
        }
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
        public void UpdateCity(City city)
        {
           cityRepository.Update(city);
        }
        public void DeleteCity(City city)
        {
            cityRepository.Delete(city);
        }
        public void SaveCity()
        {
            unitOfWork.Commit();
        }
        #endregion
    }
}
