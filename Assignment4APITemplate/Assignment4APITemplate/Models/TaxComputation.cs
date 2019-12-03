using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment4APITemplate.Models
{
    public class TaxComputation
    {
        public decimal TotalSalary { get; set; }
        public decimal TotalTaxLiability { get; set; }
        public decimal TaxPaid { get; set; }
        public int RemainingPeriods { get; set; }
        public decimal TaxPerMonth { get; set; }
    }
}