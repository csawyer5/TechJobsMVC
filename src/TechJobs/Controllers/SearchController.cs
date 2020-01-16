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

            if (string.IsNullOrEmpty(searchTerm))
            {
                ViewBag.error = "You did not enter a search term";
            } 
            
            else
            {
                if (searchType.Equals("all"))
                {
                    jobList = JobData.FindByValue(searchTerm);
                }
                else
                {
                    jobList = JobData.FindByColumnAndValue(searchType, searchTerm);
                }
                ViewBag.jobs = jobList;
            }

            return View("Index");
        }

    }
    
}
