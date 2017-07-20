using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsuranceQuote.Models
{
    public class VehicleModel
    {
        public Guid Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
    }
}