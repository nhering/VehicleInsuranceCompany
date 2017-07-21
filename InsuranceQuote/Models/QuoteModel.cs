using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsuranceQuote.Models
{
    public class QuoteModel
    {
        public Guid Id { get; set; }
        public int Age { get; set; }
        public int ZipCode { get; set; }
        public int AnnualMilage { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int AnnualPremium { get; set; }
    }
}