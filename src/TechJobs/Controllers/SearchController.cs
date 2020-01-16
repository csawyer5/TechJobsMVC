using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

       
        public IActionResult Results(string searchType, string searchTerm)
        {

          


            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";

            List<Dictionary<string, string>> jobList = new List<Dictionary<string, string>>();

            if (searchType.Equals("all") || searchTerm.Length == 0)
            {
                jobList = JobData.FindAll();
                ViewBag.jobs = jobList;
                return View("Index");
            }
            if (searchType.Equals("all"))
            {
                jobList = JobData.FindByValue(searchTerm);
            }
            else
            {
                jobList = JobData.FindByColumnAndValue(searchType, searchTerm);
            }

            ViewBag.jobs = jobList;
            return View("Index");
        }

    }

}
