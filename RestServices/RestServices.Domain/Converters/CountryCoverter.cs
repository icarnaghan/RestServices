using System.Collections.Generic;
using System.Linq;
using RestServices.Domain.Entities;
using RestServices.Domain.ViewModels;

namespace RestServices.Domain.Converters
{
    public static class CountryCoverter
    {
        public static CountryViewModel Convert(Country country)
        {
            var countryViewModel = new CountryViewModel();
            countryViewModel.Id = country.Id;
            countryViewModel.Name = country.Name;
            countryViewModel.Alpha2 = country.Alpha2;
            countryViewModel.Alpha3 = country.Alpha3;
            countryViewModel.Iso = country.Iso;

            return countryViewModel;
        }

        public static List<CountryViewModel> ConvertList(IEnumerable<Country> countries)
        {
            return countries.Select(a =>
                {
                    var model = new CountryViewModel();
                    model.Id = a.Id;
                    model.Name = a.Name;
                    model.Alpha2 = a.Alpha2;
                    model.Alpha3 = a.Alpha3;
                    model.Iso = a.Iso;
                    return model;
                })
                .ToList();
        }
    }
}