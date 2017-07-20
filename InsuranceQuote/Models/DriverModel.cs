using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsuranceQuote.Models
{
    public class DriverModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }

        public ICollection<VehicleModel> Vehicles { get; set; }
        public ICollection<QuoteModel> Quotes { get; set; }
    }
}