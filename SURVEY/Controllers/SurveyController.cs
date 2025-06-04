using Microsoft.AspNetCore.Mvc;
using SURVEY.Context;
using SURVEY.Models;
using System.Linq;

namespace SURVEY.Controllers
{
    public class SurveyController : Controller
    {
        private readonly ApplicationDBContext _applicationDBContex;

        // Constructor injection of ApplicationDBContext
        public SurveyController(ApplicationDBContext context)
        {
            _applicationDBContex = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult ViewResults()
        {
            var surveys = _applicationDBContex.Surveys.ToList();

            if (!surveys.Any())
            {
                return View(new SurveyResultViewModel());
            }

            var total = surveys.Count;
            var averageAge = surveys.Average(s => CalculateAge(s.DateOfBirth));
            var oldest = surveys.Max(s => CalculateAge(s.DateOfBirth));
            var youngest = surveys.Min(s => CalculateAge(s.DateOfBirth));
            var pizzaCount = surveys.Count(s => s.FavouriteFoods.Contains("Pizza"));
            var avgEatOut = surveys.Average(s => s.Out);

            var viewModel = new SurveyResultViewModel
            {
                TotalSurveys = total,
                AverageAge = Math.Round(averageAge, 1),
                OldestAge = oldest,
                YoungestAge = youngest,
                PizzaPreferencePercentage = Math.Round((double)pizzaCount / total * 100, 1),
                AverageEatOutRating = Math.Round(avgEatOut, 1)
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult SubmitSurvey(SurveyModel model)
        {
            if (ModelState.IsValid)
            {
                _applicationDBContex.Surveys.Add(model);
                _applicationDBContex.SaveChanges();
                return RedirectToAction("ViewResults");
            }
            return View("Index", model);
        }

        private int CalculateAge(DateTime dateOfBirth)
        {
            var today = DateTime.Today;
            
            // Validate date of birth
            if (dateOfBirth > today)
            {
                return 5; // Return 5 for future dates
            }
            
            var age = today.Year - dateOfBirth.Year;
            
            // Check if birthday has occurred this year
            if (dateOfBirth.Month > today.Month || 
                (dateOfBirth.Month == today.Month && dateOfBirth.Day > today.Day))
            {
                age--;
            }
            
            // Ensure minimum age is 5
            return Math.Max(5, age);
        }
    }
}
