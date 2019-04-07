using System.Collections.Generic;

namespace RestServices.Domain.ViewModels
{
    public class CountryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Alpha2 { get; set; }
        public string Alpha3 { get; set; }
        public string Iso { get; set; }
    }
}