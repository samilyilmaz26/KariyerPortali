﻿using KariyerPortali.Data.Infrastructure;
using KariyerPortali.Data.Repositories;
using KariyerPortali.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KariyerPortali.Service
{
    public interface ICountryService
    {
        IEnumerable<Country> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength, out int totalRecords, out int totalDisplayRecords);
        IEnumerable<Country> GetCountries();
        Country GetCountry(int id);
        void CreateCountry(Country country);
        void UpdateCountry(Country country);
        void DeleteCountry(Country country);
        void SaveCountry();
    }
    public class CountryService: ICountryService
    {
        private readonly ICountryRepository countryRepository;
        private readonly IUnitOfWork unitOfWork;
        public CountryService(ICountryRepository countryRepository, IUnitOfWork unitOfWork)
        {
            this.countryRepository = countryRepository;
            this.unitOfWork = unitOfWork;
        }
        #region ICountryService Members
        public IEnumerable<Country> Search(string search, int sortColumnIndex, string sortDirection, int displayStart, int displayLength,  out int  totalRecords, out int totalDisplayRecords)
        {
            var countries = countryRepository.Search(search, sortColumnIndex, sortDirection, displayStart, displayLength, out totalRecords, out totalDisplayRecords);

            return countries;

        }
        public IEnumerable<Country> GetCountries()
        {
            var countries = countryRepository.GetAll();
            return countries;
        }
        public Country GetCountry(int id)
        {
            var country = countryRepository.GetById(id);
            return country;
        }
        public void CreateCountry(Country country)
        {
            countryRepository.Add(country);
        }
        public void UpdateCountry(Country country)
        {
            countryRepository.Update(country);
        }
        public void DeleteCountry(Country country)
        {
            countryRepository.Delete(country);
        }
        public void SaveCountry()
        {
            unitOfWork.Commit();
        }
        #endregion
    }
}
