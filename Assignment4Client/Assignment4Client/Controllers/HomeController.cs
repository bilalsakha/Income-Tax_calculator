using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment4Client.Models;

namespace Assignment4Client.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Calculate(FormCollection form)
        {
            decimal totalSalary = 0M;
            decimal toalTaxPaid = 0M;
            int remainingMonths = 0;
            for (int index = 1; index <= 12; ++index)
            {
                totalSalary += Convert.ToDecimal(form["salary" + index.ToString()]);
                decimal taxPaid = Convert.ToDecimal(form["taxpaid" + index.ToString()]);
                if (taxPaid == 0M)
                    remainingMonths += 1;
                toalTaxPaid += taxPaid;
            }
            totalSalary += Convert.ToDecimal(form["salaryextra"]);

            TaxComputation result = CalculationManager.GetMonthlyTax(
                totalSalary, toalTaxPaid, remainingMonths); //tcc

            ViewBag.TotalSalary = result.TotalSalary;
            ViewBag.RemainingPeriods = result.RemainingPeriods;
            ViewBag.TaxPaid = result.TaxPaid;
            ViewBag.TotalTaxLiability = result.TotalTaxLiability;
            ViewBag.TaxPerMonth = result.TaxPerMonth;
            return View();
        }
    }
}